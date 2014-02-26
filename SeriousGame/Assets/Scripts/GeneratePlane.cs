using UnityEngine;
using System.Collections;
using System;

public class GeneratePlane : MonoBehaviour {

    public GameObject[] planes;
    public float chanceToGetError = 5; //in %

    public void generatePlane ()
    {
        //TODO
        System.Random rng = new System.Random();
        int planeNr = rng.Next(0, planes.Length);
        Debug.Log(planeNr);
        GameObject plane = (GameObject)GameObject.Instantiate(planes[planeNr]);
        generateErrors(plane.GetComponent<PlaneCheckScriptTest>());
    }

    void generateErrors (PlaneCheckScriptTest plane)
    {
        //TODO
    }
}
