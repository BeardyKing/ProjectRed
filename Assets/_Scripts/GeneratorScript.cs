using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorScript : MonoBehaviour {

     AnimationManager anim;
    public bool on1, on2, on3;
    public WireSend wire;

    public bool on;
    
	// Use this for initialization
	void Start () {
        anim = GetComponent<AnimationManager>();
	}
	
	// Update is called once per frame
	void Update () {
      
        int age = anim.thisAge;

       
        switch (age)
        {
            case 1:
                on = on1;

                break;
            case 2:
                on = on2;
                break;
            case 3:
                on = on3;
                break;

            default:
                on = false;
                break;
        }

        wire.sendingPower = on;


       
	}
}
