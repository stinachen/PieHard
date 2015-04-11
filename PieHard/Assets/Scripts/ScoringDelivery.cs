using UnityEngine;
using System.Collections;

public class ScoringDelivery : MonoBehaviour {

	private int pizzas;
	public GUIText txt;
	private float duration;

	public GameObject keepGO;
	private DontDestroy keep;

	// Use this for initialization
	void Start () {
		keepGO = GameObject.FindGameObjectWithTag ("dontdestroy");
		keep = keepGO.GetComponent<DontDestroy> ();
		//pizzas = 6;
		pizzas = keep.pizzas;
		duration = Time.time + 50f;
	//	print ("frames per second " + 1.0f / Time.deltaTime);
	}
	
	// Update is called once per frame
	void Update () {
		pizzas = keep.pizzas;
		//print ("keep pizzas " + keep.pizzas);
		txt.text = "Pizzas: " + keep.pizzas;
		if (Time.time > duration) {
			//print ("pizza delivered!");
			keep.pizzas--;
			keep.deliveredPizzas++;
			keep.totalScore+= 300;
			Application.LoadLevel(5);
		}
		if (keep.pizzas <= 0) {
			if(keep.deliveredPizzas < keep.lostPizzas){
				Application.LoadLevel (6);
			}
			else{
				Application.LoadLevel(7);
			}
		}
	}

	public void UpdatePizzas(){
		//print ("lost a pizza");
		keep.pizzas--;
		keep.lostPizzas++;
		keep.totalScore -= 100;
	}
}
