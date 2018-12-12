using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateCraneBoxPositionData : MonoBehaviour {

    public GameObject box;
    public GameObject node;
    

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        box.GetComponent<PositionData>().setPosition(0, node.transform.position);
        box.GetComponent<PositionData>().setPosition(1, node.transform.position);
        box.GetComponent<PositionData>().setPosition(2, node.transform.position);
    }
}
