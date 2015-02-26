using UnityEngine;
using System.Collections;

public enum ovenState{
	cooking, empty, done
}

public class oven : MonoBehaviour {

	public Animator sprite_oven;
	public ovenState cur_state;
	public ovenState next_state;

	private bool set = false;
	private float usage;
	private float delay = 4f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		switch (cur_state) {
		case ovenState.cooking:
			break;
		case ovenState.done:
			break;
		case ovenState.empty:
			break;
		}
		cur_state = next_state;
	}

	void cooking(){
		sprite_oven.SetBool ("closed", true);
		if (!set) {
			usage = Time.time + delay;
			set = true;
		}
		if (Time.time > usage) {
			set = false;
			next_state = ovenState.done;
		}
	}

	void done(){
	
	}

	void empty(){
		sprite_oven.SetBool ("closed", false);
		//nothing happens until pizza is put in
	}
}
