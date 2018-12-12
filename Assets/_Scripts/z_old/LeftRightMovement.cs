using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftRightMovement : MonoBehaviour {

    public float lowerBound;
    public float upperBound;
    public float moveSpeed = 5f;



    public string dirState = "left"; //left right stop go
    public string prevDirState;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Vector2 pos = transform.position;

        if(upperBound < lowerBound){
            upperBound = lowerBound;
        }

        if(dirState == "left"){

            if (pos.x > lowerBound){
                pos.x -= moveSpeed * Time.deltaTime;

            }else{
                dirState = "right";
            }

            if (Input.GetKeyDown("p")) { prevDirState = dirState; dirState = "stop"; }
        }
        else if(dirState == "right"){

            if (pos.x < upperBound)
            {
                pos.x += moveSpeed * Time.deltaTime;

            }
            else
            {
                dirState = "left";
            }

            if (Input.GetKeyDown("p")) { prevDirState = dirState; dirState = "stop"; }
        }
        else if(dirState == "stop"){
            if (Input.GetKeyDown("p")) { dirState = "go"; }
        }
        else if(dirState == "go"){
            dirState = prevDirState; 
        }

        transform.position = pos;
	}
}
