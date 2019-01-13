using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_fade_controller : MonoBehaviour {

	[Header("NUMBERS FOR UI")]
	[Header("0 = ladder")]
	[Header("1 = UI_scroll")]
	[Header("2 = left right")]
	[Header("3 = N/A")]
	[Header("")]

	public LerpToPlayer lerpToPlayer;
	public GameObject[] children;
	public SpriteRenderer[] childImages;

	[Range(0,4)]
	public int activeUI;
	public string state;
	bool singlePass = true;
	// Use this for initialization
	void Start () {
		activeUI = 0;
		state = "hold-out";
	}

	// Update is called once per frame
	void Update () {
		KeyboardController();

		if (state == "fade-in") {
			MoveDir(0);
			FadeIn();
		} else if (state == "fade-out") {
			MoveDir(1);
			FadeOut();
		} else if (state == "hold-in") {
			singlePass = true;
		} else if (state == "hold-out") {
			singlePass = true;
			UIFallBack();
			
		}
	}

	void UIFallBack() {
		for (int i = 0; i < childImages.Length; i++) {
			childImages[i].color = new Color(1, 1, 1, 0);
			children[activeUI].GetComponent<SpriteRenderer>().color = new Color(0,0,0,0);
		}
	}

	void MoveDir(int input) {
		if (input == 0) {
			if (singlePass == true) {
				singlePass = false;
				lerpToPlayer.isActive = true;
				lerpToPlayer.setPos = true;
			}
		}
		else if (input == 1) {
			if (singlePass == true) {
				singlePass = false;
				lerpToPlayer.isActive = false;
			}
			transform.Translate(Vector2.up * (4 * Time.deltaTime));
		}
	}

	void FadeIn() {

		Color temp = children[activeUI].GetComponent<SpriteRenderer>().color;

		children[activeUI].GetComponent<SpriteRenderer>().color =
			new Color(
				temp.r,
				temp.g,
				temp.b,
				temp.a + (4 * Time.deltaTime)
				);
		if (temp.a >= 1) {
			state = "hold-in";
		}
	}

	void FadeOut() {
		Color temp = children[activeUI].GetComponent<SpriteRenderer>().color;

		children[activeUI].GetComponent<SpriteRenderer>().color =
			new Color(
				temp.r,
				temp.g,
				temp.b,
				temp.a - (4 * Time.deltaTime)
				);
		if (temp.a <= 0) {
			state = "hold-out";
		}
	}

	public void InvokeOnEnterTrigger(int input) {
		activeUI = input;
		if (state == "hold-out") {
			state = "fade-in";
			for (int i = 0; i < children.Length; i++) {
				children[i].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
			}
		} 
	}

	public void InvokeOnExitTrigger() {

		for (int i = 0; i < children.Length; i++) {
			if (activeUI == i) {
				children[i].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
			} else {
				children[i].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
			}
		}
		state = "fade-out";
	}

	void KeyboardController() {
		if (Input.GetKeyDown(KeyCode.E)) {
			if (state == "hold-in") {
				state = "fade-out";
				for (int i = 0; i < children.Length; i++) {
					if (activeUI == i) {
						children[i].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
					} else {
						children[i].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
					}
				}
			} else if (state == "hold-out") {
				state = "fade-in";
				for (int i = 0; i < children.Length; i++) {
					children[i].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
				}
			}
		}
	}
}
