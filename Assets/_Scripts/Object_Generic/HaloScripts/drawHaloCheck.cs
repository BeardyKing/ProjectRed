using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawHaloCheck : MonoBehaviour {

    public bool drawMultipleHalos;
	// Update is called once per frame
	void Update () {

        drawHaloN[] extraHalos = GetComponents<drawHaloN>();

        if (drawMultipleHalos)
        {

            for (int i = 0; i < extraHalos.Length; i++)
            {
                extraHalos[0].Line.gameObject.SetActive(true);

            }
        }
        else
        {

            for (int i = 0; i < extraHalos.Length; i++)
            {
                extraHalos[0].Line.gameObject.SetActive(false);

            }
        }
        
        
	}
}
