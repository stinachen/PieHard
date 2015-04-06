using UnityEngine;
using System.Collections;

public class ShrubSpawn : MonoBehaviour {

	public GameObject shrub;
	public GameObject bottom;

	private float usage;
	private bool set;
	private float delay; 

	// Use this for initialization
	void Start () {
		set = true;
		delay = Random.Range (2, 7);
		usage = Time.time + delay;
	}
	
	// Update is called once per frame
	void Update () {
		if (!set) {
			usage = Time.time + delay;
			set = true;
			//instantiate animal
			Instantiate(shrub);
			shrub.transform.position = transform.position;
			shrub.GetComponent<Shrub>().bottomArea = bottom;
			shrub.transform.position = transform.position;
		}
		if (Time.time > usage) {
			set = false;
		}
	}
}
