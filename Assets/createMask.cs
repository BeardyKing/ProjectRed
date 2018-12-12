using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createMask : MonoBehaviour {


    SpriteMask mask;
	// Use this for initialization
	void Start () {
        mask = gameObject.AddComponent<SpriteMask>();
	}
	
	// Update is called once per frame
	void Update () {

        mask.sprite = GetComponent<SpriteRenderer>().sprite;
	}
}
