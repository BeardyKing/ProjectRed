using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSize : MonoBehaviour {

    [Range(1, 12)]
    public float size = 3;

    [Range(1, 12)]
    public float target = 5;


    public float yExtra;



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       

        if(size > target)
        {
            size -= target * Time.deltaTime;
        }

        if(size < target)
        {
            size += target * Time.deltaTime; 

          
        }

        GetComponent<Camera>().orthographicSize = size;

        float yOffset = 0.9f * (size - 2) + yExtra;

        GetComponent<FollowPlayer>().yOffset = yOffset;
    }
}
