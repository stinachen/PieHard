using UnityEngine;
using System.Collections;

public enum PhoneState{
	ringing, silent, busy
}

/* TOPPINGS FOR ORDERS */
/* Easy: 0-3
   Medium: 0-5
   Hard: 0-7
 */
public enum Toppings {
	Pepperoni, Pepper, Bacon, Sausage, 
	Ham, Pineapple, Olive, Chicken
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
	/* M E D I U M  T O P P I N G S */
	public GameObject five;
	public GameObject six;
	/* H A R D  T O P P I N G S */
	public GameObject seven;
	public GameObject eight;

	public GameObject plus0;
	public GameObject plus1;
	public GameObject plus2;
	public GameObject plus3;
	public GameObject plus4;
	public GameObject plus5;
	public GameObject plus6;

	public GameObject dontDestroy;

	/* S P R I T E S */
	public Sprite pepperoniSprite;
	public Sprite pepperSprite;
	public Sprite baconSprite;
	public Sprite sausageSprite;
	public Sprite hamSprite;
	public Sprite pineappleSprite;
	public Sprite chickenSprite;
	public Sprite mushroomSprite;

	public Sprite silentPhone;
	public Sprite ringingPhone;


	private SpriteRenderer phoneRenderer;
	
	public Animator sprite_phone;

	private bool timerSet = false;
	private float timerDelay = 4f;
	private float timerUsage;

	private int numToppings;

	private Scoring scoreSystem;

	private bool start = true;
	private DontDestroy information;

	
	// Use this for initialization
	void Start () {
		dontDestroy = GameObject.FindGameObjectWithTag ("dontdestroy");
		information = dontDestroy.GetComponent<DontDestroy>();
		
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
		if (information.cognitiveMode == 1) {
			five.renderer.enabled = false;
			six.renderer.enabled = false;
		} else if (information.cognitiveMode == 2) {
			seven.renderer.enabled = false;
			eight.renderer.enabled = false;

		}
		/* P L U S  I M A G E */
		plus0.renderer.enabled = false;
		plus1.renderer.enabled = false;
		plus2.renderer.enabled = false;
		if (information.cognitiveMode == 1) {
			plus3.renderer.enabled = false;
			plus4.renderer.enabled = false;
		} else if (information.cognitiveMode == 2) {
			plus5.renderer.enabled = false;
		}

		numToppings = 0;
	}

