using UnityEngine;
using System.Collections;

public enum PhoneState{
	ringing, silent
}

public class phone : MonoBehaviour {

	public float start_time;
	private float delay = 4;

	public PhoneState cur_state;
	public PhoneState next_state;


	// Use this for initialization
	void Start () {
		cur_state = PhoneState.silent;
		start_time = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		switch (cur_state) {
			case PhoneState.ringing:
				ringing();
				break;
			case PhoneState.silent:
				silent();
				break;
		}

		cur_state = next_state;
	}

	void ringing(){
		delay = Random.Range (8, 20);
		//once you pick up the phone, the state changes to silent
	}

	void silent(){
		if (Time.time > start_time + delay) {
			next_state = PhoneState.ringing;
		}
	}
}
