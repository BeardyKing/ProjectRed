using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {
    
    public float rotationSpeed = 20f;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        doRotation(rotationSpeed);
                               
	}


    void doRotation(float speed)
    {
        transform.Rotate(new Vector3(0, 0, speed * Time.deltaTime));
        float angle = transform.localEulerAngles.z;
        GetComponent<DrawHalo>().extraAngle = angle;

    }

}
