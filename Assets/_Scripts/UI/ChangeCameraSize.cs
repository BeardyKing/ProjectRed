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

    [Range(-10,10)]
    public float yOffset;

    [Range(-10, 10)]
    public float yOffsetExit;




	// Use this for initialization
	void Start () {
        cam = Camera.main;

	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            cam.GetComponent<CameraSize>().target = enterSize;
            cam.GetComponent<CameraSize>().yExtra = yOffset;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            cam.GetComponent<CameraSize>().target = exitSize;
            cam.GetComponent<CameraSize>().yExtra = yOffsetExit;

        }
    }

  
}
