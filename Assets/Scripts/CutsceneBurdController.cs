using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneBurdController : MonoBehaviour
{
    public Vector3 startPosition;
    public Vector3 endPosition;
    // Use this for initialization
    void Start ()
    {
        this.transform.position = startPosition;
    }
	
	// Update is called once per frame
	void Update ()
    {
    
	}
}
