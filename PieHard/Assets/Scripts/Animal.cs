using UnityEngine;
using System.Collections;

public class Animal : MonoBehaviour {

	private Vector3 spawnPoint;
	private Vector3 bottomPoint;
	public GameObject bottomArea;
	public bool onScreen;

	private float speed;
	private float lerpTime = 1f;
	private float curLerpTime;

	private ScoringDelivery scoreSystem;

	public Sprite animal;
	public Sprite pizza;

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<SpriteRenderer> ().sprite = animal;
		scoreSystem = GameObject.FindGameObjectWithTag ("scoring").GetComponent<ScoringDelivery>();
		spawnPoint = gameObject.transform.position;
		speed = Random.Range (.1f,.4f);
		curLerpTime = 0;
		bottomPoint = bottomArea.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (bottomArea == null) {
			print ("null bottompos");
			Destroy (gameObject);
		}
		curLerpTime += Time.deltaTime * speed;
		if (curLerpTime > lerpTime) {
			curLerpTime = lerpTime;

			Destroy (gameObject);
		}

		float perc = curLerpTime / lerpTime;
		transform.position = Vector3.Lerp (spawnPoint, bottomPoint, perc);
		transform.localScale += new Vector3(0.0008F, 0.0008f, 0);
	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Player") {
			//print ("hit!");
			scoreSystem.UpdatePizzas();
		}
	}
}
