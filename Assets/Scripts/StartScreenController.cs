using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartScreenController : MonoBehaviour
{
    private bool start = false;
	// Use this for initialization
    private Text postproces;

    public void StartAnimations()
    {
        GameObject.Find("ernesto").GetComponent<Animator>().SetTrigger("start");
        GameObject.Find("Boat").GetComponent<Animator>().SetTrigger("start");
        GameObject.Find("burd").GetComponent<Animator>().SetTrigger("start");
    }

    public void SetPostProsces()
    {
        if (GameController.postproces)
        {
            GameController.postproces = false;
            PostprocesController.singleton.SetNoPostproces();
            postproces.text = "Postproces: OFF";
        }
        else
        {
            GameController.postproces = true;
            PostprocesController.singleton.SetYesPostproces();
            postproces.text = "Postproces: ON";
        }
    }

    void Start()
    {
        postproces = gameObject.GetComponent<Text>();
    }

}
