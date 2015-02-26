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
	public GameObject pepperoni;
	public GameObject pepper;
	public GameObject bacon;
	public GameObject sausage;
	
	/* S P R I T E S */
	public Sprite silentPhone;
	public Sprite ringingPhone;
	private SpriteRenderer phoneRenderer;

	public Animator sprite_phone;
	
	// Use this for initialization
	void Start () {
		/* I N I T I A L  S P R I T E */

		/*phoneRenderer = GetComponent<SpriteRenderer>();
		if (phoneRenderer.sprite = null)
			phoneRenderer.sprite = silentPhone;
		*/
		
		/* P H O N E  S T A T E */  
		cur_state = PhoneState.silent;
		next_state = PhoneState.silent;
		start_time = Time.time;
		orderBubble.renderer.enabled = false;
		
		/* T O P P I N G S */
		pepperoni.renderer.enabled = false;
		pepper.renderer.enabled = false;
		bacon.renderer.enabled = false;
		sausage.renderer.enabled = false;
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
		delay = Random.Range(20, 45);	
		sprite_phone.SetBool("ringing", true);
	}
	
	void silent(){
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
		orderBubble.renderer.enabled = true;
		//for testing purposes
		bacon.renderer.enabled = true;
		
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
}