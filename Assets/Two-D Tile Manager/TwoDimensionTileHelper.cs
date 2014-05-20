using UnityEngine;
using System.Collections;

public class TwoDimensionTileHelper : MonoBehaviour
{
    public bool DefaultsSet;


    //Clone
    public bool ShowCloneHorizontals = false;
    public bool ShowCloneVerticals = false;

    //Verticals
    public bool ShowNudgeHorizonals = false;
    public bool ShowNudgeVerticals = false;

    //Cloning axis
    public int CloneHorizontalX = 0;
    public int CloneHorizontalY = 0;
    public int CloneHorizontalZ = 0;
    public int CloneVerticalX = 0;
    public int CloneVerticalY = 0;
    public int CloneVerticalZ = 0;

    //Moving axis
    public int NudgeHorizontalX = 0;
    public int NudgeHorizontalY = 0;
    public int NudgeHorizontalZ = 0;
    public int NudgeVerticalX = 0;
    public int NudgeVerticalY = 0;
    public int NudgeVerticalZ = 0;


	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update () {

	}
}
