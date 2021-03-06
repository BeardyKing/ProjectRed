﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheckPlayer : MonoBehaviour {

    public PlayerController pc;
    void Start() {
        pc = FindObjectOfType<PlayerController>();
    }

    void OnTriggerStay2D(Collider2D other) {

        //added caveTile
        if (other.gameObject.tag == "Ground" || other.gameObject.tag == "caveTile")
        {
			pc.isGrounded = true;
			pc.jumpSinglePass = false;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		pc.isGrounded = false;
	}
}
