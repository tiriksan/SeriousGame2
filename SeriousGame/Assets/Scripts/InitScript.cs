using UnityEngine;
using System.Collections;

public class InitScript : MonoBehaviour {

	public GameObject airbase;
	public GameObject cameraRotator;
	public GameObject light;

	// Use this for initialization
	void Start () {
		GameObject.Instantiate(airbase);
		GameObject.Instantiate(cameraRotator);
		GameObject.Instantiate(light);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
