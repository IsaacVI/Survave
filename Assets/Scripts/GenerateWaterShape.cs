using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateWaterShape : MonoBehaviour
{
    LineRenderer lr;
    public int width;
    public int height;
    Texture2D texture;
    public float aaa;
    Vector3 pos;
    void Start ()
    {
        // Create a new 2x2 texture ARGB32 (32 bit with alpha) and no mipmaps
        texture = new Texture2D(Screen.width, Screen.height, TextureFormat.ARGB32, true);
        lr = GameObject.Find("Wave").GetComponent<LineRenderer>();
        width = texture.width;
        height = texture.height;
        /*
        for (int i = 0; i < width; i++)
        {
            GameObject obj = GameObject.Instantiate(GameObject.Find("test"));
            obj.name = "w" + i;
            obj.transform.position=new Vector3(i,0,1);
        }
        */
        // set the pixel values
        for (int i = 0; i < 128; i++)
        {
            GameObject obj = GameObject.Instantiate(GameObject.Find("test"));
            obj.name = "w" + i;
            obj.transform.position = new Vector3(lr.GetPosition(4*i).x, lr.GetPosition(4*i).y- aaa, lr.GetPosition(4*i).z);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        /*for (int i = 0; i < width; i++)
        {
            GameObject.Find("w"+i).transform.position = new Vector3(i/100f, Mathf.Cos(i / 100f * GameController.freq + Time.time) * GameController.amp , 1);
        }
        */
        for (int i = 0; i < 128; i++)
        {
            GameObject.Find("w"+i).transform.position = new Vector3(lr.GetPosition(i*4).x, lr.GetPosition(i*4).y - aaa, lr.GetPosition(i*4).z);
        }

texture.Apply();
GetComponent<Renderer>().material.mainTexture = texture;
}
}
