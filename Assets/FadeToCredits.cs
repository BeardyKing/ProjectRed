﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeToCredits : MonoBehaviour
{
	public LoadLevel loadLevel;
    public Animator anim;
    public Animator playerAnim;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
            anim.SetBool("Rise", true);
			loadLevel.SelectLevelWait2(3);
           other.GetComponent<PlayerController>().playerState = "Respawn";
            StaticData.GameState = "End";
           
           
        }
    }


}
