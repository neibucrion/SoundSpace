﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoueNote : MonoBehaviour {

	public GameObject controller;
	public AudioSource note;
	public float centre = 1.5f;
	public float distorsion = 1f;

	private bool joue = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("TriggerLeft")) {
			joue = true;
			note.Play ();
		} else if (Input.GetButtonUp ("TriggerLeft")) {
			joue = false;
			note.Stop();
		}

		if (joue) {
			float posY = controller.transform.position.y;
			float distance = posY - centre;
			note.pitch = 1f+(distance*distorsion);
			note.pitch = Mathf.Clamp (note.pitch, 0f, 3f);
		}
	}
}
