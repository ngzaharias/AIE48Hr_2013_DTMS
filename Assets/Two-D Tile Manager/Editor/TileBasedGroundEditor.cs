using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TwoDimensionTileHelper))] 
public class TileBasedGroundEditor : Editor
{
    private bool _defaultsSet = false;
    
    public override void OnInspectorGUI()
    {
        var myTarget = (TwoDimensionTileHelper)target;

        if (!myTarget.DefaultsSet)
        {
            //Clone Horizontal
            myTarget.CloneHorizontalX = (int)myTarget.gameObject.transform.localScale.x;
            myTarget.CloneHorizontalY = 0;
            myTarget.CloneHorizontalZ = 0;
            //Clone Vertical
            myTarget.CloneVerticalX = 0;
            myTarget.CloneVerticalY = (int)myTarget.gameObject.transform.localScale.y;
            myTarget.CloneVerticalZ = 0;
            //Nudge Horizontal
            myTarget.NudgeHorizontalX = (int)myTarget.gameObject.transform.localScale.x;
            myTarget.NudgeHorizontalY = 0;
            myTarget.NudgeHorizontalZ = 0;
            //Nudge Vertical
            myTarget.NudgeVerticalX = 0;
            myTarget.NudgeVerticalY = (int)myTarget.gameObject.transform.localScale.y;
            myTarget.NudgeVerticalZ = 0;
            myTarget.DefaultsSet = true;
        }

        //CLONING
        GUILayout.Label("Cloning");
        myTarget.ShowCloneHorizontals = EditorGUILayout.Foldout(myTarget.ShowCloneHorizontals, "Horizontal Shifts");
        if (myTarget.ShowCloneHorizontals)
        {
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Swap X and Z"))
            {
                var holder = myTarget.CloneHorizontalX;
                myTarget.CloneHorizontalX = myTarget.CloneHorizontalZ;
                myTarget.CloneHorizontalZ = holder;
            }
            if (GUILayout.Button("Invert X and Z"))
            {
                myTarget.CloneHorizontalX = -myTarget.CloneHorizontalX;
                myTarget.CloneHorizontalZ = -myTarget.CloneHorizontalZ;
            }
            GUILayout.EndHorizontal();
            myTarget.CloneHorizontalX = EditorGUILayout.IntSlider("    X Shift:", myTarget.CloneHorizontalX, -100, 100);
            myTarget.CloneHorizontalY = EditorGUILayout.IntSlider("    Y Shift:", myTarget.CloneHorizontalY, -100, 100);
            myTarget.CloneHorizontalZ = EditorGUILayout.IntSlider("    Z Shift:", myTarget.CloneHorizontalZ, -100, 100);
        }
        myTarget.ShowCloneVerticals = EditorGUILayout.Foldout(myTarget.ShowCloneVerticals, "Vertical Shifts");
        if (myTarget.ShowCloneVerticals)
        {
            myTarget.CloneVerticalX = EditorGUILayout.IntSlider("    X Shift:", myTarget.CloneVerticalX, -100, 100);
            myTarget.CloneVerticalY = EditorGUILayout.IntSlider("    Y Shift:", myTarget.CloneVerticalY, -100, 100);
            myTarget.CloneVerticalZ = EditorGUILayout.IntSlider("    Z Shift:", myTarget.CloneVerticalZ, -100, 100);
        }

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Left"))
        {
            var targetPosition = myTarget.gameObject.transform.position;
            myTarget.gameObject.transform.position = new Vector3(targetPosition.x - myTarget.CloneHorizontalX, targetPosition.y - myTarget.CloneHorizontalY, targetPosition.z - myTarget.CloneHorizontalZ);
            var newbie = (GameObject) Instantiate(myTarget.gameObject, new Vector3(targetPosition.x, targetPosition.y, targetPosition.z), myTarget.gameObject.transform.rotation);
            newbie.transform.parent = myTarget.gameObject.transform.parent;
            newbie.name = myTarget.gameObject.name;
        }
        if (GUILayout.Button("Right"))
        {
            var targetPosition = myTarget.gameObject.transform.position;
            myTarget.gameObject.transform.position = new Vector3(targetPosition.x + myTarget.CloneHorizontalX, targetPosition.y + myTarget.CloneHorizontalY, targetPosition.z + myTarget.CloneHorizontalZ);
            var newbie = (GameObject)Instantiate(myTarget.gameObject, new Vector3(targetPosition.x, targetPosition.y, targetPosition.z), myTarget.gameObject.transform.rotation);
            newbie.transform.parent = myTarget.gameObject.transform.parent;
            newbie.name = myTarget.gameObject.name;
        }
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Down"))
        {
            var targetPosition = myTarget.gameObject.transform.position;
            myTarget.gameObject.transform.position = new Vector3(targetPosition.x - myTarget.CloneVerticalX, targetPosition.y - myTarget.CloneVerticalY, targetPosition.z - myTarget.CloneVerticalZ);
            var newbie = (GameObject)Instantiate(myTarget.gameObject, new Vector3(targetPosition.x, targetPosition.y, targetPosition.z), myTarget.gameObject.transform.rotation);
            newbie.transform.parent = myTarget.gameObject.transform.parent;
            newbie.name = myTarget.gameObject.name;
        }
        if (GUILayout.Button("Up"))
        {
            var targetPosition = myTarget.gameObject.transform.position;
            myTarget.gameObject.transform.position = new Vector3(targetPosition.x + myTarget.CloneVerticalX, targetPosition.y + myTarget.CloneVerticalY, targetPosition.z + myTarget.CloneVerticalZ);
            var newbie = (GameObject)Instantiate(myTarget.gameObject, new Vector3(targetPosition.x, targetPosition.y, targetPosition.z), myTarget.gameObject.transform.rotation);
            newbie.transform.parent = myTarget.gameObject.transform.parent;
            newbie.name = myTarget.gameObject.name;
        }
        GUILayout.EndHorizontal();


        //MOVING
        GUILayout.Label("Moving");
        myTarget.ShowNudgeHorizonals = EditorGUILayout.Foldout(myTarget.ShowNudgeHorizonals, "Horizontal Shifts");
        if (myTarget.ShowNudgeHorizonals)
        {
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Swap X and Z"))
            {
                var holder = myTarget.NudgeHorizontalX;
                myTarget.NudgeHorizontalX = myTarget.NudgeHorizontalZ;
                myTarget.NudgeHorizontalZ = holder;
            }
            if (GUILayout.Button("Invert X and Z"))
            {
                myTarget.NudgeHorizontalX = -myTarget.NudgeHorizontalX;
                myTarget.NudgeHorizontalZ = -myTarget.NudgeHorizontalZ;
            }
            GUILayout.EndHorizontal();
            myTarget.NudgeHorizontalX = EditorGUILayout.IntSlider("    X Shift:", myTarget.NudgeHorizontalX, -100, 100);
            myTarget.NudgeHorizontalY = EditorGUILayout.IntSlider("    Y Shift:", myTarget.NudgeHorizontalY, -100, 100);
            myTarget.NudgeHorizontalZ = EditorGUILayout.IntSlider("    Z Shift:", myTarget.NudgeHorizontalZ, -100, 100);
        }
        myTarget.ShowNudgeVerticals = EditorGUILayout.Foldout(myTarget.ShowNudgeVerticals, "Vertical Shifts");
        if (myTarget.ShowNudgeVerticals)
        {
            myTarget.NudgeVerticalX = EditorGUILayout.IntSlider("    X Shift:", myTarget.NudgeVerticalX, -100, 100);
            myTarget.NudgeVerticalY = EditorGUILayout.IntSlider("    Y Shift:", myTarget.NudgeVerticalY, -100, 100);
            myTarget.NudgeVerticalZ = EditorGUILayout.IntSlider("    Z Shift:", myTarget.NudgeVerticalZ, -100, 100);
        }
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Left"))
        {
            var targetPosition = myTarget.gameObject.transform.position;
            myTarget.gameObject.transform.position = new Vector3(targetPosition.x - myTarget.NudgeHorizontalX, targetPosition.y - myTarget.NudgeHorizontalY, targetPosition.z - myTarget.NudgeHorizontalZ);
        }
        if (GUILayout.Button("Right"))
        {
            var targetPosition = myTarget.gameObject.transform.position;
            myTarget.gameObject.transform.position = new Vector3(targetPosition.x + myTarget.NudgeHorizontalX, targetPosition.y + myTarget.NudgeHorizontalY, targetPosition.z + myTarget.NudgeHorizontalZ);
        }
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Down"))
        {
            var targetPosition = myTarget.gameObject.transform.position;
            myTarget.gameObject.transform.position = new Vector3(targetPosition.x - myTarget.NudgeVerticalX, targetPosition.y - myTarget.NudgeVerticalY, targetPosition.z - myTarget.NudgeVerticalZ);
        }
        if (GUILayout.Button("Up"))
        {
            var targetPosition = myTarget.gameObject.transform.position;
            myTarget.gameObject.transform.position = new Vector3(targetPosition.x + myTarget.NudgeVerticalX, targetPosition.y + myTarget.NudgeVerticalY, targetPosition.z + myTarget.NudgeVerticalZ);
        }
        GUILayout.EndHorizontal();
    }
}