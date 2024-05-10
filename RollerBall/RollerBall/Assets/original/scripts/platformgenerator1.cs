using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformgenerator1 : MonoBehaviour {

    public GameObject[] tileprefabs;
    public player players;

    private Transform playerTransform;
    private float spawnZ;
    private float tilelength = 70;
    private int amntilesonscreen=3;
    public int random;


    void Start () {
        players = FindObjectOfType<player>();
        playerTransform = GameObject.FindGameObjectWithTag("player").transform;

        for (int i = 0; i < amntilesonscreen; i++)
        {
            SpawnTile();
        }
		
	}


    void Update()
    {
        if (playerTransform.position.z > (spawnZ - amntilesonscreen * tilelength))
        { SpawnTile(); }
    }

    private void newtile()
    {
        random = Random.Range(0, tileprefabs.Length);
        GameObject go;

        go = Instantiate(tileprefabs[random]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 4.2f, this.transform.position.z + 0);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += tilelength;
        go.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, go.transform.position.z);
        go.transform.rotation = this.transform.rotation;
    }


    private void SpawnTile(int prefabIndex = -1)
    {

        if (this.gameObject.name == "Plane1")
        {
            // if (playerTransform.position.z < -50)
            {
                newtile();

            }
        }

        if (this.gameObject.name == "Plane2")

        { 
            if ((playerTransform.position.z > 80) && (playerTransform.position.z < 80))
            {
                newtile();
            }
        }

        if (this.gameObject.name == "Plane3")

        {
            if ((playerTransform.position.z > 90) && playerTransform.position.z < 170)
            {
                //newtile();
            }
        }

    }
}
