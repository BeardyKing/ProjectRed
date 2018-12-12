using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxController : MonoBehaviour {

	[Header("data")]
	public float parallaxOffset;

	[Header("References")]
	public GameObject mainCamera;
	public GameObject[] bg_1;

	float offsetX;
    [Range(-5,5)]
	public float offsetY;
	float i;

	public int lvl = 0;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Level_1();
		Level_2();
	}

	void Level_1() {
		if (lvl == 0) {
			offsetX = mainCamera.transform.position.x;
			offsetX = offsetX / parallaxOffset;

			i += 0.03f;
			for (int i = 0; i < bg_1.Length - 1; i++) {

				bg_1[i].transform.position = new Vector3(offsetX * Mathf.Pow(bg_1.Length - i, 1.5f), offsetY, 0);
			}
		}
	}



	void Level_2() {

	}

	void Level_3() {

	}
}
