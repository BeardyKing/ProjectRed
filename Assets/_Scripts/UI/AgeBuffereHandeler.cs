using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgeBuffereHandeler : MonoBehaviour {
    public GameObject[] ageLines = new GameObject[3];
    public GameObject ageBuffer;
    public AgeChanger age;
    float temp;
    // Use this for initialization
    void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
        float temp2 = (float)StaticData.BufferAge / 10;

        if (StaticData.CurrentAge == 1) {
            temp = ageLines[0].transform.position.x;
        }
        if (StaticData.CurrentAge == 2) {
            temp = ageLines[1].transform.position.x;
        }
        if (StaticData.CurrentAge == 3) {
            temp = ageLines[2].transform.position.x;
        }
        //Debug.Log("BuffferAge : " + StaticData.BufferAge + " || CurrentAge : " + StaticData.CurrentAge + " || BufferAge / 2 : " + temp2);
        ageBuffer.transform.position = new Vector2(temp + temp2, ageBuffer.transform.position.y);
	}
}
