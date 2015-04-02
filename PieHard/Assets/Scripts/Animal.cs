using UnityEngine;
using System.Collections;

public class Animal : MonoBehaviour {

	private Vector3 spawnPoint;
	public Vector3 bottomPoint;

	private float speed;

	// Use this for initialization
	void Start () {
		spawnPoint = gameObject.transform.position;
		speed = 3f;
		bottomPoint = gameObject.transform.position;
		bottomPoint.y = -.38f;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3.Lerp (spawnPoint, bottomPoint, Time.deltaTime * speed);
	}
}
