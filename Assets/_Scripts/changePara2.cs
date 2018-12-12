using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changePara2 : MonoBehaviour {

	public ParallaxController pc;
	public GameObject bg;

	// Use this for initialization
	void Start() {
		pc = FindObjectOfType<ParallaxController>();
	}

	// Update is called once per frame
	void Update() {

	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			pc.lvl = 0;
			bg.transform.position = new Vector3(96, 22, 0);
			pc.parallaxOffset = 0;
			Debug.Log("changed");
		}
	}
}
