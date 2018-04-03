using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObscaleController : MonoBehaviour {

	public float speed;
	public bool swim;
	public bool active;
	float positionY;
	float speedY;
	public float speedAir;
	public float speedWater;
	public float acelerationWater;
	public float acelerationAir;
	public float maxAirFallSpeed;

	public float maxRotate;
	public float minSize;
	public float maxMuliplerSize;
	bool visable;
	public float Height;
	public Vector3 spawnerPosition;
	public Vector3 storagePosition;
    public bool upperWater;
    public float waterOffset;
    public float maxHeight;
    public float minHeight;
    public bool randomHeight;

	void OnBecameVisible()
	{
		visable = true;
	}

	void OnBecameInvisible()
	{
		if (visable)
			Disactive ();
	}

	// Use this for initialization
	void Start () {
		Disactive ();
	    speedY = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (active) {
		    if (upperWater)
		    {
		        if ((Mathf.Cos(this.transform.position.x*GameController.freq + GameController.angle)*GameController.amp) +
		            GameController.hC - GameController.waveOffset > Height)
		        {
                    transform.position = new Vector3(transform.position.x,(Mathf.Cos(this.transform.position.x * GameController.freq + GameController.angle) * GameController.amp) + GameController.hC - GameController.waveOffset+waterOffset,transform.position.z);
		        }
		        else
		        {
                    transform.position = new Vector3(transform.position.x, Height, transform.position.z);
                }

		    }
		    if (swim) {
				if (this.transform.position.y> (Mathf.Cos(this.transform.position.x * GameController.freq + GameController.angle) * GameController.amp) + GameController.hC - GameController.waveOffset) {
					speedY -= acelerationAir * Time.deltaTime;
				    if (speedY > maxAirFallSpeed)
				    {
                        speedY = maxAirFallSpeed;
				    }
                } else {
					speedY += acelerationWater * Time.deltaTime;
                }

			} 
           
			transform.position = Vector3.MoveTowards(transform.position,new Vector3(transform.position.x-100,transform.position.y,transform.position.z), speed * Time.deltaTime );
		 
			transform.position = Vector3.MoveTowards(transform.position,new Vector3(transform.position.x,transform.position.y+100,transform.position.z), speedY*Time.deltaTime );
		}
	}

	public void Actvate()
	{
		active = true;
		transform.position = new Vector3 (spawnerPosition.x,Height,1);	
	}

	public void Disactive()
	{
		active = false;
		transform.position = storagePosition;
	}
}
