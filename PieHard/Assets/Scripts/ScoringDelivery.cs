using UnityEngine;
using System.Collections;

public class ScoringDelivery : MonoBehaviour {

	public int pizzas;
	public GUIText txt;
	private float duration;

	public GameObject keepGO;
	private DontDestroy keep;

	// Use this for initialization
	void Start () {
		keepGO.GetComponent<DontDestroy> ();
		//pizzas = 6;
		duration = Time.time + 50f;
	//	print ("frames per second " + 1.0f / Time.deltaTime);
	}
	
	// Update is called once per frame
	void Update () {
		txt.text = "Pizzas: " + keep.pizzas;
		if (Time.time > duration) {
			//print ("pizza delivered!");
			keep.pizzas--;
			keep.deliveredPizzas++;
			Application.LoadLevel(4);
		}
		if (keep.pizzas <= 0) {
			print ("you failed");
		}
	}

	public void UpdatePizzas(){
		//print ("lost a pizza");
		pizzas--;
	}
}
