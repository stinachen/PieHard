using UnityEngine;
using System.Collections;


public class topping : MonoBehaviour {

	public bool onPizza = false;
	public bool inHand = false;
	public bool inOven = false;

	public GameObject pizzaTopping;
	public Vector3 toppingSpawn;

	// Use this for initialization
	void Start () {
		pizzaTopping.renderer.enabled = false;
		toppingSpawn = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (onPizza) {
			pizzaTopping.renderer.enabled = true;
			renderer.enabled = false;
		}
		if (inHand || inOven) {
			pizzaTopping.renderer.enabled = false;
			renderer.enabled = true;
			if(inOven){
				transform.position = toppingSpawn;
				inHand = false;
				inOven = false;
			}
		}
	}

	public void resetPosition(){
		transform.position = toppingSpawn;
		pizzaTopping.renderer.enabled = false;
		renderer.enabled = true;
		onPizza = false;
		inHand = false;
	}
}
