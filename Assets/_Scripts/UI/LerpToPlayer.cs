using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpToPlayer : MonoBehaviour {

	[Header("References")]

	public Transform player;
	public UI_fade_controller cont;

	[Header("Offsets")]
	[Space(3)]

	[Range(-5,5)]
	public float xOffset;
	[Range(-5, 5)]
	public float yOffset;
	public float lerpSpeed;

	[Header("controller")]
	public bool isActive = true;
	public bool setPos;

	void Update() {
		SetOffset();
		if (isActive == true) {
			if (setPos == false) {
				LerpToPlayerPos();
			}
			else if (setPos == true) {
				setPos = false;
			}
		}
	}

	public void SetPosOfUI() {
		transform.position = new Vector3(player.position.x + xOffset, player.position.y + yOffset + 1, 0);
	}

	void SetOffset() {
		if (cont.activeUI == 0) {
			xOffset = 1.8f;
		}
		else if (cont.activeUI == 1) {
			xOffset = 3.8f;
		}
		else if (cont.activeUI == 2) {
			xOffset = 2.5f;
		}
		else if (cont.activeUI == 3) {
			xOffset = -3.8f;
		}
		else if(cont.activeUI == 4) {
			xOffset = 1.8f;
		}
	}

	void LerpToPlayerPos() {
		transform.position = Vector3.Lerp(
			new Vector3(
				transform.position.x,
				transform.position.y,
				0),
			new Vector3(
				player.position.x + xOffset,
				player.position.y + yOffset,
				0),
			lerpSpeed * Time.deltaTime);
	}
}
