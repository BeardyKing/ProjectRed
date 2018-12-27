﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeClockShowController : MonoBehaviour {


	public PlayerController playerController;
	public GameObject clock;
	public float lerpSpeed = 4;

	void Update () {
		if (playerController.playerState == "move") {
			clock.GetComponent<RectTransform>().localPosition = Vector3.Lerp(
			new Vector3(
				clock.GetComponent<RectTransform>().localPosition.x,
				clock.GetComponent<RectTransform>().localPosition.y,
				0),
			new Vector3(
				clock.GetComponent<RectTransform>().localPosition.x,
				-226,
				0),
			lerpSpeed * Time.deltaTime);
		}
		else if (playerController.playerState == "aim") {
			clock.GetComponent<RectTransform>().localPosition = Vector3.Lerp(
			new Vector3(
				clock.GetComponent<RectTransform>().localPosition.x,
				clock.GetComponent<RectTransform>().localPosition.y,
				0), 
			new Vector3(
				clock.GetComponent<RectTransform>().localPosition.x, 
				-340, 
				0), 
			lerpSpeed * Time.deltaTime);
		}
	}
}
