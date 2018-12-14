using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawHalo : MonoBehaviour {

     public bool haloActive;

    public string state = "none";   // none, selected, object1, object2 //


    public GameObject player;

    public GameObject manager;

    public LineRenderer Line;
    public GameObject lineDraw;

  

    public Material[] mats = new Material[3];
    public float extraAngle = 0f;

    public float haloDistance = 0.1f;
    public float haloWidth = 0.1f;
    public haloStyle style;
    public bool keepToMainStyle = true;





    void Start () {
        // haloSwitch = GetComponent<HaloSwitch>();
        // haloSwitch.setValues(player, state, manager, haloActive);

        player = GameObject.Find("player");
        manager = GameObject.Find("EventHandeler");
        style = manager.GetComponent<haloStyle>();
     
    }
	
	
	void Update () {

        Vector2 pos = transform.position;
        checkMainStyle();
        StateCheck();
        DrawLines(pos);
        UpdateLineStyle();


        //print(gameObject.name + "Scale: " + getScale());
    }


    void UpdateLineStyle()
    {
        Line.startWidth = (haloActive) ? haloWidth : 0f;
        Line.endWidth = (haloActive) ? haloWidth : 0f;
        Line.material = chooseMaterial(state);
        Line.loop = true;
    }

    void checkMainStyle()
    {

        if (keepToMainStyle)
        {
            haloDistance = style.distatnce;
            haloWidth = style.width;

        }
    }


    public Material chooseMaterial(string state)
    {
        switch (state)
        {
            case "selected":
                return mats[0];
            case "object1":
                return mats[1];
            case "object2":
                return mats[2];
            case "aim":
                return mats[3];
            default:
                return mats[0];
        }
    }


    
    void DrawLines(Vector2 pos)
    {


        PolygonCollider2D poly = GetComponent<PolygonCollider2D>();
        List<Vector3> Verticies = new List<Vector3>();

        for (int i = 0; i < poly.points.Length; i++)
        {
            Verticies.Add(poly.points[i]);
        }
        Verticies.Add(Verticies[0]);



        if (Line.useWorldSpace == false)
        {
            lineDraw.transform.position = transform.position;
             lineDraw.transform.Rotate(0,0,GetComponent<Rotate>().rotationSpeed * Time.deltaTime);
           // lineDraw.transform.rotation.SetEulerAngles(0, 0, transform.rotation.eulerAngles.z);
        }


        
        Vector3[] temp = Verticies.ToArray();
        for (int i = 0; i < temp.Length; i++)
        {


          //  temp[i] = addExtraRotation(pos, temp[i], extraAngle);
           
            if(Line.useWorldSpace== true){
                temp[i].x += pos.x;
                temp[i].y += pos.y;
            }
           

           
           
            if(Line.useWorldSpace!=true){
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

        for (int i = 0; i < temp.Length; i++)
        {

            Vector2 original = temp[i];
            temp[i] = (temp[i] * getScale());
            Vector3 offset = original * (getScale() - Vector2.one);
          //  temp[i] = temp[i] - offset;
          

        }


        Line.positionCount = temp.Length;
        Line.SetPositions(temp);


       












    }

    Vector3 addExtraRotation(Vector3 centre, Vector3 point, float angle){
        
        Vector3 Distance = point - centre;
        float rads = angle * Mathf.Deg2Rad;
        Vector3 angleVector = new Vector3(Mathf.Cos(rads), Mathf.Sin(rads));
         float Magnitude = Distance.magnitude;
        return angleVector * Magnitude;








    }

    void StateCheck()
    {
     
		if (StaticData.FrozenObjectOne == gameObject)
        {
            state = "object1";
        }
		else if (StaticData.FrozenObjectTwo == gameObject)
        {
            state = "object2";
        }
        else if (player.GetComponent<FreezeGun>().currentObject == gameObject)
        {
            state = "selected";
        }
        else if(player.GetComponent<PlayerController>().playerState == "aim")
        {
            state = "aim";
        }
        else
        {
            state = "none";
        }

        if (state != "none")
        {
            haloActive = true;
        }
        else
        {
            haloActive = false;
        }
    }


    Vector2 getScale()
    {

        float x = transform.localScale.x;
        float y = transform.localScale.y;
        Vector2 scale = new Vector2(x, y);
        return scale;

    }
    
}
