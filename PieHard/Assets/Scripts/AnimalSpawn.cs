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

	public bool allClear;

	public Sprite fox;
	public Sprite racoon;
	public Sprite bunny;
	public Sprite squirrel;

	// Use this for initialization
	void Start () {
		set = true;
		delay = Random.Range (5, 10);
		otherAni = otherSpawner.GetComponent<AnimalSpawn> ();
		allClear = true;
		usage = Time.time + delay;
	}
	
	// Update is called once per frame
	void Update () {
		//print (Time.time);
		checkClear ();
		if (!set && allClear) {
			usage = Time.time + delay;
			set = true;
			//instantiate animal
			Instantiate(animal);
			animal.transform.position = transform.position;
			animal.GetComponent<Animal>().bottomArea = bottom;
			animal.GetComponent<Animal>().animal =  pickAnimal();
			animal.transform.position = transform.position;
		}
		if (Time.time > usage) {
			set = false;
		}
	}

	private void checkClear(){
		if (otherAni.set) {
			if(Time.time > otherAni.usage + 4f){
				allClear = true;
				//print ("clear");
			}
			else{
				allClear = false;
				//print ("not clear");
			}
			return;
		}
		else{
			allClear = true;
		}
		return;
	}

	public Sprite pickAnimal(){
		int rand = Random.Range (0, 16);
		int that = 0;
		if (rand > 0 && rand < 4) {
			that = 0;
		} else if (rand >= 4 && rand < 8) {
			that = 1;
		} else if(rand >= 8 && rand < 12){
			that = 2;
		}
		switch (that) {
			case 0:
				return fox;
				break;
			case 1:
				return racoon;
				break;
			case 2: 
				return bunny;
				break;
			default: 
				return squirrel;
		}
		return fox;
	}
}
