using UnityEngine;
using System.Collections;

public class DontDestroy : MonoBehaviour {

	public int deliveredPizzas;
	public int pizzas;

	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
	}

	// Use this for initialization
	void Start () {
		pizzas = 6;
		deliveredPizzas = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
