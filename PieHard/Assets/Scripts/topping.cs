using UnityEngine;
using System.Collections;

public class topping : MonoBehaviour {

	public bool onPizza = false;
	public bool inHand = false;

	public GameObject pizzaTopping;

	// Use this for initialization
	void Start () {
		pizzaTopping.renderer.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (onPizza) {
			pizzaTopping.renderer.enabled = true;
			renderer.enabled = false;
		}
		if (inHand) {
			pizzaTopping.renderer.enabled = false;
			renderer.enabled = true;
		}
	}
}
