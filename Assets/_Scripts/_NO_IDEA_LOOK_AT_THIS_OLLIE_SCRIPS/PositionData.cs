using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionData : MonoBehaviour
{
    public Vector2[] timePositions = new Vector2[3];



    public void setPosition(int pos, Vector2 point)
    {
        timePositions[pos] = point;
    }

}



