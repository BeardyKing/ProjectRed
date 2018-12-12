using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bridgeScript : MonoBehaviour {

    PolygonCollider2D drawPoly;

     public GameObject[] colliders;
     Sprite[] sprites;

    GameObject bridgeMiddle;



    AnimationManager anim;
    int age;


	void Start () {
        anim = GetComponent<AnimationManager>();
        sprites = anim.timeSprites;
	}
	
	// Update is called once per frame
	void Update () {

        updateColliderReference();

        checkAndUpdateCollider();
    }


    void updateColliderReference()
    {

        drawPoly = GetComponent<PolygonCollider2D>();
        drawPoly.isTrigger = true;
    }

    void checkAndUpdateCollider()
    {
        for (int i = 0; i < sprites.Length; i++)
        {
            if (GetComponent<SpriteRenderer>().sprite == sprites[i])
            {
                colliders[i].SetActive(true);
            }
            else
            {
                colliders[i].SetActive(false);
            }
        }
    }



}

