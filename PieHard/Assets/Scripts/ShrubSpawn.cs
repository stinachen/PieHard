using UnityEngine;
using System.Collections;

public class ShrubSpawn : MonoBehaviour {

	public GameObject shrub;
	public GameObject bottom;

	private float usage;
	private bool set;
	private float delay; 

	public Sprite round;
	public Sprite square;
	public Sprite rock;

	// Use this for initialization
	void Start () {
		set = true;
		delay = Random.Range (4, 7);
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
			shrub.GetComponent<Shrub>().pic = picSprite();
			shrub.transform.position = transform.position;
		}
		if (Time.time > usage) {
			set = false;
		}
	}

	Sprite picSprite(){
		int rand = Random.Range (0, 9);
		int that;
		if (rand > 0 && rand < 3) {
			that = 0;
		} else if (rand >= 3 && rand < 6) {
			that = 1;
		} else {
			that = 2;
		}
		switch (that) {
		case 0:
			return round;
			break;
		case 1:
			return square;
			break;
		default:
			return rock;
		}
	}
}
