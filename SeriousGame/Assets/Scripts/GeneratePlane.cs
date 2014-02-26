using UnityEngine;
using System.Collections;

public class GeneratePlane : MonoBehaviour {

    public GameObject[] planes;

    public void generatePlane ()
    {
        //TODO
        GameObject.Instantiate(planes[0]);
    }
}
