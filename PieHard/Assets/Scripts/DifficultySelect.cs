using UnityEngine;
using System.Collections;

public class DifficultySelect: MonoBehaviour {

	public GameObject cognitiveTitle;
	public GameObject physicalTitle;

	public GameObject CEasyButton;
	public GameObject CMediumButton;
	public GameObject CHardButton;

	public GameObject PEasyButton;
	public GameObject PMediumButton;
	public GameObject PHardButton;

	public GameObject dontDestroy;

	private DontDestroy information;
	// Use this for initialization
	void Start () {
		information = dontDestroy.GetComponent<DontDestroy>();
	}

	public void selectCognitiveMode(int mode) {
		information.cognitiveMode = mode;
		CEasyButton.SetActive(false);
		CMediumButton.SetActive(false);
		CHardButton.SetActive(false);
		PEasyButton.SetActive(true);
		PMediumButton.SetActive(true);
		PHardButton.SetActive(true);
		cognitiveTitle.SetActive(false);
		physicalTitle.SetActive(true);
	}

	public void selectPhysicalMode(int mode) {
		information.physicalMode = mode;
		// load game scene
		Application.LoadLevel(2);
	}
	
	public void returnToMainMenu(){
		Application.LoadLevel(0);
	}
}
