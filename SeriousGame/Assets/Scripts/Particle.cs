﻿using UnityEngine;
using System.Collections;

public class Particle : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    GameObject.Find("Cessna172/particle").GetComponent<ParticleSystem>().Emit(10);
	}
}
