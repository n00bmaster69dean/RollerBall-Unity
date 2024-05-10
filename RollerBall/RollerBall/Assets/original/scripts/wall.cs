using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall : MonoBehaviour {

    levelcontroler lc;
    rotateboard board;
    public Rigidbody rb;

    public GameObject[] points;

    [SerializeField] bool jump;
    public bool move = true;
    public bool loop = false;
    public bool rotate;

    public float rotatespeed;
    public float speedx;
    public float speedy;
    public float time;

    public int follow = 0;

    public AudioClip moving;


    private AudioSource moves;



    private void Awake()
    {
        moves = GetComponent<AudioSource>();
        if (jump == true)
        {
            if (points.Length >= 1)
            {
                transform.position = new Vector3(points[0].transform.position.x, points[0].transform.position.y, points[0].transform.position.z);
            }
        }
        lc = GameObject.Find("levelmanager").GetComponent<levelcontroler>();
        board = GameObject.Find("Plane1").GetComponent<rotateboard>();


    }

    void Start ()
    {
		rb = GetComponent<Rigidbody>();
  
    }


	void Update ()
    {


            float step = speedx * Time.deltaTime;

            for (int p = 0; p <= follow; p++)
            {
            if (follow < points.Length)
            {
                transform.position = Vector3.MoveTowards((transform.position), points[follow].transform.position, step);
            }
                    
            }

        if (rotate == true)
        { transform.Rotate(Vector3.left * rotatespeed);
            transform.Rotate(Vector3.up * rotatespeed);
        }

        if (move == true)
        {
        
            if (jump == true)
            {
               
                StartCoroutine(mycoroutine());
                move = false;
            }
        }
        
	}

	private void OnCollisionEnter(Collision other)
    {
  
    }
    IEnumerator mycoroutine() {

        
        for (int p = 0; p <= follow; p++)
        {
            if (p == follow)
            {
                if (follow < points.Length)
                {
                    yield return new WaitForSeconds(time);
                    {
                        float vol = Random.Range(0.4f, 0.4f);
                        moves.PlayOneShot(moving, vol);
                        follow = follow + 1;
                    }
                }
                else
                {
                    if (loop == true)
                    { follow = 0; }
                }

            }

        }
        move = true;
    }
}
