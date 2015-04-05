using UnityEngine;
using System.Collections;

public class ScoringDelivery : MonoBehaviour {

	public int pizzas;
	public GUIText txt;

	// Use this for initialization
	void Start () {
		pizzas = 6;
	}
	
	// Update is called once per frame
	void Update () {
		txt.text = "Pizzas: " + pizzas;
	}

	public void UpdatePizzas(){
		print ("lost a pizza");
		pizzas--;
	}
}
