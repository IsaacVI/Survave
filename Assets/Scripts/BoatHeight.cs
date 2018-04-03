using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatHeight : MonoBehaviour {
    LineRenderer lr;
    public int index;
    public Vector3 vector1;
    public Vector3 vector2;
    Vector3 target;
    public Vector3 vector3;
    public Vector3 test;
    GameObject sprite;
    public float tempRot;
    public float tempPiMod;
    // Use this for initialization
    void Start ()
    {
        lr = GameObject.Find("Wave").GetComponent<LineRenderer>();
        sprite = GameObject.Find("boat");
	}
	
	// Update is called once per frame
	void Update ()
    {
        /*target = new Vector3((gameObject.transform.position.x+0.01f) + 0.1f, Mathf.Cos((gameObject.transform.position.x+0.01f) + 0.1f * GameController.freq + GameController.angle) * GameController.amp, 1);
		this.transform.position=new Vector3(gameObject.transform.position.x, Mathf.Cos(gameObject.transform.position.x * GameController.freq + GameController.angle) * GameController.amp, 1);

        vector1 = this.transform.position;
		vector2 = new Vector3(gameObject.transform.position.x+0.1f, Mathf.Cos(gameObject.transform.position.x + 0.1f * GameController.freq + GameController.angle) * GameController.amp, 1);
        vector3 = vector2 - vector1;
        vector3.Normalize();
        */
        //            pos.y = (Mathf.Cos(pos.x * GameController.freq + GameController.angle) * GameController.amp) + GameController.hC- GameController.waveOffset;
        this.transform.position = new Vector3(gameObject.transform.position.x, (Mathf.Cos(gameObject.transform.position.x * GameController.freq + GameController.angle) * GameController.amp) + GameController.hC- GameController.waveOffset, 1);
        test = new Vector3(gameObject.transform.position.x+1f, (Mathf.Cos((gameObject.transform.position.x+1f) * GameController.freq + GameController.angle) * GameController.amp) + GameController.hC - GameController.waveOffset, 1);
        vector1 = this.transform.position;
        vector2 = new Vector3(gameObject.transform.position.x + 1f, Mathf.Cos(this.transform.position.x * GameController.freq + GameController.angle * GameController.amp) + GameController.hC - GameController.waveOffset, 1);
        vector3 = test - vector1;
        vector3.Normalize();
        float rotation = Mathf.Atan2(vector3.y, vector3.x);
        Vector3 dir = target - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + tempRot;
        transform.rotation = Quaternion.FromToRotation(Vector3.right, vector3);
        //transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        //float rotation = Mathf.Acos((Mathf.Cos((gameObject.transform.position.y+Mathf.PI*tempPiMod)/4)));
        //sprite.transform.rotation = Quaternion.AngleAxis( (rotation*Mathf.Rad2Deg + tempRot)*4,Vector3.forward);

        //float rotation = Mathf.Atan2(vector3.y, vector3.x);
        //Vector3 dir = target - transform.position;
        //float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg+tempRot;
        //transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        //float rotation = Mathf.Asin(Mathf.Abs((Mathf.Cos((gameObject.transform.position.x+GameController.angle/2+Mathf.PI)))));
        //sprite.transform.rotation = Quaternion.AngleAxis( (rotation*Mathf.Rad2Deg),Vector3.forward);
    }
}
