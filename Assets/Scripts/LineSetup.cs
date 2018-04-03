using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineSetup : MonoBehaviour {
    LineRenderer lr;
    int positions;
    public int numberOfPositions;
    float time=0;

    float amplitudeX = 10.0f;
    float amplitudeY = 5.0f;
    float omegaX = 1.0f;
    float omegaY = 5.0f;
    float index;
    public float length;
    public float translationX;
    public float waveOffset;


    // Use this for initialization
    void Start ()
    {
        lr = this.GetComponent<LineRenderer>();
        for(int i =0; i<numberOfPositions;i++)
        {
            lr.SetPosition(i, new Vector3(i*length, Random.Range(0,5), 1));
            Renderer render = GetComponent<Renderer>();
            render.material.mainTextureScale = new Vector2(i, i);
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        /*  for (int i = 0; i < numberOfPositions; i++)
          {
              Vector3 pos = lr.GetPosition(i);
              pos.x = i * length;
              pos.x += translationX;
              pos.y = Mathf.Cos(pos.x * GameController.freq + GameController.angle) * GameController.amp;
              pos.z = 0;
              //pos = new Vector3(i * 0.8f, Mathf.Cos(i * freq + Time.time)*amp, 1);
              lr.SetPosition(i,pos);
          }
          */
        for (int i = 0; i < numberOfPositions; i++)
        {
            Vector3 pos = lr.GetPosition(i);
            pos.x = i * length;
            pos.x += translationX;
            pos.y = (Mathf.Cos(pos.x * GameController.freq + GameController.angle) * GameController.amp) + GameController.hC- GameController.waveOffset;
            pos.z = 1;
            lr.SetPosition(i, pos);
        }
    }
}
