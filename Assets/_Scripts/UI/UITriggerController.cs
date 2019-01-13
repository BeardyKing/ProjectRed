using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITriggerController : MonoBehaviour {

	public UI_fade_controller controller;
	public LerpToPlayer lerpToPlayer;
	Collider2D lastCol;

	int lastAge = 1;

	public void Update() {
		if (lastAge != StaticData.CurrentAge) {
			if (lastCol.gameObject.tag  == "UI_aim") {
				controller.InvokeOnExitTrigger();
				OnTriggerEnter2D(lastCol);
				Debug.Log("CALLED");
			}
		}
		lastAge = StaticData.CurrentAge;
	}

	void OnTriggerEnter2D(Collider2D other) {
		lastCol = other;
		if (other.gameObject.tag == "ladder") {
			lerpToPlayer.SetPosOfUI();
			controller.InvokeOnEnterTrigger(0);
		}
		if (other.gameObject.tag == "UI_scroll") {
			lerpToPlayer.SetPosOfUI();
			controller.InvokeOnEnterTrigger(1);
		}
		if (other.gameObject.tag == "start") {
			lerpToPlayer.SetPosOfUI();
			controller.InvokeOnEnterTrigger(2);
		}
		if (other.gameObject.tag == "UI_aim") {
			lerpToPlayer.SetPosOfUI();
			Invoke("DoInOneSecond", .3f);
		}
	}

	void DoInOneSecond() {
		if (StaticData.CurrentAge == 1) {
			controller.InvokeOnEnterTrigger(1);
		}
		if (StaticData.CurrentAge == 2) {
			controller.InvokeOnEnterTrigger(3);
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.tag == "ladder") {
			lerpToPlayer.isActive = false;
			controller.InvokeOnExitTrigger();
		}
		if (other.gameObject.tag == "UI_scroll") {
			lerpToPlayer.isActive = false;
			controller.InvokeOnExitTrigger();
		}
		if (other.gameObject.tag == "start") {
			lerpToPlayer.isActive = false;
			controller.InvokeOnExitTrigger();
		}
		if (other.gameObject.tag == "UI_aim") {
			lerpToPlayer.isActive = false;
			controller.InvokeOnExitTrigger();
		}
	}
}
