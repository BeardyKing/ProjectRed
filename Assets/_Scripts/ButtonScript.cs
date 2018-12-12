using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour {

    public bool down;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag != "feet")
        down = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.tag != "feet")
            down = false;
    }


    private void Update()
    {
        transform.parent.GetComponent<Animator>().SetBool("down", down);
        print(down);
    }
}
