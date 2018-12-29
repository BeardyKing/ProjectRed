using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveUpYouFuck : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnTriggerStay2D(Collider2D other) {
		if (other.gameObject.tag == "fuck") {
			transform.Translate(Vector2.up / 6);
			Debug.Log("FUCKING MOVE PLZ");
		}
	}

	void OnCollisionStay2D(Collision2D other) {
	
	}
}
