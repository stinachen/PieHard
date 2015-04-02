using UnityEngine;
using System.Collections;

public enum PhoneState{
	ringing, silent, busy
}
/* TOPPINGS FOR ORDERS */
/* Easy: 0-3
   Medium: 0-7
   Hard: 0-11
 */
public enum Toppings {
	Pepperoni, Pepper, Bacon, Sausage, 
	Ham, Pineapple, Olive, Chicken,
	Jalapeno, Mushroom, Onion, Tomato
};

public class phone : MonoBehaviour {

	public float start_time;
	private float delay = 4;
	
	public PhoneState cur_state;
	public PhoneState next_state;

	public GameObject orderBubble;
	/* E A S Y  T O P P I N G S */
	public GameObject one;
	public GameObject two;
	public GameObject three;
	public GameObject four;

	public GameObject plus1;
	public GameObject plus2;
	public GameObject plus3;

	public Sprite pepperoniSprite;
	public Sprite pepperSprite;
	public Sprite baconSprite;
	public Sprite sausageSprite;

	/* S P R I T E S */
	public Sprite silentPhone;
	public Sprite ringingPhone;
	private SpriteRenderer phoneRenderer;
	
	public Animator sprite_phone;

	private bool timerSet = false;
	private float timerDelay = 4f;
	private float timerUsage;

	private int numToppings;

	private Scoring scoreSystem;
	
	// Use this for initialization
	void Start () {
		/* I N I T I A L  S P R I T E */
		
		/*phoneRenderer = GetComponent<SpriteRenderer>();
		if (phoneRenderer.sprite = null)
			phoneRenderer.sprite = silentPhone;
		*/
		
		scoreSystem = GameObject.FindGameObjectWithTag ("scoring").GetComponent<Scoring>();

		/* P H O N E  S T A T E */  
		cur_state = PhoneState.silent;
		next_state = PhoneState.silent;
		start_time = Time.time;
		orderBubble.renderer.enabled = false;

		/* T O P P I N G S */
		one.renderer.enabled = false;
		two.renderer.enabled = false;
		three.renderer.enabled = false;
		four.renderer.enabled = false;

		plus1.renderer.enabled = false;
		plus2.renderer.enabled = false;
		plus3.renderer.enabled = false;

		numToppings = 0;
	}

	// Update is called once per frame
	void Update () {
		switch (cur_state) {
			case PhoneState.ringing:
				//changeSprite();
				ringing();
				break;
			case PhoneState.silent:
				//changeSprite();
				silent();
				break;
			case PhoneState.busy:
				sprite_phone.SetBool("ringing", false);
				//changeSprite();
				takeOrders();
				break;
		}
		
		cur_state = next_state;
	}
	
	void ringing(){
		delay = Random.Range(8, 10);	
		sprite_phone.SetBool("ringing", true);
		one.renderer.enabled = false;
	}
	
	void silent(){
		one.renderer.enabled = false;
		sprite_phone.SetBool ("ringing", false);
		if (Time.time > start_time + delay) {
			print ("switch");
			next_state = PhoneState.ringing;
		}
	}
	/* P H O N E  O R D E R S */
	// RANDOMLY GENERATES NUMBER OF TOPPINGS ON PIZZA
	// EACH TOPPING IS ALSO RANDOMLY GENERATED
	void takeOrders() {
		if (!timerSet) {
			timerSet = true;
			timerUsage = Time.time + timerDelay;
			orderBubble.renderer.enabled = true;
			//pick a number of toppings
			int topping1 = -1;
			int topping2 = -1;
			int topping3 = -1;
			int topping4 = -1;
			numToppings = Random.Range(1, 5);
			if(numToppings >= 1){
				topping1 = Random.Range (0, 4);
				two.GetComponent<SpriteRenderer>().sprite = spritePicker(topping1);
				two.renderer.enabled = true;
			}
			if(numToppings >= 2){
				topping2 = topping1;
				while(topping2 == topping1){
					topping2 = Random.Range (0, 4);
				}
				three.GetComponent<SpriteRenderer>().sprite = spritePicker(topping2);
				three.renderer.enabled = true;
				plus2.renderer.enabled = true;
			}
			if(numToppings >= 3){
				topping3 = topping2;
				while(topping3 == topping1 || topping3 == topping2){
					topping3 = Random.Range (0, 4);
				}
				one.GetComponent<SpriteRenderer>().sprite = spritePicker(topping3);
				one.renderer.enabled = true;
				plus1.renderer.enabled = true;
			}
			if(numToppings >= 4){
				topping4 = topping3;
				while(topping4 == topping1 || topping4 == topping2 || topping4 == topping3){
					topping4 = Random.Range (0, 4);
				}
				four.GetComponent<SpriteRenderer>().sprite = spritePicker(topping4);
				four.renderer.enabled = true;
				plus3.renderer.enabled = true;
			}

		}
		if (Time.time > timerUsage) {
			timerSet = false;
			orderBubble.renderer.enabled = false;
			one.renderer.enabled = false;
			two.renderer.enabled = false;
			three.renderer.enabled = false;
			four.renderer.enabled = false;
			plus1.renderer.enabled = false;
			plus2.renderer.enabled = false;
			plus3.renderer.enabled = false;
			next_state = PhoneState.silent;
			start_time = Time.time;
		}


		//to implement later when we has more toppingz
		/*int numItems = Random.Range(1,4);
		int chosenTopping = 0;
		GameObject toppings = new GameObject();
		toppings.AddComponent<SpriteRenderer>();

		for (int i = 0; i < numItems; i++) {
			chosenTopping = Random.Range(0, 3);
			if (chosenTopping == Toppings.Pepperoni)
				pepperoni.renderer.enabled = true;
			else if (chosenTopping == Toppings.Pepper)
				pepper.renderer.enabled = true;
			else if (chosenTopping == Toppings.Bacon)
				bacon.renderer.enabled = true;
			else if (chosenTopping = Toppings.Sausage)
				sausage.renderer.enabled = true;
		}
		
		yield return new WaitForSeconds(5);
		pepperoni.renderer.enabled = false;
		pepper.renderer.enabled = false;
		bacon.renderer.enabled = false;
		sausage.renderer.enabled = false;
		orderBubble.renderer.enabled = false;
		*/
	}
	void changeSprite() {
		if (phoneRenderer.sprite == silentPhone)
			phoneRenderer.sprite = ringingPhone;
		else
			phoneRenderer.sprite = silentPhone;
	}

	Sprite spritePicker(int num){
		scoreSystem.wantedToppings[num] = true;
		switch (num) {
			case 0:
				return pepperoniSprite;
				break;
			case 1:
				return pepperSprite;
				break;
			case 2:
				return baconSprite;
				break;
			case 3:
				return sausageSprite;
				break;
		default:
			break;
		}
		return pepperoniSprite;
	}
}

