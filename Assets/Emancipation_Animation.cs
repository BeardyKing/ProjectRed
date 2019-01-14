using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emancipation_Animation : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //show the UI
        GetComponent<Animator>().SetBool("ON", true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //hide the UI
        GetComponent<Animator>().SetBool("ON", false);

    }
}