	// Update is called once per frame
	void Update () {
		switch (cur_state) {
			case PhoneState.ringing:
				ringing();
				break;
			case PhoneState.silent:
				silent();
				break;
			case PhoneState.busy:
				sprite_phone.SetBool("ringing", false);
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
		if (start && Time.time > start_time + delay) {
			print ("switch");
			next_state = PhoneState.ringing;
			audio.loop = true;
			audio.Play ();
			start = false;
		}
	}

	/* P H O N E  O R D E R S */
	// RANDOMLY GENERATES NUMBER OF TOPPINGS ON PIZZA
	// EACH TOPPING IS ALSO RANDOMLY GENERATED
	void takeOrders() {
		if (!timerSet) {
			audio.Pause();
			timerSet = true;
			timerUsage = Time.time + timerDelay;
			orderBubble.renderer.enabled = true;
			//pick a number of toppings
			int topping1 = -1;
			int topping2 = -1;
			int topping3 = -1;
			int topping4 = -1;
			int topping5 = -1;
			int topping6 = -1;
			int topping7 = -1;
			int topping8 = -1;

			/* N U M B E R  O F  T O P P I N G S */
			if (information.cognitiveMode == 0)
				numToppings = Random.Range(1,5);
			else if (information.cognitiveMode == 1);
				numToppings = Random.Range(1,7);
			else if (information.cognitiveMode == 2)
				numToppings = Random.Range(1,9);

			/* R E N D E R  I M A G E S */
			if(numToppings >= 1){
				if (information.cognitiveMode == 0)
					topping1 = Random.Range(0,4);
				else if (information.cognitiveMode == 1)
					topping1 = Random.Range(0,6);
				else if (information.cognitiveMode == 2)
					topping1 = Random.Range(0,8);
				one.GetComponent<SpriteRenderer>().sprite = spritePicker(topping1);
				one.renderer.enabled = true;
			}
			if(numToppings >= 2){
				topping2 = topping1;
				while(topping2 == topping1){
					if (information.cognitiveMode == 0)
						topping2 = Random.Range(0,4);
					else if (information.cognitiveMode == 1)
						topping2 = Random.Range(0,6);
					else if (information.cognitiveMode == 2)
						topping2 = Random.Range(0,8);
				}
				two.GetComponent<SpriteRenderer>().sprite = spritePicker(topping2);
				two.renderer.enabled = true;
				plus1.renderer.enabled = true;
			}
			if(numToppings >= 3){
				topping3 = topping2;
				while(topping3 == topping1 || topping3 == topping2){
					if (information.cognitiveMode == 0)
						topping3 = Random.Range (0,4);
					else if (information.cognitiveMode == 1)
						topping3 = Random.Range(0,6);
					else if (information.cognitiveMode == 2)
						topping3 = Random.Range(0,8);
				}
				three.GetComponent<SpriteRenderer>().sprite = spritePicker(topping3);
				three.renderer.enabled = true;
				plus0.renderer.enabled = true;
			}
			if(numToppings >= 4){
				topping4 = topping3;
				while(topping4 == topping1 || topping4 == topping2 || topping4 == topping3){
					if (information.cognitiveMode == 0)
						topping4 = Random.Range(0,4);
					else if (information.cognitiveMode == 1)
						topping4 = Random.Range(0,6); 
					else if (information.cognitiveMode == 2)
						topping4 = Random.Range(0,8);
				}
				four.GetComponent<SpriteRenderer>().sprite = spritePicker(topping4);
				four.renderer.enabled = true;
				plus2.renderer.enabled = true;
			}
			if(numToppings >= 5 && information.cognitiveMode >= 1){
				topping5 = topping4;
				while(topping5 == topping1 || topping5 == topping2 || 
					topping5 == topping3 || topping5 == topping4){
					if (information.cognitiveMode == 1)
						topping5 = Random.Range(0,6);
					else if (information.cognitiveMode == 2)
						topping5 = Random.Range(0,8);
				}
				five.GetComponent<SpriteRenderer>().sprite = spritePicker(topping5);
				five.renderer.enabled = true;
				plus3.renderer.enabled = true;
			}
			if(numToppings >= 6 && information.cognitiveMode >= 1){
				topping6 = topping5;
				while(topping6 == topping1 || topping6 == topping2 || 
					topping6 == topping3 || topping6 == topping4 || 
					topping6 == topping5){
					if (information.cognitiveMode == 1)
						topping6 = Random.Range(0,6);
					else if (information.cognitiveMode == 2)
						topping6 = Random.Range(0,8);
				}
				six.GetComponent<SpriteRenderer>().sprite = spritePicker(topping6);
				six.renderer.enabled = true;
				plus4.renderer.enabled = true;
			}
			if (numToppings >= 7 && information.cognitiveMode == 2) {
				topping7 = topping6;
				while (topping7 == topping1 || topping7 == topping2 || topping7 == topping3 || 
					topping7 == topping4 || topping7 == topping5 || 
					topping7 == topping6) {
					if (information.cognitiveMode == 1)
						topping7 = Random.Range(0,6);
					else if (information.cognitiveMode == 2)
						topping7 = Random.Range(0,8);
				}
				seven.GetComponent<SpriteRenderer>().sprite = spritePicker(topping7);
				seven.renderer.enabled = true;
				plus5.renderer.enabled = true;
			}
			if (numToppings >= 8 && information.cognitiveMode == 2) {
				topping8 = topping7;
				while (topping8 == topping1 || topping8 == topping2 || topping8 == topping3 || 
					topping8 == topping4 || topping8 == topping5 || 
					topping8 == topping6 || topping8 == topping7) {
					if (information.cognitiveMode == 1)
						topping8 = Random.Range(0,6);
					else if (information.cognitiveMode == 2)
						topping8 = Random.Range(0,8);
				}
				eight.GetComponent<SpriteRenderer>().sprite = spritePicker(topping7);
				eight.renderer.enabled = true;
				plus6.renderer.enabled = true;
			}

		}
		if (Time.time > timerUsage) {
			timerSet = false;
			orderBubble.renderer.enabled = false;
			one.renderer.enabled = false;
			two.renderer.enabled = false;
			three.renderer.enabled = false;
			four.renderer.enabled = false;
			if (information.cognitiveMode == 1){
				five.renderer.enabled = false;
				six.renderer.enabled = false;
			}
			if (information.cognitiveMode == 2) {
				seven.renderer.enabled = false;
				eight.renderer.enabled = false;
			}

			plus0.renderer.enabled = false;
			plus1.renderer.enabled = false;
			plus2.renderer.enabled = false;

			if (information.cognitiveMode == 1){
				plus3.renderer.enabled = false;
				plus4.renderer.enabled = false;
			}
			if (information.cognitiveMode == 2) {
				plus5.renderer.enabled = false;
				plus6.renderer.enabled = false;
			}

			next_state = PhoneState.silent;
			start_time = Time.time;
		}

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
				scoreSystem.wantedToppings[0] = true;
				return pepperoniSprite;
				break;
			case 1:
				scoreSystem.wantedToppings[1] = true;
				return pepperSprite;
				break;
			case 2:
				scoreSystem.wantedToppings[2] = true;
				return baconSprite;
				break;
			case 3:
				scoreSystem.wantedToppings[3] = true;
				return sausageSprite;
				break;
			case 4:
				scoreSystem.wantedToppings[4] = true;
				return hamSprite;
				break;
			case 5:
				scoreSystem.wantedToppings[5] = true;
				return pineappleSprite;
			case 6:
				scoreSystem.wantedToppings[6] = true;
				return chickenSprite;
			case 7:
				scoreSystem.wantedToppings[7] = true;
				return mushroomSprite;
		default:
			break;
		}
		return pepperoniSprite;
	}
}

