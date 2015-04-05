using UnityEngine;
using System.Collections;

public class BikeControl : MonoBehaviour {

	public GameObject bike;
	public GameObject bikeLeft;
	public GameObject bikeRight;

	public Vector3 center;
	public Vector3 curPos;

	// Use this for initialization
	void Start () {
		center = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		curPos = transform.position;
		if (transform.position.x < center.x) {
			bike.transform.position = bikeLeft.transform.position;
		} else if (transform.position.x > center.x) {
			bike.transform.position = bikeRight.transform.position;
		}

	}

}
