using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITriggerController : MonoBehaviour {

	public UI_fade_controller controller;
	public LerpToPlayer lerpToPlayer;

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "ladder") {
			lerpToPlayer.SetPosOfUI();
			controller.InvokeOnEnterTrigger(0);
		}
		if (other.gameObject.tag == "start") {
			lerpToPlayer.SetPosOfUI();
			controller.InvokeOnEnterTrigger(2);
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.tag == "ladder") {
			lerpToPlayer.isActive = false;
			controller.InvokeOnExitTrigger();
		}
		if (other.gameObject.tag == "start") {
			lerpToPlayer.isActive = false;
			controller.InvokeOnExitTrigger();
		}
	}
}
