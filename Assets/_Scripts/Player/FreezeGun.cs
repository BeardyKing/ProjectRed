﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeGun : MonoBehaviour {

    public LayerMask timeObjects;

    public GameObject currentObject;

    public GameObject manager;

    public LineRenderer RayLine;

    public Material[] mats = new Material[3];


    public GameObject nub;

    public Vector2 mousePos;

    public bool doAim = false;

    public GameObject arm;

	[Range(0,Mathf.PI)]public float offset = 0; // added by kingsley to temp fix the arm

    private void Start()
    {
        nub.GetComponent<SpriteRenderer>().color = Color.green;
    }
    void Update () {

        if(GetComponent<PlayerController>().playerState == "aim")
        {

            if (doAim)
            {
                freezeGun();
            }
           
        }
        else
        {
            doAim = false;
            Vector3[] empty = new Vector3[2];

            RayLine.SetPositions(empty);
        }

    }


    void setDoAimTrue()
    {
        doAim = true;
        
    }

    void rotateArm(Vector2 direction)
    {
		float dir = Mathf.Atan2(direction.y , direction.x);
		dir = dir + offset; // added for temp fix
        arm.transform.rotation = Quaternion.Euler(0, 0, dir*Mathf.Rad2Deg);

    }

    void freezeGun()
    {
        //updating positions
        Vector2 pos = new Vector2(transform.position.x, transform.position.y + 0.25f);
         mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePos - pos;

        rotateArm(direction);
        float disToMouse = direction.magnitude;
        //updating positions

        //sending raycast and interpreting data
        RaycastHit2D hit2D = Physics2D.Raycast(pos, direction, 1000, timeObjects);
        Vector2 temp = (hit2D.collider != null) ? hit2D.point : direction * 100;
        Vector2 extra;

        //print(hit2D.collider);
        if (hit2D.collider != null)
        {
            currentObject = hit2D.collider.gameObject;
            extra = (direction).normalized * 0.2f;
            nub.transform.position = hit2D.point - extra;
            nub.SetActive(true);

        }
        else
        {
            currentObject = null;
            extra = Vector2.zero;
            nub.SetActive(false);

        }
        //sending raycast and interpreting data

        //drawing line based on results
        RayLine.SetPosition(0, pos);
        RayLine.SetPosition(1, temp - extra);
        //drawing line based on results


        //Selecting Objects
        GetMouseInput();
        //Selecting Objects


    }

    void GetMouseInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
			//if (StaticData.FrozenObjectOne != currentObject)
     //       {
     //           if (currentObject != null)
     //           {
					//StaticData.FrozenObjectOne = currentObject;
            //        RayLine.material = mats[1];
            //        nub.GetComponent<SpriteRenderer>().color = Color.blue;
            //    }

            //}

            RayLine.material = mats[1];
             nub.GetComponent<SpriteRenderer>().color = Color.blue;
            if(StaticData.FrozenObjectOne == null && StaticData.FrozenObjectTwo != currentObject){
                StaticData.FrozenObjectOne = currentObject;

            }else if(StaticData.FrozenObjectOne == currentObject){
                StaticData.FrozenObjectOne = null;

            }
        }
        if (Input.GetMouseButtonDown(1))
        {

            RayLine.material = mats[2];
            nub.GetComponent<SpriteRenderer>().color = Color.yellow;
            if (StaticData.FrozenObjectTwo == null && StaticData.FrozenObjectOne != currentObject)
            {
                StaticData.FrozenObjectTwo = currentObject;

            }
            else if (StaticData.FrozenObjectTwo == currentObject)
            {
                StaticData.FrozenObjectTwo = null;

            }


			//if (StaticData.FrozenObjectOne != currentObject)
     //       {

     //           if (currentObject != null)
     //           {
					//StaticData.FrozenObjectTwo = currentObject;
            //        RayLine.material = mats[2];
            //        nub.GetComponent<SpriteRenderer>().color = Color.yellow;
            //    }

            //}
        }

        if(Input.GetMouseButtonUp(0)|| Input.GetMouseButtonUp(1)){
            RayLine.material = mats[0];
            nub.GetComponent<SpriteRenderer>().color = Color.green;
        }





    }  
}
