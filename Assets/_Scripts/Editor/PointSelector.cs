
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PositionData))]
public class PointSelector : Editor {

    public override void OnInspectorGUI()
    {
        PositionData other = (PositionData)target;
        if (GUILayout.Button("Set Position 1") || Input.GetKeyDown("1"))
        {

            other.setPosition(0, other.gameObject.transform.position);
        }
        GUILayout.Label("X: "+other.timePositions[0].x+" Y: "+ other.timePositions[0].y);

        if (GUILayout.Button("Set Position 2") || Input.GetKeyDown("1"))
        {
            other.setPosition(1, other.gameObject.transform.position);
            
        }
        GUILayout.Label("X: " + other.timePositions[1].x + " Y: " + other.timePositions[1].y);

        if (GUILayout.Button("Set Position 3") || Input.GetKeyDown("1"))
        {
            other.setPosition(2, other.gameObject.transform.position);
         

        }
        GUILayout.Label("X: " + other.timePositions[2].x + " Y: " + other.timePositions[2].y);

        base.OnInspectorGUI();
    }



}
