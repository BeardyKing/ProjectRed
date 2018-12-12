using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawMultipleOnSpriteCheck : MonoBehaviour {


    public Sprite[] Singles = new Sprite[1];
    public Sprite[] Multiples =  new Sprite[1];
    SpriteRenderer renderer;

    Sprite[] sprites;
    AnimationManager anim;
    drawHaloCheck check;
	void Start () {
        anim = GetComponent<AnimationManager>();
        check = GetComponent<drawHaloCheck>();
        renderer = GetComponent<SpriteRenderer>();

    }
	
	// Update is called once per frame
	void Update () {
        sprites = anim.timeSprites;
        Sprite current = renderer.sprite;
        bool drawMultiple = false;



        for (int i = 0; i < Singles.Length; i++)
        {
            if(current == Singles[i])
            {
                drawMultiple = false;
                break;
            }
        }
        for (int i = 0; i < Multiples.Length; i++)
        {
            if (current == Multiples[i])
            {
                drawMultiple = true;
                break;
            }
        }

        check.drawMultipleHalos = drawMultiple;





    }
}
