using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bridgeMiddle : MonoBehaviour {

    public bool active1;
    public bool active2;
    public bool active3;

    public AnimationManager anim;

    public GameObject Line;

    bool active = false;


    // Use this for initialization
    void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
        



        checkIfActive();



        updateSpriteRenderer();

      

    }


    void checkIfActive()
    {
        //if (anim.thisAge ==1)
        //{
        //    active = active1;


        //}

        //else if (anim.thisAge == 2)
        //{
        //    active = active2;

        //}

        //else if (anim.thisAge == 3)
        //{

        //    active = active3;
        //}


        switch (anim.thisAge)
        {
            case 1:
                active = active1;
                break;
            case 2:
                active = active2;
                break;
            case 3:
                active = active3;
                break;
            default:
                break;
        }
    }

    void updateSpriteRenderer()
    {
        if (active == true)
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            Line.SetActive(true);

        }
        else
        {
            GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
            Line.SetActive(false);
        }
    }
}
