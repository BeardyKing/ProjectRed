using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animatePlayer : MonoBehaviour {

    // Use this for initialization

    PlayerController controller;
    Animator anim;
    SpriteRenderer renderer;
	FreezeGun freezeGun;
    public Respawn respawn;

	public SpriteRenderer armRend; // kingsley
	float tempOffset; // kingsley

    int age;

	void Start () {
        controller = GetComponent<PlayerController>();
        anim = GetComponent<Animator>();
        renderer = GetComponent<SpriteRenderer>();
        freezeGun = GetComponent<FreezeGun>();
		tempOffset = freezeGun.offset;
    }

	void Update() {
		ChangeTime();
		Running();
		Jumping();
		FlipSprite();
		FlipArm();
		Aiming();
		Grounded();
        Climbing();


        age = StaticData.CurrentAge;
	}

	void ChangeTime(){
		if (age != StaticData.CurrentAge) {
			anim.SetTrigger("changeTime");
		}
	}

	void Running(){
		if (controller.xDir != 0) {
			anim.SetBool("running", true);
		} else {
			anim.SetBool("running", false);
		}
	}


    public void Climbing()
    {
        if(controller.tryClimb && controller.onLadder)
        {
            anim.SetBool("onLadder",true);
        }

        if (controller.climbing)
        {
            anim.SetBool("climbing",true);
        }
        else
        {
            anim.SetBool("climbing", false);
        }

        if(!controller.tryClimb && !controller.onLadder)
        {
            anim.SetBool("onLadder", false);
        }


    }

    public void spawn(){
        respawn.spawn();
    }

	void Jumping(){
		if (controller.jumpPressed == true) {
			anim.SetBool("jumping", true);
		} else {
			anim.SetBool("jumping", false);
		}
	}

	void FlipSprite(){
		if (controller.xDir > 0) {
			renderer.flipX = false;
		}

		if (controller.xDir < 0) {
			renderer.flipX = true;
		}
	}

	void FlipArm(){
		if (renderer.flipX == true) {
			//armRend.flipX = true;
			freezeGun.offset = -tempOffset;

			armRend.flipY = true;
		}
		else{
			//armRend.flipY = false;
			freezeGun.offset = tempOffset;

			armRend.flipY = false;
		}
	}

	void Aiming(){
		if (controller.playerState == "aim") {

			freezeGun.arm.SetActive(true);
			anim.SetBool("aiming", true);

			if (freezeGun.mousePos.x > transform.position.x) {
				renderer.flipX = false;
			}

			if (freezeGun.mousePos.x < transform.position.x) {
				renderer.flipX = true;
			}
		} else {
			freezeGun.arm.SetActive(false);
			anim.SetBool("aiming", false);
		}
	}

	void Grounded(){
		if (controller.isGrounded == true) {
			anim.SetBool("grounded", true);
		} else {
			anim.SetBool("grounded", false);
		}
	}  
}

