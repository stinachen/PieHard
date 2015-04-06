using UnityEngine;
using System.Collections;

public class AnimalSpawn : MonoBehaviour {

	public float usage;
	public bool set;
	private float delay; 

	public GameObject animal;
	public GameObject bottom;

	public GameObject otherSpawner;
	private AnimalSpawn otherAni;

	private bool allClear;
	

	// Use this for initialization
	void Start () {
		set = false;
		delay = Random.Range (9, 12);
		otherAni = otherSpawner.GetComponent<AnimalSpawn> ();
		allClear = true;
	}
	
	// Update is called once per frame
	void Update () {
		checkClear ();
		if (!set && allClear) {
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

	private void checkClear(){
		if (otherAni.set) {
			if(Time.time > otherAni.delay + 8f){
				allClear = true;
				print ("clear");
			}
			else{
				allClear = false;
				print ("not clear");
			}
			return;
		}
		return;
	}
}
