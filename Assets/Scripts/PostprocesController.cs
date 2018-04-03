using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;
using System;

public class PostprocesController : MonoBehaviour {

    public VignetteAndChromaticAberration vaca;
    public SunShafts ss;
    public MotionBlur MB;
    public static PostprocesController singleton;

  public   void SetNoPostproces()
    {
        
        vaca.enabled = false;
        ss.enabled = false;
        MB.enabled = false;
   }

   public  void SetYesPostproces()
    {
       
        vaca.enabled = true;
        ss.enabled = true;
        MB.enabled = true;
    }

    // Use this for initialization
    void Start ()
    {
        singleton = this;
        vaca = this.GetComponentInChildren<VignetteAndChromaticAberration>();
        ss = this.GetComponentInChildren<SunShafts>();
        MB = this.GetComponentInChildren<MotionBlur>();
        if(GameController.postproces)
            SetYesPostproces();
        else
        {
            SetNoPostproces();
        }

    }

    // Update is called once per frame
    void Update () {
		
	}
}
