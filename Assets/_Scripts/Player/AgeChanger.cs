using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgeChanger : MonoBehaviour {

	public int refAge = 0;
	public float ageBuffer;
    float scrollCounter = 0.5f;
    float MoveBufferTime = 0.3f;

    PlayerController controller;

	// Use this for initialization
	void Start () {
        controller = GetComponent<PlayerController>();
		refAge = StaticData.CurrentAge;
	}
	
	// Update is called once per frame
	void Update () {

        if(controller.playerState != "aim")
        {
            ScrollToNextAge();
            TestingAgeChanger();
            UpdateRefAge();
        }
       
	}
    
    void ScrollToNextAge(){
        //Debug.Log(StaticData.StopScroll + " || " + scrollCounter + " || " + StaticData.BufferAge);
        if (StaticData.StopScroll == false) {
            float temp = Input.GetAxis("Mouse ScrollWheel");
            if (temp != 0) {
                MoveBufferTime = 0.3f;
                if (temp > 0.05) {
                    StaticData.BufferAge += 2;
                }
                else if (temp < -0.05) {
                    StaticData.BufferAge -= 2;
                }
                else {
                 //   Debug.Log(" :: " + temp);
                }
            }
            DoCountDown();
        }
        else if (StaticData.StopScroll == true) {
            scrollCounter -= Time.deltaTime;
            if (scrollCounter <= 0) {
                scrollCounter = 0.5f;
                StaticData.StopScroll = false;
            }
        }
    }

    void DoCountDown(){
        MoveBufferTime -= Time.deltaTime;
        if (MoveBufferTime <= 0) {
            if (StaticData.BufferAge > 0) {
                StaticData.BufferAge -= 1;
            }
            else if (StaticData.BufferAge < 0) {
                StaticData.BufferAge += 1;
            }
        }
    }

	void UpdateRefAge(){
		if (refAge != StaticData.CurrentAge) {
			refAge = StaticData.CurrentAge;
		}
	}

	void TestingAgeChanger(){
		if (Input.GetKeyDown(KeyCode.UpArrow)) {
			if (StaticData.CurrentAge != 3) {
				StaticData.CurrentAge += 1;
			}
		}
		if (Input.GetKeyDown(KeyCode.DownArrow)) {
			if (StaticData.CurrentAge != 1) {
				StaticData.CurrentAge -= 1;
			}
		}
	}
}
