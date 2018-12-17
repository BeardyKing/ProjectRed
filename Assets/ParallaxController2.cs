﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxController2 : MonoBehaviour {

	[Header("References")]
	[Space(5)]
	public GameObject camera;
	public GameObject[] level1_backgrounds;
	public GameObject[] level2_backgrounds;
	[Space(5)]

	[Header("Level")]
	[Space(5)]
	public int currentLevel;
	public bool isActive;

	[Space(10)]
	[Header("Object Offset")]
	[Space(5)]

	public float[] level1_xOffset;
	public float[] level2_xOffset;

	Vector3 lastCamPos;

	void Start() {
		lastCamPos = camera.transform.position;
	}

	void Update() {
		if (currentLevel == 1) {
			DoParallax(level1_backgrounds, level1_xOffset);
		}
		else if (currentLevel == 2) {
			DoParallax(level2_backgrounds, level2_xOffset);
		}
	}

	void DoParallax(GameObject[] backgrounds, float[] xOffset) {
		for (int i = 0; i < backgrounds.Length; i++) {
			float parallax = ((lastCamPos.x - camera.transform.position.x) * xOffset[i]) * Time.deltaTime;
			backgrounds[i].transform.position = new
				Vector3(
				backgrounds[i].transform.position.x + parallax,
				backgrounds[i].transform.position.y,
				0);
		}
		lastCamPos = camera.transform.position;
	}
}
