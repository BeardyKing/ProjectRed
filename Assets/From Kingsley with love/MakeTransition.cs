using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakeTransition : MonoBehaviour {


	Image box;
	public bool startTransition = false;
	public bool startedLevel = false;

	// Use this for initialization
	void Start () {
		startedLevel = true;
		box = GetComponent<Image>();
		box.color = new Color(box.color.r, box.color.g, box.color.b, 1f);
		//Debug.Log(box.color.a);
	}
	
	// Update is called once per frame
	void Update () {
		if (startedLevel == true) {
			box.color = new Color(box.color.r, box.color.g, box.color.b, box.color.a - (2f * Time.deltaTime));
			if (box.color.a <= 0) {
				startedLevel = false;
			}
		}
		if (startTransition == true) {
			box.color = new Color(box.color.r, box.color.g, box.color.b, box.color.a + (1f*Time.deltaTime));
			//if (box.color.a >= 2) {
			//	startTransition = false;
			//}
		}
	}


}
