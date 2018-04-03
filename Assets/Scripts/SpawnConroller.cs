using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnConroller : MonoBehaviour {

	Vector3 spawner;
	Vector3 storage;
	public int obscaleStorageValue;
	GameObject[] obscalesTemples;
	ObscaleController[,] obscales;
	float timeToNextObscale;


	void Start () {
		spawner = transform.position;
		storage = GameObject.Find ("_Storage").transform.position;
		obscalesTemples = Resources.LoadAll<GameObject> ("Obscales");
		obscales = new ObscaleController[obscalesTemples.Length,obscaleStorageValue];
		GameObject temp;
		for (int i = 0; i < obscalesTemples.Length; i++) {
			for (int j = 0; j < obscaleStorageValue; j++) {
				temp = Instantiate(obscalesTemples[i],storage,new Quaternion()) as GameObject;
				obscales[i,j] = temp.GetComponent<ObscaleController>();
				obscales [i, j].spawnerPosition = spawner;
				obscales [i, j].storagePosition = storage;
			}
		}
	}
	

	void Update () {
		if (timeToNextObscale < 0) {
			bool noSawned =true;
			int type;
			do {
				type = Random.Range(0,obscalesTemples.Length);
				for(int i=0;i<obscaleStorageValue;i++)
				{
					if(!obscales[type,i].active)
					{
						float x =obscales[type,i].minSize*Mathf.Pow(Random.Range(1000,Mathf.Sqrt(obscales[type,i].maxMuliplerSize)*1000)/1000f,2);
						obscales[type,i].gameObject.transform.localScale = new Vector3 (x,x,x);
						obscales[type,i].gameObject.transform.rotation = Quaternion.AngleAxis((Random.Range(-1000,1000)/1000f)*obscales[type,i].maxRotate , Vector3.forward);
					    if (obscales[type, i].randomHeight)
					        obscales[type, i].Height = Random.Range(obscales[type, i].minHeight* 1000, obscales[type, i].maxHeight*1000)/1000f;

                        obscales[type,i].Actvate();
                       
						noSawned =false;
						break;
					}
				}
			} while(noSawned);

			timeToNextObscale=Random.Range (400,1500)/1000f;
		}
		timeToNextObscale -= Time.deltaTime;
	}
}
