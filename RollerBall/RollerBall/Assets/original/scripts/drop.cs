using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drop : MonoBehaviour {

    public AudioClip hit;
    private bool play = true;
    private AudioSource source;
    // Use this for initialization
    void Start () {
        source = GetComponent<AudioSource>();
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "plat")
        {
            if (play)
            {
                float vol = Random.Range(0.4f, 0.4f);
                source.PlayOneShot(hit, vol);
                play = false;
                StartCoroutine(mycoroutine());
            }
        }
    }

    IEnumerator mycoroutine()
    {

        yield return new WaitForSeconds(10f);
        {
            play = true;
        }

    }
}
