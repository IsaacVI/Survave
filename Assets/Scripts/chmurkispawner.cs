using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chmurkispawner : MonoBehaviour
{
    private Vector3 spawner, storage;
    private GameObject[] obscalesTemples;
    private ObscaleController[,] obscales;
    public int obscaleStorageValue;
    public float timeToNextObscale;

    // Use this for initialization
    void Start () {
        spawner = transform.position;
        storage = GameObject.Find("_Storage").transform.position;
        obscalesTemples = Resources.LoadAll<GameObject>("Clouds");
        obscales = new ObscaleController[obscalesTemples.Length, obscaleStorageValue];
        GameObject temp;
        for (int i = 0; i < obscalesTemples.Length; i++)
        {
            for (int j = 0; j < obscaleStorageValue; j++)
            {
                temp = Instantiate(obscalesTemples[i], storage, new Quaternion()) as GameObject;
                obscales[i, j] = temp.GetComponent<ObscaleController>();
                obscales[i, j].spawnerPosition = spawner;
                obscales[i, j].storagePosition = storage;
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (timeToNextObscale < 0)
        {
            bool noSawned = true;
            int type;
            do
            {
                type = Random.Range(0, obscalesTemples.Length);
                for (int i = 0; i < obscaleStorageValue; i++)
                {
                    if (!obscales[type, i].active)
                    {
                        obscales[type, i].Height = Random.Range(1500,2000)/1000f;
                        obscales[type, i].Actvate();
                        
                        noSawned = false;
                        break;
                    }
                }
            } while (noSawned);

            timeToNextObscale = Random.Range(1000, 3000) / 1000f;
        }
        timeToNextObscale -= Time.deltaTime;
    }
}
