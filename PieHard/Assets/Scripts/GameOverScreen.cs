using UnityEngine;
using System.Collections;

public class GameOverScreen : MonoBehaviour {

	public void changeScene(int scene) {
		Application.LoadLevel(scene);
	}
}
