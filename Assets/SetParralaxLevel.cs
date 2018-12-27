using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetParralaxLevel : MonoBehaviour {

	public ParallaxController2 para;
	public int currentLevel;

	void OnTriggerEnter2D(Collider2D collision) {
		para.currentLevel = currentLevel;
	}

	// overkill fix
	void OnTriggerStay2D(Collider2D collision) {
		para.currentLevel = currentLevel;
	}

	void OnTriggerExit2D(Collider2D collision) {
		para.currentLevel = 0;
	}
}
