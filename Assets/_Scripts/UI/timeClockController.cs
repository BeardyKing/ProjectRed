using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeClockController : MonoBehaviour {

	public GameObject arm;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float offset = (float)StaticData.BufferAge * 2f;

		if (StaticData.CurrentAge == 1) {
			arm.transform.eulerAngles = new Vector3(0, 0, 45 - offset);

		} else if (StaticData.CurrentAge == 2) {
			arm.transform.eulerAngles = new Vector3(0, 0, 0 - offset);

		} else if(StaticData.CurrentAge == 3){
			arm.transform.eulerAngles = new Vector3(0, 0, -45 - offset);
		}


	}	
}
