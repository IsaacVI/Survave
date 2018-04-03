using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ernestoCutsceneController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void changeSprite12()
    {
        GameObject.Find("ernesto1").GetComponent<SpriteRenderer>().enabled = false;
        GameObject.Find("ernesto2").GetComponent<SpriteRenderer>().enabled = true;
    }
    public void changeSprite23()
    {
        GameObject.Find("ernesto2").GetComponent<SpriteRenderer>().enabled = false;
        GameObject.Find("ernesto3").GetComponent<SpriteRenderer>().enabled = true;
    }
    public void disableSprite()
    {
        GameObject.Find("ernesto3").GetComponent<SpriteRenderer>().enabled = false;
    }
    public void changeBoatSprite()
    {
        GameObject.Find("ernesto3").GetComponent<SpriteRenderer>().enabled = false;
        GameObject.Find("dasBoot1").GetComponent<SpriteRenderer>().enabled = false;
        GameObject.Find("dasBoot2").GetComponent<SpriteRenderer>().enabled = true;
    }
}
