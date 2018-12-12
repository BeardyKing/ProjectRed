using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawHaloOnOtherObject : MonoBehaviour {


    PolygonCollider2D poly;
    DrawHalo baseHalo;

    public LineRenderer Line;
    public GameObject otherObject;
    GameObject lineDraw;

    float haloDistance = 0.1f;
    float haloWidth = 0.1f;
    haloStyle style;
     GameObject manager;
    bool keepToMainStyle = true;

    bool haloActive;

    public bool drawOnOther;

    // Use this for initialization
    void Start () {
      
       
        baseHalo = GetComponent<DrawHalo>();
        
        lineDraw = Line.gameObject;
       
	}
	
	// Update is called once per frame
	void Update () {

        getReferences();
        UpdateLineStyle();

       
        if (drawOnOther)
        {
            DrawLines(otherObject.transform.position);
        }

	}

    void UpdateLineStyle()
    {

        if (keepToMainStyle)
        {
            haloDistance = style.distatnce;
            haloWidth = style.width;

        }


        Line.startWidth = (baseHalo.haloActive) ? haloWidth : 0f;
        Line.endWidth = (baseHalo.haloActive) ? haloWidth : 0f;
        Line.material = baseHalo.chooseMaterial(baseHalo.state);
        Line.loop = true;

    }

    void getReferences()
    {
        manager = baseHalo.manager;
        style = manager.GetComponent<haloStyle>();
        haloActive = baseHalo.haloActive;
        poly = otherObject.GetComponent<PolygonCollider2D>();
        keepToMainStyle = baseHalo.keepToMainStyle;
    }

    void DrawLines(Vector2 pos)
    {


        
        List<Vector3> Verticies = new List<Vector3>();


        for (int i = 0; i < poly.GetPath(0).Length; i++)
        {
            Verticies.Add(poly.GetPath(0)[i]);
        }
        Verticies.Add(Verticies[0]);



        if (Line.useWorldSpace == false)
        {
            lineDraw.transform.position = transform.position;
            lineDraw.transform.Rotate(0, 0, GetComponent<Rotate>().rotationSpeed * Time.deltaTime);
            // lineDraw.transform.rotation.SetEulerAngles(0, 0, transform.rotation.eulerAngles.z);
        }



        Vector3[] temp = Verticies.ToArray();
        for (int i = 0; i < temp.Length; i++)
        {


            //  temp[i] = addExtraRotation(pos, temp[i], extraAngle);

            if (Line.useWorldSpace == true)
            {
                temp[i].x += pos.x;
                temp[i].y += pos.y;
            }




            if (Line.useWorldSpace != true)
            {
                pos = Vector3.zero;
            }
            if (temp[i].x < pos.x)
            {
                temp[i].x -= haloDistance;

            }
            else
            {
                temp[i].x += haloDistance;
            }

            if (temp[i].y < pos.y)
            {
                temp[i].y -= haloDistance;

            }
            else
            {
                temp[i].y += haloDistance;
            }





        }


        Line.positionCount = temp.Length;
        Line.SetPositions(temp);















    }
}
