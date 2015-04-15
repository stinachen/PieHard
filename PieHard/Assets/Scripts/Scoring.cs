using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Scoring : MonoBehaviour {

	public int pizzasLeft;
	public int curScore = 0;

	public GUIText score;
	public GUIText pizzas;

	public List<bool> wantedToppings;

	public GameObject[] toppingObjs;

	private DontDestroy information;

	// Use this for initialization
	void Start () {
<<<<<<< HEAD
//		toppingObjs = GameObject.FindGameObjectWithTag ("topping");
=======
		//dontDestroy = GameObject.FindGameObjectWithTag ("dontdestroy");
>>>>>>> 6606584a2ffe113815a6e31d52602730898789fa
		for(int i = 0; i < toppingObjs.Length; i++){
			wantedToppings.Add (false);
		}
		score.text = "Score: " + score;
		pizzas.text = "Pizzas Left: " + pizzasLeft;

		information = GameObject.FindGameObjectWithTag("dontdestroy").GetComponent<DontDestroy>();
		pizzasLeft = information.pizzas;
<<<<<<< HEAD
		print (information.rightHand);
		print ("right hand or not " + information.rightHand);
=======

>>>>>>> 6606584a2ffe113815a6e31d52602730898789fa
		if (information.rightHand) {
			GameObject.FindGameObjectWithTag("rightHand").SetActive(true);
			GameObject.FindGameObjectWithTag("leftHand").SetActive(false);
		}
		else{
			GameObject.FindGameObjectWithTag("rightHand").SetActive(false);
			GameObject.FindGameObjectWithTag("leftHand").SetActive(true);
		}
	}
	
	// Update is called once per frame
	void Update () {
		score.text = "Score: " + curScore;
		pizzas.text = "Pizzas Left: " + pizzasLeft;
		if (pizzasLeft == 0) {
			Application.LoadLevel(4);
		}
	}

	public void scoreUpdate(){
		bool perfect = true;
		int cheese = 0;
		print ("topping length " + toppingObjs.Length);
		for(int i = 0; i < toppingObjs.Length; i++){
			if(toppingObjs[i].GetComponent<topping>().onPizza == false){
				cheese++;
			}
			print ("wanted toppings" + wantedToppings[i] + " onPizza " + toppingObjs[i].GetComponent<topping>().onPizza);
			if(toppingObjs[i].GetComponent<topping>().onPizza != wantedToppings[i]){
				perfect = false;
				curScore-= 100;
				print ("bad pizza");
				gameObject.GetComponents<AudioSource>()[1].Play();
				break;
			}
		}
		if (cheese == 4) {
			perfect = false;
		}
		if (perfect){
			//print ("perfect pizza");
			pizzasLeft--;
			curScore += 300;
			gameObject.GetComponents<AudioSource>()[0].Play();
		}
		information.totalScore = curScore;

	}
}
