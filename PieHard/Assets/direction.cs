﻿using UnityEngine;
using System.Collections;

public class direction : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Return) || Input.GetKeyDown (KeyCode.KeypadEnter)) {
			Application.LoadLevel(2);
		}
	}
}
