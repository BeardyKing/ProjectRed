using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmancipationGrid : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            ClearFrozenObjects();
        }
    }


    void ClearFrozenObjects()
    {
        StaticData.FrozenObjectOne = null;
        StaticData.FrozenObjectTwo = null;
    }
}
