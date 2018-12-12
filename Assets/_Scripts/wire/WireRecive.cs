using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireRecive : MonoBehaviour {

    public bool recievingPower = false;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (recievingPower)
        {

            GetComponent<SpriteRenderer>().color = Color.green;
        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.red;
        }
	}
}
