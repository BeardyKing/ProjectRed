using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetParralaxLevel : MonoBehaviour {

	public ParallaxController2 para;
	public int currentLevel;

	void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player")
        {
            para.currentLevel = currentLevel;
        }
    }

	// overkill fix
	void OnTriggerStay2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player")
        {
            //para.currentLevel = currentLevel;
        }
        Debug.Log(collision.gameObject.tag);
    }

	void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player")
        {
            para.currentLevel = 0;
        }
	}
}
