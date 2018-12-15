using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carryObject : MonoBehaviour {


    Transform parent;
	// Use this for initialization
	void Start () {
        parent = transform.parent;
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" ||collision.gameObject.tag == "Ground")
        collision.transform.parent = parent;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Ground")
            collision.transform.parent = null;
    }

   
}
