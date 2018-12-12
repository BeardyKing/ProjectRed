using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour {


    public int thisAge = 1;
    int mainAge;
    Animator anim;
	Vector2[] posData;


    int firstFrame = 2;


    public Sprite[] timeSprites = new Sprite[3];

    public Sprite test;

    void Start () {

        anim = GetComponent<Animator>();
		posData = GetComponent<PositionData>().timePositions;
        anim.Play("Age1");


        //initializing polycollider to the correct shape
        Destroy(GetComponent<PolygonCollider2D>());
        gameObject.AddComponent<PolygonCollider2D>();
        //

    }
	
	// Update is called once per frame
	void Update () {

        initializeColliders();
        checkAgeandChange();


    }




    void checkAgeandChange()
    {
        mainAge = StaticData.CurrentAge;

        if (thisAge != mainAge)
        {
            if (isFrozen() == false)
            {
                changeAge(thisAge, mainAge);
                //changeSprite(mainAge);
                // thisAge = mainAge;

                //  print("main: " + mainAge + " this:" + thisAge);
                UpdatePositionOnAgeChange();
            }
        }
    }


    void initializeColliders()
    {

        if (firstFrame > 0)
        {
            resetPolyCollider();
            firstFrame--;
        }
    }

	void UpdatePositionOnAgeChange(){

		transform.position = posData[StaticData.CurrentAge -1];
	}

    void changeSprite(int age){
        print("Changing "+gameObject.name +" to "+timeSprites[age-1].name);

        SpriteRenderer SR = GetComponent<SpriteRenderer>();


         SR.sprite = timeSprites[age-1];

       
    }

    void resetPolyCollider()
    {

        Destroy(GetComponent<PolygonCollider2D>());
        gameObject.AddComponent<PolygonCollider2D>();
    }


	bool isFrozen()
    {
        GameObject frozenObject1 = StaticData.FrozenObjectOne;
        GameObject frozenObject2 = StaticData.FrozenObjectTwo;

		if (gameObject == frozenObject1) {
			return true;
		}
        if(gameObject == frozenObject2){
            return true;
        }
        return false;
    }

    void changeAge(int from, int to){
         if(from == 1){
            if(to == 2){
                //anim 1--> 2
                //anim.Play("A1_A2");
                anim.Play("to2");
            }
            if(to == 3){
                //anim 1--> 3
               // anim.Play("A1_A3");
                anim.Play("to3");
            
            }
        }

         if(from == 2){
            if (to == 1){
                //anim 2--> 1
                //anim.Play("A2_A1");
                anim.Play("to1");
            }
            if (to == 3){
                //anim 2--> 3
                //anim.Play("A2_A3");

                anim.Play("to3");
            }
        }

         if(from == 3){
            if (to == 1){
				//anim 3--> 1
                //anim.Play("A3_A1");
                anim.Play("to1");
            }
			if (to == 2){
				//anim 3 --> 2
               // anim.Play("A3_A2");
                anim.Play("to2");
            }
        }
        thisAge = mainAge;
    }
}
