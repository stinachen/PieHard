using UnityEngine;
using System.Collections;
using Kinect;
using System.Collections.Generic;

public enum State{
	empty, hold_topping, hold_pizza, phone
}

public class cursor : MonoBehaviour {

	private bool set = false;
	private float usage;
	private float delay = 2f;

	private bool pizzaSet = false;
	private float pizzaUsage;

	private bool phoneSet = false;
	private float phoneUsage;

	private bool ovenSet = false;
	private float ovenUsage;

	//public GameObject topping;

	public GameObject pizza;
	public GameObject oven;
	public GameObject phone;
	public GameObject[] toppings; //doesn't work as of now

	private List<bool> sets;
	private List<float> usages;


	public State cur_state = State.empty;
	public State next_state; 

	public GameObject cur_topping;




	// Use this for initialization
	void Start () {
		sets = new List<bool> ();
		usages = new List<float> ();
		toppings = GameObject.FindGameObjectsWithTag ("topping");
		for (int i = 0; i < toppings.Length; i++) {
			sets.Add(false);
			usages.Add(0f);
		}
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
		int i = 0;
		foreach (GameObject topping in toppings) {
			topping top = topping.GetComponent<topping> ();
			if (!top.onPizza) {
				float xDist_top = Mathf.Abs (gameObject.transform.position.x - topping.transform.position.x);
				float yDist_top = Mathf.Abs (gameObject.transform.position.y - topping.transform.position.y);
				//float dist = Vector3.Distance(gameObject.transform.position, topping.transform.position);
				if (xDist_top < .15f && yDist_top < .15f) {
					print ("on topping");
					//hover over topping to grab
					if (!sets[i]) {
						print ("set time for " + topping.name);
						usages[i] = Time.time + delay;
						sets[i] = true;
					}
					if (Time.time > usage) { //successfully grabbed topping
						sets[i] = false;
						cur_topping = topping;
						next_state = State.hold_topping;
						print ("grabbed it");
						return;
					}
				} else { //you exited topping before grabbing
					print ("exited topping");
					sets[i] = false;
					next_state = State.empty;
				}
			}
			i++;
		}
		//pizza
		float xDist_pizza = Mathf.Abs (gameObject.transform.position.x - pizza.transform.position.x);
		float yDist_pizza = Mathf.Abs (gameObject.transform.position.y - pizza.transform.position.y);	//float pizzaDist = Vector3.Distance (gameObject.transform.position, pizza.transform.position);
		//print ("pizza distance " + pizzaDist);
		if (xDist_pizza < .15f && yDist_pizza < .15f) {
			print ("on pizza");
			if(!pizzaSet){
				print ("set time for pizza");
				pizzaUsage = Time.time + delay;
				pizzaSet = true;
			}
			if(Time.time > pizzaUsage){
				pizzaSet = false;
				next_state = State.hold_pizza;
				print ("grabbed pizza");
				return;
			}
		}
		else{
			print ("exited pizza");
			pizzaSet = false;
			next_state = State.empty;
		}
		
		//phone
		float xDist_phone = Mathf.Abs (gameObject.transform.position.x - phone.transform.position.x);
		float yDist_phone = Mathf.Abs (gameObject.transform.position.y - phone.transform.position.y);
		if (xDist_phone < .15f && yDist_phone < .15f) {
			print ("on phone");
			if(!phoneSet){
				print ("set time for phone");
				phoneUsage = Time.time + delay;
				phoneSet = true;
			}
			if(Time.time > phoneUsage){
				print ("phone answered");
				phoneSet = false;
				next_state = State.empty;
				phone talk = phone.GetComponent<phone>();
				talk.next_state = PhoneState.busy;
				next_state = State.empty;
				return;
			}
		}
		else{
			next_state = State.empty;
			phoneSet = false;
		}
	}

	//Topping follows hand. Release if you throw away topping or hover over pizza
	void hold_topping(){
		//topping follows hand
		cur_topping.gameObject.transform.position = gameObject.transform.position;
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
				topping top = cur_topping.GetComponent<topping>();
				top.onPizza = true;
			}
		}
		else {
			set = false;
			next_state = State.hold_topping;
		}
	}

	void hold_pizza(){
		print ("holding pizza");
		pizza.gameObject.transform.position = gameObject.transform.position;
		//let go over oven
		float xDist_oven = Mathf.Abs (gameObject.transform.position.x - oven.transform.position.x);
		float yDist_oven = Mathf.Abs (gameObject.transform.position.y - oven.transform.position.y);
		if (xDist_oven < .15f && yDist_oven < .15f) {
			print ("on oven");
			if(!ovenSet){
				ovenUsage = Time.time + delay;
				ovenSet = true;
			}
			if(Time.time > usage){
				ovenSet = false;
				oven cook = oven.GetComponent<oven>();
				cook.next_state = ovenState.cooking;
				next_state = State.empty;
			}
		}
	}
}
