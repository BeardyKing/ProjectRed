using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carryObject : MonoBehaviour {


    Transform parent;


    public List<GameObject> children;

    Vector2 oldPos;
    Vector2 newPos;

    float age = 0;
	// Use this for initialization
	void Start () {
        parent = transform.parent;
        oldPos = transform.position;
	}



   
    private void Update()
    {

        newPos = transform.position;

        if(Mathf.Abs(newPos.x-oldPos.x) > 1f)
        {
            children.Clear();

        }


        foreach (var child in children)
        {
            child.transform.Translate(new Vector2(newPos.x - oldPos.x, 0));

        }

        oldPos = newPos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if(collision.gameObject.tag == "Player" || collision.gameObject.tag == "Ground")
      
            children.Add(collision.gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
      
            
           children.Remove(collision.gameObject);
    }

   
}
