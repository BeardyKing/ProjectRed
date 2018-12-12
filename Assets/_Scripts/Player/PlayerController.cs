using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	 bool leftPressed, rightPressed;
    [HideInInspector()]// left = A // right = D
    public  bool jumpPressed;               // jump = SPACE
	//bool shootPressed;              // shoot = E
	 bool groundPoundPressed;

    // groundPound = Leftshift
    [HideInInspector()]
   public  bool isGrounded;

    [HideInInspector()]
    public bool jumpSinglePass = false;

    [HideInInspector()]
	  public float xDir = 0;
	 public float yDir = 0;

	public float speed;

	public LayerMask layerMask;

	 Vector2 lastPos;
	 Vector2 currentPos;
	 Vector2 vectorDist;

    [HideInInspector()]
    public string playerState = "move";  //  move aim.

     bool doJump;

    //ladderStuff
    [HideInInspector()]
    public bool tryClimb, onLadder;
    [HideInInspector()]
    public float climbDir;
    public float climbSpeed = 3;

    [HideInInspector()]
    public bool climbing;




    void Start() {
		currentPos = transform.position;
		lastPos = currentPos;
	}

	void Update() {
		if (StaticData.GameState == "running") {

            if(playerState == "move")
            {
                KeyboardInput();
                Movement();

            }
            else
            {
                xDir = 0;
                leftPressed = false;
                rightPressed = false;
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                changeState();
                print("Q");
            }

        } else {
			//END OF GAME;
		}
        CheckNextPos();
		
	}

    void CheckNextPos() {
        // use for checking if the player will fall through the ground ( change from debug to raycast )
        currentPos = transform.position;
        vectorDist = currentPos - lastPos;
        Debug.DrawRay(currentPos, vectorDist, Color.red);
        lastPos = currentPos;
        // add bool when true
        //fixed update will then set pos next frame
    }

	void KeyboardInput() {
		KeyDown();
		KeyUp();
	}

	void Movement() {
		HorizontalMove();
        //ladderStuff
        LadderMove();
		//Jump(); // no longer needed jump called from animation
		transform.Translate(new Vector2(xDir, yDir) * speed * Time.deltaTime);
	}

	void HorizontalMove() {
		if (leftPressed == true) {
			xDir = -1;
		} else if (rightPressed == true) {
			xDir = 1;
		} else {
			xDir = 0;
		}
	}

    void LadderMove()
    {
        //ladderStuff
        if (tryClimb && onLadder)
        {
            if((climbDir < 0 && !isGrounded)||climbDir > 0)
            transform.Translate(0, climbDir*Time.deltaTime, 0);
            GetComponent<Rigidbody2D>().gravityScale = 0;
            climbing = true;

        }
        else
        {
            if (!onLadder)
            {
            GetComponent<Rigidbody2D>().gravityScale = 1;

            }
            else
            {
                climbing = false;
            }

        }
    }

    void setDoJump()
    {
        doJump = true;
		Jump();
    }

	void Jump() {
		if(jumpSinglePass == false){
			GetComponent<Rigidbody2D>().AddForce(Vector3.up * 200);
			jumpSinglePass = true;
		}
	}

	void KeyDown() {
		if (Input.GetKey(KeyCode.A))
			leftPressed = true;
		if (Input.GetKey(KeyCode.D))
			rightPressed = true;
		if (Input.GetKeyDown(KeyCode.Space))
			jumpPressed = true;
		if (Input.GetKeyDown(KeyCode.LeftShift))
			groundPoundPressed = true;

        //ladder stuff here
        if (Input.GetKeyDown(KeyCode.W))
        {

            tryClimb = true;
            climbDir = climbSpeed;

        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            tryClimb = true;
            climbDir = -climbSpeed;

        }
            


    }

	void KeyUp() {
		if (Input.GetKeyUp(KeyCode.A))
			leftPressed = false;
		if (Input.GetKeyUp(KeyCode.D))
			rightPressed = false;
		if (Input.GetKeyUp(KeyCode.Space))
			jumpPressed = false;
		if (Input.GetKeyUp(KeyCode.LeftShift))
			groundPoundPressed = false;

        //ladder stuff here
        if (Input.GetKeyUp(KeyCode.W))
            tryClimb = false;
          //  climbDir = 0;

        if (Input.GetKeyUp(KeyCode.S))
        {
            tryClimb = false;
           // climbDir = 0;

        }
    }


    void changeState()
    {
        if(playerState == "move")
        {
            playerState = "aim";
        }

        else if (playerState == "aim")
        {
            playerState = "move";
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ladder")
        onLadder = true;
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "ladder")
            onLadder = false;
    }



    // moved to child

    //void OnCollisionStay2D(Collision2D other) {
    //	if (other.gameObject.tag == "Ground") {
    //		isGrounded = true;
    //		jumpSinglePass = false;
    //	}
    //}

    //void OnCollisionExit2D(Collision2D other) {
    //	isGrounded = false;
    //}
}
