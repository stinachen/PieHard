using UnityEngine;
using System.Collections;

public class BikeCollider : MonoBehaviour {

	private bool rend;
	public GameObject pizza;

	// Use this for initialization
	void Start () {
		rend = true;
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "animal") {
			print ("lose pizza");
			//throw pizza
			Instantiate(pizza);
			pizza.transform.position = transform.position;
		}
	}

}
