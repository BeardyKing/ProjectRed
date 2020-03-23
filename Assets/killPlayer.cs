using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killPlayer : MonoBehaviour
{
    public Respawn respawn;



    private void Update()
    {

        PolygonCollider2D[] polys = GetComponents<PolygonCollider2D>();
        foreach (var item in polys)
        {
            item.isTrigger = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.gameObject.tag == "Player")
        {
            if(collision.gameObject.GetComponent<PlayerController>().playerState != "Respawn")
            respawn.die();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.GetComponent<PlayerController>().playerState != "Respawn")
                respawn.die();
        }
    }
}
