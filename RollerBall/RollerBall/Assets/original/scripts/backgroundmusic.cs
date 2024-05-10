using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundmusic : MonoBehaviour {


    public AudioSource source;

	// Use this for initialization
	void Start () {
        GameObject.FindGameObjectWithTag("Music").GetComponent<backgroundmusic>().PlayMusic();

        DontDestroyOnLoad(this.gameObject);
    }

    public void PlayMusic()
    {
        if (source.isPlaying) return;
        source.Play();
    }


}
