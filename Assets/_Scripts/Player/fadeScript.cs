using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fadeScript : MonoBehaviour {


    int age = 1;
	// Use this for initialization
	void Start () {
        //transform.position = new Vector3(0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
        if(age != StaticData.CurrentAge){
            GetComponent<Animator>().SetTrigger("fade");
        }

        age = StaticData.CurrentAge;
	}
}
