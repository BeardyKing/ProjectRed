using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UiController : MonoBehaviour {
	public Text currentAge;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Convert.ToInt16(currentAge.text) != StaticData.CurrentAge) {
			currentAge.text = StaticData.CurrentAge.ToString();
		}
	}
}
