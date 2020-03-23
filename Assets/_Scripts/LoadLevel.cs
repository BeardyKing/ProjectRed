using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour {

	int levelSelected;
	bool singlePass = false;
	public MakeTransition box;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SelectLevelNow(int input){
		SceneManager.LoadScene(input);

	}
	public void SelectLevelWait(int input){
		levelSelected = input;
		if (singlePass == false) {
			singlePass = true;
			box.startTransition = true;
		}
		Invoke("WaitBeforeLoad", 1);
	}

	public void SelectLevelWait2(int input) {
		levelSelected = input;
		if (singlePass == false) {
			singlePass = true;
			box.startTransition = true;
		}
		Invoke("WaitBeforeLoad",4);
	}

	void WaitBeforeLoad(){
		SceneManager.LoadScene(levelSelected);
	}

	public void ExitGame() {
		Application.Quit();
	}
}
