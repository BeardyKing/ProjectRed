using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinecartScript : MonoBehaviour {
    
    public GameObject leftStop;
    public GameObject rightStop;
    [Range(1,10)]
    public float speed;
    float xDir;
    public bool on;

    public bool  onTracks;

    public GeneratorScript generator;

	// Use this for initialization
	void Start () {
        xDir = speed;

	}
	
	// Update is called once per frame
	void FixedUpdate () {
        on = generator.on;

       
       
	}

    private void LateUpdate()
    {
        if (on && onTracks)
        {
            move();
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="tracks"){
            onTracks = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "tracks")
        {
            onTracks = false;
        }
    }




    private void move()
    {
        
        Vector2 pos = transform.position;
        pos.x += xDir * Time.deltaTime;
        transform.position = pos;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject == leftStop || collision.gameObject == rightStop){
            xDir *= -1;
        }
    }
}
