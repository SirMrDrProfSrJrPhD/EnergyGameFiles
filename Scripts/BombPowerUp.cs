﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombPowerUp : MonoBehaviour {
	public GameObject BombCharge;
	public bool BombFullyCharged;
	float XScale = 5f;
	float YScale = 5f;
	float DecayRate = .0065f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
			
		if (BombCharge.transform.localScale.x >= 1) {
			XScale -= DecayRate;
			YScale -= DecayRate;
			BombCharge.transform.localScale = new Vector3 (XScale, YScale, 0f);
		} else {
			BombFullyCharged = true;
		}
	}
	void OnTriggerStay2D(Collider2D other){
		print ("entered");
		if (BombFullyCharged == true){
			if (other.gameObject.name == "BlueRobot") {
				BuildABomb.BlueExplosivePower += 1f;
				gameObject.GetComponent<AudioSource> ().Play ();
				Destroy (gameObject);
			}
			if (other.gameObject.name == "RedRobot") {
				BuildABomb.RedExplosivePower += 1f;
				gameObject.GetComponent<AudioSource> ().Play ();
				Destroy (gameObject);
			}
		}
	}
}
