using UnityEngine;
using System.Collections;

public class House : MonoBehaviour {

	private float duration;

	// Use this for initialization
	void Start () {
		duration = Time.time + 5f;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > duration) {
			Application.LoadLevel (3);
		}
	}
}
