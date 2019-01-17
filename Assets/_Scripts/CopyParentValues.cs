using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyParentValues : MonoBehaviour {

	public UI_fade_controller cont;
	SpriteRenderer rend;

	// Use this for initialization
	void Start () {
		rend = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {

		UIZero();
		UIOne();
		UITwo();
		UIThree();
		UIFour();
		UIFive();

	}
	void UIZero() {
		if (cont.activeUI == 0 && transform.name == "UI_img_0") {
			if (cont.state == "hold-in") {
				if (rend.color.a < 1) {
					rend.color =
					new Color(
						1,
						1,
						1,
						rend.color.a + (3f * Time.deltaTime)
					);
				}
			} else if (cont.state == "fade-out") {
				if (rend.color.a > 0) {
					rend.color =
					new Color(
						1,
						1,
						1,
						rend.color.a - (8f * Time.deltaTime)
					);
				}
			} else if (cont.state == "hold-out") {
				rend.color = new Color(1, 1, 1, 0);
			}
		}
	}
	void UIOne() {
		if (cont.activeUI == 1 && transform.name == "UI_img_1") {
			if (cont.state == "hold-in") {
				if (rend.color.a < 1) {
					rend.color =
					new Color(
						1,
						1,
						1,
						rend.color.a + (3f * Time.deltaTime)
					);
				}
			} else if (cont.state == "fade-out") {
				if (rend.color.a > 0) {
					rend.color =
					new Color(
						1,
						1,
						1,
						rend.color.a - (8f * Time.deltaTime)
					);
				}
			} else if (cont.state == "hold-out") {
				rend.color = new Color(1, 1, 1, 0);
			}
		}
	}

	void UITwo() {
		if (cont.activeUI == 2 && transform.name == "UI_img_2") {
			if (cont.state == "hold-in") {
				if (rend.color.a < 1) {
					rend.color =
					new Color(
						1,
						1,
						1,
						rend.color.a + (3f * Time.deltaTime)
					);
				}
			} else if (cont.state == "fade-out") {
				if (rend.color.a > 0) {
					rend.color =
					new Color(
						1,
						1,
						1,
						rend.color.a - (8f * Time.deltaTime)
					);
				}
			} else if (cont.state == "hold-out") {
				rend.color = new Color(1, 1, 1, 0);
			}
		}
	}

	void UIThree() {
		if (cont.activeUI == 3 && transform.name == "UI_img_3") {
			if (cont.state == "hold-in") {
				if (rend.color.a < 1) {
					rend.color =
					new Color(
						1,
						1,
						1,
						rend.color.a + (3f * Time.deltaTime)
					);
				}
			} else if (cont.state == "fade-out") {
				if (rend.color.a > 0) {
					rend.color =
					new Color(
						1,
						1,
						1,
						rend.color.a - (8f * Time.deltaTime)
					);
				}
			} else if (cont.state == "hold-out") {
				rend.color = new Color(1, 1, 1, 0);
			}
		}
	}

	void UIFour() {
		if (cont.activeUI == 4 && transform.name == "UI_img_4") {
			if (cont.state == "hold-in") {
				if (rend.color.a < 1) {
					rend.color =
					new Color(
						1,
						1,
						1,
						rend.color.a + (3f * Time.deltaTime)
					);
				}
			} else if (cont.state == "fade-out") {
				if (rend.color.a > 0) {
					rend.color =
					new Color(
						1,
						1,
						1,
						rend.color.a - (8f * Time.deltaTime)
					);
				}
			} else if (cont.state == "hold-out") {
				rend.color = new Color(1, 1, 1, 0);
			}
		}
	}

	void UIFive() {
		if (cont.activeUI == 5 && transform.name == "UI_img_5") {
			if (cont.state == "hold-in") {
				if (rend.color.a < 1) {
					rend.color =
					new Color(
						1,
						1,
						1,
						rend.color.a + (3f * Time.deltaTime)
					);
				}
			} else if (cont.state == "fade-out") {
				if (rend.color.a > 0) {
					rend.color =
					new Color(
						1,
						1,
						1,
						rend.color.a - (8f * Time.deltaTime)
					);
				}
			} else if (cont.state == "hold-out") {
				rend.color = new Color(1, 1, 1, 0);
			}
		}
	}
}
