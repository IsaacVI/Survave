using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour
{
    private bool dead = false;
	PolygonCollider2D PolColl;
	public Animator explosionAnimator;
    private float timer;
    public static bool isDead;

	// Use this for initialization
	void Start () {
		PolColl = this.gameObject.GetComponent<PolygonCollider2D> ();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (dead)
        {
            timer += Time.deltaTime;
            if (timer > 5)
            {
                Application.LoadLevel("game");
            }
        }
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "obscale") {
			explosionAnimator.SetTrigger ("Bum");
			PolColl.enabled = false;
			ScoreController.StopGrowing ();
            GetComponentInChildren<AudioSource>().Play();
		    dead = true;
            isDead = true;
		    if (ScoreController.bestScore < (int) ScoreController.score)
		    {
                PlayerPrefs.SetInt("BestScore", (int)ScoreController.score);
		    }

		}
	}
}
