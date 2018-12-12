using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireSend : MonoBehaviour {

    public GameObject reciever;
    public LineRenderer line;
  
    public List<Vector3> linePoints = new List<Vector3>();
    public bool sendingPower;
    public Material onMaterial;
    public Material offMaterial;
    public GameObject[] intersections;



	void Start () {
      


	}
	
	// Update is called once per frame
	void Update () {
        linePoints.Clear();

        linePoints.Add(transform.position);

        for (int i = 0; i < intersections.Length; i++)
        {
            linePoints.Add(intersections[i].transform.position);
        }

        linePoints.Add(reciever.transform.position);

        line.positionCount = linePoints.Count;


        Vector3[] temp = new Vector3[linePoints.Count];
        for (int i = 0; i < linePoints.Count; i++)
        {
            temp[i] = linePoints[i];
        }
        line.SetPositions(temp);

        reciever.GetComponent<WireRecive>().recievingPower = sendingPower;

        if (sendingPower)
        {
            line.material = onMaterial;
            GetComponent<SpriteRenderer>().color = Color.green;
        }
        else
        {
            line.material = offMaterial;
            GetComponent<SpriteRenderer>().color = Color.red;
        }

        


    }
}
