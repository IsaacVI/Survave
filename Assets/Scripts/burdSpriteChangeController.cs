using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class burdSpriteChangeController : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
	}

    public void ChangeSprite()
    {
        GameObject.Find("undund1").GetComponent<SpriteRenderer>().enabled = false;
        GameObject.Find("undund2").GetComponent<SpriteRenderer>().enabled = true;

        GameObject.Find("ButBox").GetComponent<SpriteRenderer>().enabled = false;
    }

    public void breakMusic()
    {
        GameObject.Find("music").GetComponent<AudioSource>().Stop();
        GameObject.Find("vinyl").GetComponent<AudioSource>().Play();
    }
}
