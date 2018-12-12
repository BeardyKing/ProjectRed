using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class placeHolder_playerController : MonoBehaviour {

    public float xSpeed;


	void Update () {
        var pos = transform.position;
        if (Input.GetKey("a"))
        {
            pos.x -= xSpeed * Time.deltaTime;
        }
        if (Input.GetKey("d"))
        {
            pos.x += xSpeed * Time.deltaTime;
        }
        transform.position = pos;

    }
}

