using UnityEngine;
using System.Collections;

public class DontDestroy : MonoBehaviour {

	public int deliveredPizzas;
	public int lostPizzas = 0;
	public int pizzas = 6;

	private static DontDestroy instance;

	public static DontDestroy Instance{
		get{return instance;}
	}

	void Awake() {
		deliveredPizzas = 0;
		DontDestroyOnLoad(this);

		if (instance == null)
			instance = this;
		else if (instance != this) {
			Destroy(gameObject);
			return;
		}
	}

}
