using UnityEngine;
using System.Collections;


public class DontDestroy : MonoBehaviour {

	public int deliveredPizzas;
	public int lostPizzas = 0;
	public int pizzas = 6;

	/* D I F F I C U L T Y  L E V E L S */
	// EASY: 0
	// MEDIUM: 1
	// HARD: 2
	public int cognitiveMode = 0;
	public int physicalMode = 0;

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
