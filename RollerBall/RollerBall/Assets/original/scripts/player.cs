using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour {
    public float speed;

    private bool onGround = false;
    public bool splats = false;
    private bool magup = false;
    private bool magdwon = false;
    private bool sizeup = false;
    private bool sizedown = false;
    private bool speedup = false;
    private bool speeddown = false;
    private bool levelchange = false;
    public bool canmove = true;
    public int roatte = 7;


    public GameObject effect;
    public GameObject boards;
    public GameObject splat;

    public GameObject[] ball;
    public GameObject[] l1;
    public GameObject[] l2;
    public GameObject[] coinsobject;


    public coin[] coins;

    public rotateboard board;
    public Rigidbody rb;
    public levelcontroler levelcontroller;

    public Text powerup;

    public AudioClip jump;


    public AudioClip coincollect;
    public AudioClip sizedowns;
    public AudioClip speeddowns;
    public AudioClip speedups;
    public AudioClip sizeups;
    public AudioClip splatsound;
    public AudioClip magnetup;
    public AudioClip magnetdown;


    private AudioSource source;




    void Start()
    {
        // PlayerPrefs.SetInt("Highscore1", 3);
        // PlayerPrefs.SetInt("Highscore2", 2);
        // PlayerPrefs.SetInt("Highscore3", 1);
        source = GetComponent<AudioSource>();
        powerup.text = "";

        splat.SetActive(false);


        board = FindObjectOfType<rotateboard>();
        rb = GetComponent<Rigidbody>();
        levelcontroller = FindObjectOfType<levelcontroler>();

    }

    void Update()
    {

        if (Input.GetKey("left"))
        {

            transform.Rotate(new Vector3(0, 0, 40) * Time.deltaTime, Space.World);
       
        }

        if (Input.GetKey("right"))
        {
            transform.Rotate(new Vector3(0, 0, -40) * Time.deltaTime, Space.World);
   
        }


        if (onGround)
        { board.pos = board.pos * 1.0125f; }

        

        //find objects with tag coin and put it in an array
        coinsobject = GameObject.FindGameObjectsWithTag("coin");
        //refrence the script and find the length of the array
        coins = new coin[coinsobject.Length];

        //put all the gameobjects in the object array and refecnce the Component script coin and add it all to the array
        for (int i = 0; i < coinsobject.Length; i++)
        {
            coins[i] = coinsobject[i].GetComponent<coin>();
        }
        //this.transform.rotation = boards.transform.rotation;

        transform.Rotate(Vector3.left * roatte);

        if (this.transform.position.y < -10)
        {
            //transform.position = new Vector3(-0.34f, 1.01f, 158.6f);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }

    }

    void FixedUpdate()
    {
        if (speed >= -3)
        {
            speed = -3;
        }

        if (Input.GetKeyDown("space") && (onGround))
        {
            
            float vol = Random.Range(0.3f, 0.3f);
            source.PlayOneShot(jump, vol);
            rb.AddForce(Vector3.up * 40f);
            onGround = false;
        }


        if (canmove == true)
        {

            rb.velocity = new Vector3(board.pos, rb.velocity.y, -speed);

        }
        else
        {
            rb.velocity = new Vector3(0, 0, -speed);
        }

    }


    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "next")
        {
            SceneManager.LoadScene("menu");
        }


        if (other.gameObject.tag == "speedup")
        {


            roatte = 9;
            if (!source.isPlaying)
            {
                float vol = Random.Range(0.3f, 0.3f);
                source.PlayOneShot(speedups, vol);
            }
            speedup = true;

            StartCoroutine(mycoroutine3());
            speed = speed - 0.5f;

        }

        if (other.gameObject.tag == "speeddown")
        {
            roatte = 5;
            if (!source.isPlaying)
            {
                float vol = Random.Range(0.3f, 0.3f);
                source.PlayOneShot(speeddowns, vol);
            }
            speeddown = true;

            StartCoroutine(mycoroutine3());
            speed = speed + 0.03f;

        }


    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "coin")
        {
            float vol = Random.Range(0.5f, 0.5f);
            source.PlayOneShot(coincollect, vol);
        }
        if (other.gameObject.tag == "gameover")
        {
            levelcontroller.savehighscore();


            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }
        if (other.gameObject.tag == "sizeup")
        {

            float vol = Random.Range(0.3f, 0.3f);
            source.PlayOneShot(sizeups, vol);
            sizeup = true;
            StartCoroutine(mycoroutine3());

            ball[0].transform.localScale = new Vector3(2, 2, 2);
            ball[1].transform.localScale = new Vector3(2, 2, 2);
            ball[2].transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
            StartCoroutine(mycoroutine());
            Instantiate(effect, other.transform.position, Quaternion.identity);
            Destroy(other.gameObject);


        }

        if (other.gameObject.tag == "sizedown")
        {


            float vol = Random.Range(0.3f, 0.3f);
            source.PlayOneShot(sizedowns, vol);

            sizedown = true;
            StartCoroutine(mycoroutine3());

            ball[0].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            ball[1].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            ball[2].transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            StartCoroutine(mycoroutine());
            Instantiate(effect, other.transform.position, Quaternion.identity);
            Destroy(other.gameObject);

        }

        if (other.gameObject.tag == "splat")
        {
              float vol = Random.Range(0.3f, 0.3f);
            source.PlayOneShot(splatsound, vol);
            splat.SetActive(true);
            splats = true;
            StartCoroutine(mycoroutine2());
            Destroy(other.gameObject);

        }

        if (other.gameObject.tag == "magup")
        {
            float vol = Random.Range(0.5f, 0.5f);
            source.PlayOneShot(magnetup, vol);
            magup = true;
            StartCoroutine(mycoroutine3());

            for (int a = 0; a < coins.Length; a++)
            {
                coins[a].mag = true;
            }
            Instantiate(effect, other.transform.position, Quaternion.identity);
            Destroy(other.gameObject);

        }

        if (other.gameObject.tag == "magdown")
        {
            float vol = Random.Range(0.5f, 0.5f);
            source.PlayOneShot(magnetdown, vol);
            magdwon = true;
            StartCoroutine(mycoroutine3());


            for (int a = 0; a < coins.Length; a++)
            {
                coins[a].magdown = true;
            }
            Instantiate(effect, other.transform.position, Quaternion.identity);
            Destroy(other.gameObject);

        }

        if (other.gameObject.tag == "trigger1")
        {

            levelchange = true;

           StartCoroutine(mycoroutine3());

            //for (int i = 0; i < l2.Length; i++)
            //{

            //    l2[i].gameObject.SetActive(false);
            //}
            //for (int i = 0; i < l1.Length; i++)
            //{
            //    l1[i].gameObject.SetActive(false);
            //    l1[i].gameObject.SetActive(true);

            //    for (int e = 0; e < walls.Length; e++)
            //    {
            //        walls[e].move = true;
            //    }
            //}

        }


        if (other.gameObject.tag == "trigger2")
        {
            levelchange = true;

            StartCoroutine(mycoroutine3());
            //for (int i = 0; i < l2.Length; i++)
            //{
            //    l2[i].gameObject.SetActive(false);

            //    l2[i].gameObject.SetActive(true);
            //    for (int e = 0; e < walls2.Length; e++)
            //    {
            //        walls2[e].move = true;
            //    }
            //}
            //for (int i = 0; i < l1.Length; i++)
            //{

            //    l1[i].gameObject.SetActive(false);
            //}

        }
    }
    void OnCollisionEnter(Collision other)
    {
        if ((other.gameObject.tag == "plat") || (other.gameObject.tag == "high"))
        {
            onGround = true;
        }


        if (other.gameObject.tag == "wall")
        {
            levelcontroller.savehighscore();


            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

            levelcontroller.UpdateUI();
        }
    }

    void OnCollisionExit(Collision other)
    {
        if ((other.gameObject.tag == "plat") || (other.gameObject.tag == "high"))
        {
            onGround = false;
        }
    }

        IEnumerator mycoroutine()
    {

        yield return new WaitForSeconds(10f);
        {
            transform.localScale = new Vector3(1, 1, 1);
            ball[1].transform.localScale = new Vector3(1f, 1f, 1f);
            ball[2].transform.localScale = new Vector3(0.1720144f, 0.1720144f, 0.1720144f);
        }

    }


    IEnumerator mycoroutine2()
    {
        yield return new WaitForSeconds(4f);
        {
            splats = false;
          
        }
        yield return new WaitForSeconds(0.01f);
        {
          
            splat.SetActive(false);
        }


    }

    IEnumerator mycoroutine3()
    {
        yield return new WaitForSeconds(0f);
        {
            if (magup == true) {  powerup.text = "Magnet Pull! "; }
            if (magdwon == true) { powerup.text = "Magnet Push! "; }
            if (sizeup == true) { powerup.text = "Size Up! "; }
            if (sizedown == true) { powerup.text = "Size Down! "; }
            if (speedup == true) { powerup.text = "Speed Up! "; }
            if (speeddown == true) { powerup.text = "Speed Down! "; }
            if (levelchange == true) { powerup.text = "Level Change! "; }

          


           // powerup.text = "Speed Up! ";//+ coincount.ToString() + "/" + maxcoins.ToString();

        
        }

        yield return new WaitForSeconds(0.5f);
        {
            powerup.text = "";

            magdwon = false;
            magup = false;
            sizeup = false;
            sizedown = false;
            speedup = false;
            speeddown = false;
            levelchange = false;

        }



    }
}

