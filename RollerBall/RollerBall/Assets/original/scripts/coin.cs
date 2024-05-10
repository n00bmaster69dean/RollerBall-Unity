using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour {

    levelcontroler lc;
    player players;
    public Rigidbody rb;

    public GameObject effects;

    public float rotatespeed = 3f;
    private float speed;

    private bool i=true;
    private bool magdowncheck = false;
    public bool jump;
    public bool mag = false;
    public bool magdown = false;
    public bool pp = false;

    public AudioClip coincollect;

    private AudioSource source;


    private void Awake()
    {
        source = GetComponent<AudioSource>();
        lc = GameObject.Find("levelmanager").GetComponent<levelcontroler>();
        lc.maxcoins++;


        lc.UpdateUI();
        players = FindObjectOfType<player>();
        
    }

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        
    }


	void Update ()
    {
        //if (transform.position.y <= 2.54) { transform.position = new Vector3(transform.position.x , 0.54f, transform.position.z); }

        //if the magnet power up is true
        if (magdown==true) { magdowncheck = true; }
        if ((mag == true)||(magdown == true))
        {
            mag = false;
            magdown = false;

            pp = true;
            StartCoroutine(mycoroutine2());
        }
        if (pp == true)
        {
            if ((players.transform.position - this.transform.position).sqrMagnitude < 20 * 20)
            {
          
                Vector3 dir = players.transform.position - transform.position;
                dir = dir.normalized;
                if (magdowncheck == true)
                {
                    rb.AddForce(dir * -5);
                }
                else
                {
                    rb.AddForce(dir * 50);
                }
            }
        }
        //normal - no powerup
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y + speed, rb.velocity.z);
        transform.Rotate(Vector3.left* rotatespeed);
        if (i == true)
        {
            if (jump == true)
            {
                StartCoroutine(mycoroutine());                
                i = false;
            }
        } 
	}

    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.tag == "player"))
        {
            Instantiate(effects, this.transform.position, Quaternion.identity);
            float vol = Random.Range(0.4f, 0.4f);
            source.PlayOneShot(coincollect, vol);
            lc.coincount++;

            Destroy(this.gameObject);
            lc.UpdateUI();
        }
    }
    IEnumerator mycoroutine() {
     
        yield return new WaitForSeconds(0);
        {
            speed = 0.1f;
        }
        yield return new WaitForSeconds(3);
        {
            speed = -0.1f;
        }
        yield return new WaitForSeconds(3);


        i = true;
    }

    IEnumerator mycoroutine2()
    {

        yield return new WaitForSeconds(10);
        {
            pp = false;
        }
        rb.velocity = new Vector3(0, 0, 0);
        magdowncheck = false;
    }
}
