using UnityEngine;
using System.Collections;

public class AnimalSpawn : MonoBehaviour {

	private float usage;
	private bool set;
	private float delay; 

	public GameObject animal;
	public GameObject bottom;

	// Use this for initialization
	void Start () {
		set = false;
		delay = Random.Range (5, 7);
	}
	
	// Update is called once per frame
	void Update () {
		if (!set) {
			usage = Time.time + delay;
			set = true;
			//instantiate animal
			Instantiate(animal);
			animal.transform.position = transform.position;
			animal.GetComponent<Animal>().bottomArea = bottom;
			animal.transform.position = transform.position;
		}
		if (Time.time > usage) {
			set = false;
		}
	}
}
