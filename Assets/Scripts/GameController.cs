using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;

public class GameController : MonoBehaviour {

    public static float amp;
    public static float freq;
	public static float angle;
    public static float hC;

    public float speed;
    public float ampTemp;
    public float freqTemp;

    public static bool postproces;

    public float input;
    public float heightChange;
    public float inputPower;
    public float inputTresholdUp;
    public float inputTresholdDown;
    private GameObject player;
    public float playerSpeed;
    private bool direction;
    public float leftBound;
    public float rightBound;
    private float minMapX;
    private float minMapY;
    private float maxMapX;
    private float maxMapY;
    public float offsetMinMapX;
    public float offsetMaxMapX;
    public static float waveOffset;
    public float wo;
    public float waterLevel;
   

    

  

    // Use this for initialization
    void Start ()
    {
        waveOffset = wo;
        amp = ampTemp;
        freq = freqTemp;
                player = GameObject.Find("Player");
        direction = true;
        Ray ray = new Ray();
        RaycastHit raycastHit = new RaycastHit();
        ray = Camera.main.ScreenPointToRay(new Vector2(0, 0));
        if (Physics.Raycast(ray, out raycastHit, Mathf.Infinity, 1 << 8))
        {
            minMapX = raycastHit.point.x;
            minMapY = raycastHit.point.y;
        }
        ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width, Screen.height));
        if (Physics.Raycast(ray, out raycastHit, Mathf.Infinity, 1 << 8))
        {
            maxMapX = raycastHit.point.x;
            maxMapY = raycastHit.point.y;
        }

    }

    void LastUpade()
    {
        Vector3 previosuPosition = player.transform.position;
        previosuPosition.x= Mathf.Clamp(previosuPosition.x, 0, 100);
        player.transform.position = previosuPosition;
    }
	// Update is called once per frame
	void Update ()
	{
        amp = ampTemp*PhoneController.waveAplitude;
        freq = freqTemp;

        if (direction)
        {
            input += inputPower;
            heightChange += inputPower;
            if (input > inputTresholdUp)
            {
                input = inputTresholdUp;
                direction = false;
            }
        }
        else
        {
            input -= inputPower;
            heightChange -= inputPower;
            if (input < inputTresholdDown)
            {
                input = inputTresholdDown;
                direction = true;
            }
        }
	    hC = heightChange+waterLevel;




        angle += Time.deltaTime * speed;
        /* amp = ampTemp*PhoneController.waveAplitude;
         //angle += PhoneController.waveHorizontalSpeed * Time.deltaTime*speed;

         if (angle > 2 * Mathf.PI)
             angle -= 2 * Mathf.PI;
             */
        player.transform.Translate(PhoneController.waveHorizontalSpeed/10f, 0, 0);

	    if (player.transform.position.x < minMapX + offsetMinMapX)

        {
            player.transform.position = new Vector3(minMapX + offsetMinMapX, player.transform.position.y, player.transform.position.z);

        }

        if (player.transform.position.x > maxMapX - offsetMaxMapX)
        {
            player.transform.position = new Vector3(maxMapX - offsetMaxMapX, player.transform.position.y, player.transform.position.z);

        }



        if (Input.GetKeyDown("escape"))
        {
            Application.Quit();
        }
	}
}
