using UnityEngine;
using System.Collections;

public class InitScript : MonoBehaviour {

	public GameObject airbase;
	public GameObject cameraRotator;
	public GameObject light;
    public GeneratePlane genPlane;

	// Use this for initialization
	void Start () {
		GameObject.Instantiate(airbase);
		GameObject.Instantiate(cameraRotator);
		GameObject.Instantiate(light);
        genPlane.generatePlane();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
