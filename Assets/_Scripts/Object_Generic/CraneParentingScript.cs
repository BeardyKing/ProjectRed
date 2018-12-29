using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraneParentingScript : MonoBehaviour {



    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.transform.SetParent(transform);

        //fix this 
        collision.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.transform.SetParent(null);
    }
}
