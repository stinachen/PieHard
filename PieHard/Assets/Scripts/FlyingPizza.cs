using UnityEngine;
using System.Collections;

public class FlyingPizza : MonoBehaviour {

	private float timer;

	// Use this for initialization
	void Start () {
		timer = Time.time + 4f;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 temp = new Vector3 (-2, 1, 0);
		transform.Translate (temp * Time.deltaTime);
		if (Time.time > timer) {
			Destroy (gameObject);
		}
	}
}
