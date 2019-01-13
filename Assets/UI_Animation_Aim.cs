using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Animation_Aim : MonoBehaviour
{
	public FrozenObjects frozenObjects;
	public GameObject aim_long;
	public GameObject aim_ball;
	public GameObject mouse_click;
	public GameObject mouse_click_right;

	public UITriggerController uiTriggerRef;

	public Color white;
	//public Color red;


    // Start is called before the first frame update
    void Start()
    {
        
    }

	// Update is called once per frame
	float counter;
	float maxCounter = 0.3f;
	bool colActive = false;
	int temp = 0;
    void Update()
    {
		if (uiTriggerRef.uiState == 2) {
			counter += Time.deltaTime;
			if (counter > maxCounter) {
				counter = 0;
				colActive = !colActive;
				if (colActive == true) {
					aim_long.GetComponent<SpriteRenderer>().color = white;
					aim_ball.GetComponent<SpriteRenderer>().color = white;
					mouse_click.GetComponent<SpriteRenderer>().color = white;
					mouse_click_right.GetComponent<SpriteRenderer>().color = white;
				} 
				else if(colActive == false) {

					aim_long.GetComponent<SpriteRenderer>().color = frozenObjects.colors[temp];
					aim_ball.GetComponent<SpriteRenderer>().color = frozenObjects.colors[temp];
					if (temp == 0) {
						mouse_click.GetComponent<SpriteRenderer>().color = frozenObjects.colors[0];
					}
					if (temp == 1) {
						mouse_click_right.GetComponent<SpriteRenderer>().color = frozenObjects.colors[1];
					}

					temp++;
					if (temp > 1) {
						temp = 0;
					}
				}
			}
		}

	}
}
