using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdatePolyColider : MonoBehaviour {

    public SpriteRenderer rend;
    public Sprite last;
    float timer = 1f;
    bool beginTimer = false;
	// Use this for initialization
	void Start () {
        rend = GetComponent<SpriteRenderer>();
        last = rend.sprite;

        Destroy(GetComponent<PolygonCollider2D>());
        gameObject.AddComponent<PolygonCollider2D>();
    }
	
	// Update is called once per frame
	void Update () {
        if (rend.sprite != last || beginTimer == true) {
            last = rend.sprite;
            beginTimer = true;
            Destroy(GetComponent<PolygonCollider2D>());
            gameObject.AddComponent<PolygonCollider2D>();
           // Debug.Log("DOING A BIG UPDATE");
        }
        if (timer >= 0 && beginTimer == true) {
            timer -= Time.deltaTime;
            if (timer <= 0) {
                timer = 1f;
                beginTimer = false;
            }
            //Debug.Log("DOING A THING");
        }
    }
}
