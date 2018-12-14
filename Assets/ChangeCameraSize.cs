using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeCameraSize : MonoBehaviour {

    Camera cam;
    [Range(2,10)]
   public  float enterSize;
    [Range(2, 10)]
    public float exitSize;

	// Use this for initialization
	void Start () {
        cam = Camera.main;

	}
   
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            cam.GetComponent<CameraSize>().target = exitSize;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            cam.GetComponent<CameraSize>().target = enterSize;
        }
    }
}
