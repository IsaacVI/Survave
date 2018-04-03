using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneController : MonoBehaviour {

	public float axisX, axisY;
	public int speed;

    public float speedX;
    public float speedY;

    private bool telefon;

    public float  Y;

	public static float waveHorizontalSpeed; // -1 -right; 0 - no move; 1 - left
	public static float waveAplitude; // 0 - flat; 1- curve



	// Use this for initialization
	void Start ()
	{
	    telefon = true;
	    Y = 0;
	}
	

	void Update ()
	{
	    if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.1f || Mathf.Abs(Input.GetAxis("Vertical")) > 0.1f && telefon)
	        telefon = false;
	    if (!telefon)
	    {
	        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.1f)
	            waveHorizontalSpeed = Input.GetAxis("Horizontal");
	        if (Mathf.Abs(Input.GetAxis("Vertical")) > 0.1f)
	            Y += Input.GetAxis("Vertical");
	        if (Y > 1)
	            Y = 1;
	        if (Y < -1)
	            Y = -1;
	        if (Mathf.Abs(waveAplitude - Y) > 0.1f)
	        {
	            if (waveAplitude > Y)
	                waveAplitude -= speedY*Time.deltaTime;
	            if (waveAplitude < Y)
	                waveAplitude += speedY*Time.deltaTime;
	        }
	    }
	    if (telefon)
	    {
	        waveHorizontalSpeed = Input.acceleration.x;
	        //waveAplitude =  Input.acceleration.y;
	        if (Mathf.Abs(waveAplitude - Input.acceleration.y) > 0.1f)
	        {
	            if (waveAplitude > Input.acceleration.y)
	                waveAplitude -= speedY*Time.deltaTime;
	            if (waveAplitude < Input.acceleration.y)
	                waveAplitude += speedY*Time.deltaTime;
	        }
	    }

	}
}
