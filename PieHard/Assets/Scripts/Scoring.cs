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
	public GameObject dontDestroy;

	private DontDestroy information;

	// Use this for initialization
	void Start () {
		for(int i = 0; i < toppingObjs.Length; i++){
			wantedToppings.Add (false);
		}
		score.text = "Score: " + score;
		pizzas.text = "Pizzas Left: " + pizzasLeft;

		information = dontDestroy.GetComponent<DontDestroy>();
	}
	
	// Update is called once per frame
	void Update () {
		score.text = "Score: " + curScore;
		pizzas.text = "Pizzas Left: " + pizzasLeft;
		if (pizzasLeft == 0) {
			Application.LoadLevel(3);
		}
	}

	public void scoreUpdate(){
		bool perfect = true;
		print ("topping length " + toppingObjs.Length);
		for(int i = 0; i < toppingObjs.Length; i++){
			print ("wanted toppings" + wantedToppings[i] + " onPizza " + toppingObjs[i].GetComponent<topping>().onPizza);
			if(toppingObjs[i].GetComponent<topping>().onPizza != wantedToppings[i]){
				perfect = false;
				curScore-= 100;
				print ("bad pizza");
				break;
			}
		}
		if (perfect){
			//print ("perfect pizza");
			pizzasLeft--;
			curScore += 300;
		}
		information.totalScore = curScore;

	}
}
