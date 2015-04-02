using UnityEngine;
using System.Collections;

public enum ovenState{
	cooking, empty, done
}

public class oven : MonoBehaviour {

	public Animator sprite_oven;
	public ovenState cur_state;
	public ovenState next_state;
	public GameObject pizza;
	public GameObject[] toppings;

	private bool set = false;
	private float usage;
	private float delay = 4f;

	public GameObject pizzaSpawner;
	private Vector3 pizzaSpawn;

	private Scoring scoreSystem;

	// Use this for initialization
	void Start () {
		cur_state = ovenState.empty;
		pizzaSpawn = pizza.gameObject.transform.position;
		scoreSystem = GameObject.FindGameObjectWithTag ("scoring").GetComponent<Scoring>();
	}
	
	// Update is called once per frame
	void Update () {
		switch (cur_state) {
		case ovenState.cooking:
			cooking();
			break;
		case ovenState.done:
			done ();
			break;
		case ovenState.empty:
			empty();
			break;
		}
		cur_state = next_state;
	}

	void cooking(){
		print ("cooking");
		sprite_oven.SetBool ("closed", true);
		if (!set) {
			usage = Time.time + delay;
			set = true;
			//put a blank pizza, reset toppings
			pizza.gameObject.transform.position = pizzaSpawn;
			print("number of pizza children " + pizza.transform.childCount);
			pizza.gameObject.renderer.enabled = true;
			scoreSystem.scoreUpdate();
			for(int i = 0; i < scoreSystem.wantedToppings.Count; i++){
				scoreSystem.wantedToppings[i] = false;
			}
		}
		if (Time.time > usage) {
			set = false;
			next_state = ovenState.done;
		}
	}

	void done(){
		sprite_oven.SetBool ("closed", false);
		//pizza.SetActive (true);
		//has pizza inside, changes state by cursor
	}

	void empty(){
		sprite_oven.SetBool ("closed", false);
		//nothing happens until pizza is put in
	}
}
