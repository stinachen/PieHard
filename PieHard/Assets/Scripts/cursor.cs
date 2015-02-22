﻿using UnityEngine;
using System.Collections;
using Kinect;

public enum State{
	empty, hold_topping, hold_pizza, phone
}

public class cursor : MonoBehaviour {

	private bool set = false;
	private float usage;
	private float delay = 2f;

	private GameObject RightHand;
	public GameObject topping;
	public GameObject pizza;

	public State cur_state = State.empty;
	public State next_state; 

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		switch (cur_state) {
			case(State.empty):
				empty ();
				break;
			case(State.hold_topping):
				hold_topping();
				break;
			case(State.hold_pizza):
				break;
			case(State.phone):
				break;
		}
		cur_state = next_state;
	}

	//nothing in hand. Hover over topping or pizza to change state.
	void empty(){
		float xDist_top = Mathf.Abs (gameObject.transform.position.x - topping.transform.position.x);
		float yDist_top = Mathf.Abs (gameObject.transform.position.y - topping.transform.position.y);
		if (xDist_top < .15f && yDist_top < .15f) {
			print ("on topping");
			//hover over topping to grab
			if (!set) {
				usage = Time.time + delay;
				set = true;
			}
			if (Time.time > usage) { //successfully grabbed topping
				set = false;
				next_state = State.hold_topping;
			}
		}
		else{ //you exited topping before grabbing
			set = false;
			next_state = State.empty;
		}
	}

	//Topping follows hand. Release if you throw away topping or hover over pizza
	void hold_topping(){
		//topping follows hand
		topping.gameObject.transform.position = gameObject.transform.position;
		float xDist_pizza = Mathf.Abs (gameObject.transform.position.x - pizza.transform.position.x);
		float yDist_pizza = Mathf.Abs (gameObject.transform.position.y - pizza.transform.position.y);
		if (xDist_pizza < .15f && yDist_pizza < .15f) {
			print ("on pizza");
			if (!set) {
				usage = Time.time + delay;
				set = true;
			}
			if (Time.time > usage) { //time has lapsed so drop topping on pizza
				set = false;
				next_state = State.empty;
			}
		}
		else {
			set = false;
			next_state = State.hold_topping;
		}
	}
}