using UnityEngine;
using System.Collections;

public class MenuActions : MonoBehaviour {

	public void PickScene(int lvl){
		Application.LoadLevel (lvl);
	}


}
