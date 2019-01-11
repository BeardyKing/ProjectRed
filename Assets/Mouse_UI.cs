using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Mouse_UI : MonoBehaviour
{

    public GameObject Left;
    public GameObject Right;
    public FrozenObjects frozenObjects;


    private void Update()
    {
        if(StaticData.FrozenObjectOne != null)
        {
            Left.GetComponent<Image>().color = frozenObjects.colors[0];
        }
        else
        {
            Left.GetComponent<Image>().color = Color.white;
        }

        if (StaticData.FrozenObjectTwo != null)
        {
            Right.GetComponent<Image>().color = frozenObjects.colors[1];
        }
        else
        {
            Right.GetComponent<Image>().color = Color.white;
        }
    }


}
