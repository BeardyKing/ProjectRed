using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Animation : MonoBehaviour {


	UI_fade_controller uiCont;

	public GameObject arrow;
	public GameObject pointer;

	public Sprite[] mouseSprites;
	public GameObject mouseObject;

	public bool startArrow = true;
	float timepassed;

	// Use this for initialization
	void Start () {
		uiCont = gameObject.GetComponent<UI_fade_controller>();
		// starting col for mouse
	}
	
	// Update is called once per frame
	void Update () {
		SetStartValues();
		if (uiCont.activeUI == 1 && uiCont.state == "hold-in") {
			MoveArrowUp();
			RotateHand();
			MouseFlash();
		}
	}

	void MouseFlash() {
		timepassed += Time.deltaTime;
		if (timepassed >= 0.4f) {
			timepassed = 0;
			if (mouseObject.GetComponent<SpriteRenderer>().sprite.name == "scroll to change time_1") {
				mouseObject.GetComponent<SpriteRenderer>().sprite = mouseSprites[1];
			} else if(mouseObject.GetComponent<SpriteRenderer>().sprite.name == "scroll to change time_8") {
				mouseObject.GetComponent<SpriteRenderer>().sprite = mouseSprites[0];
			}
		}
	}

	void SetStartValues() {
		if (GetComponent<UI_fade_controller>().state == "fade-in") {
			arrow.transform.localPosition = new Vector2(arrow.transform.localPosition.x, -0.29f);
			mouseObject.GetComponent<SpriteRenderer>().sprite = mouseSprites[0];
		}
	}

	void RotateHand() {
		if (pointer.transform.rotation.z > 0) {

			Color c;
			c = pointer.GetComponent<SpriteRenderer>().color;
			if (c.a < 1) {
				pointer.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, c.a + Time.deltaTime * 1);
			}

			pointer.transform.Rotate(Vector3.back * 50 * (Time.deltaTime));

		}
		if (pointer.transform.rotation.z <= 0) {
			Color c;
			c = pointer.GetComponent<SpriteRenderer>().color;
			pointer.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, c.a - Time.deltaTime * 5);
			if (c.a <= 0) {
				pointer.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
				pointer.transform.eulerAngles = new Vector3(0, 0, 70);
				startArrow = true;
			}
		}
	}

	void MoveArrowUp() {
		if (arrow.transform.localPosition.y < 0.27f) {
			Color c;
			c = arrow.GetComponent<SpriteRenderer>().color;
			if (c.a <= 0) {
				arrow.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, c.a + Time.deltaTime * 1);
			}
			arrow.transform.Translate((Vector2.up * Time.deltaTime) / 2.3f);
		} else if (arrow.transform.localPosition.y >= 0.27f) {
			
			Color c;
			c = arrow.GetComponent<SpriteRenderer>().color;
			arrow.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, c.a - Time.deltaTime * 5);
			if (c.a <= 0 && startArrow == true) {
				arrow.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
				arrow.transform.localPosition = new Vector2(arrow.transform.localPosition.x, -0.29f);
				startArrow = false;
			}
		}
	}
}
