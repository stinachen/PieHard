using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Scoring : MonoBehaviour {

	public int pizzasLeft = 5;
	public int curScore = 0;

	public GUIText score;
	public GUIText pizzas;

	public List<bool> wantedToppings;

	public GameObject[] toppingObjs;

	// Use this for initialization
	void Start () {
		toppingObjs = GameObject.FindGameObjectsWithTag ("topping");
		for(int i = 0; i < toppingObjs.Length; i++){
			wantedToppings.Add (false);
		}
		score.text = "Score: " + score;
		pizzas.text = "Pizzas Left: " + pizzasLeft;
	}
	
	// Update is called once per frame
	void Update () {
		score.text = "Score: " + curScore;
		pizzas.text = "Pizzas Left: " + pizzasLeft;
	}

	public void scoreUpdate(){
		bool perfect = true;
		for(int i = 0; i < toppingObjs.Length; i++){
			if(toppingObjs[i].GetComponent<topping>().onPizza != wantedToppings[i]){
				perfect = false;
				curScore--;
			}
		}
		if (perfect) {
			pizzasLeft--;
			curScore += 3;
		}


	}
}
