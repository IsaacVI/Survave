using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneBoatController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void changeSprite()
    {
        GameObject.Find("dasBoot1").GetComponent<SpriteRenderer>().enabled = false;
        GameObject.Find("dasBoot2").GetComponent<SpriteRenderer>().enabled = true;
    }
}
