using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITriggerController : MonoBehaviour {

	public UI_fade_controller controller;
	public LerpToPlayer lerpToPlayer;
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update() {

	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "ladder") {
			lerpToPlayer.SetPosOfUI();
			controller.EnvokeOnExitAndEnterTrigger(0);
		}
		if (other.gameObject.tag == "start") {
			lerpToPlayer.SetPosOfUI();
			controller.EnvokeOnExitAndEnterTrigger(2);
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.tag == "ladder") {
			controller.EnvokeOnExitAndEnterTrigger(0);
		}
		if (other.gameObject.tag == "start") {
			controller.EnvokeOnExitAndEnterTrigger(2);

		}
	}
}
