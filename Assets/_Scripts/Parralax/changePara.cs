using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changePara : MonoBehaviour {


	public ParallaxController pc;

	// Use this for initialization
	void Start () {
		pc = FindObjectOfType<ParallaxController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			pc.lvl = 1;
			Debug.Log("changed");
		}
	}
}
