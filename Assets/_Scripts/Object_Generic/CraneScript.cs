using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraneScript : MonoBehaviour {

    public bool on;
    public ButtonScript button;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        on = button.down;
        GetComponent<Animator>().SetBool("on", on);
	}
}
