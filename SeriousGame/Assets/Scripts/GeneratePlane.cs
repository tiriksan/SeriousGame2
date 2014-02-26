using UnityEngine;
using System.Collections;
using System;

public class GeneratePlane : MonoBehaviour
{

    public GameObject[] planes;
    public float chanceToGetError; //in %

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
        System.Random rng = new System.Random();
        int rnd = rng.Next(0, 100);
        Debug.Log("Chance for error: " + chanceToGetError + ", rnd: " + rnd); 
        if(rnd < chanceToGetError)
        {
            //set random error
            if(plane.tag == "Cessna")
            {
                int error = rng.Next(0, 2);
                switch(error)
                {
                    case 0:
                        plane.centerEngineOilLeak = true;
                        break;
                    case 1:
                        plane.centerEngineBroken = true;
                        break;

                }
            } else if(plane.tag == "C130")
            {
                int error = rng.Next(0, 4);
                switch(error)
                {
                    case 0:
                    plane.leftEngineOilLeak = true;
                    break;
                    case 1:
                    plane.leftEngineBroken = true;
                    break;
                    case 2:
                    plane.rightEngineOilLeak = true;
                    break;
                    case 3:
                    plane.rightEngineBroken = true;
                    break;
                }
            } else if(plane.tag == "Learjet60")
            {
                int error = rng.Next(0, 6);
                switch(error)
                {
                    case 0:
                    plane.leftEngineBroken = true;
                    break;
                    case 1:
                    plane.rightEngineBroken = true;
                    break;
                    case 2:
                    plane.leftEngineOilLeak = true;
                    break;
                    case 3:
                    plane.rightEngineOilLeak = true;
                    break;
                    case 4:
                    plane.rightFlapBroken = true;
                    break;
                    case 5:
                    plane.leftFlapBroken = true;
                    break;

                }
            }
        }
    }
}
