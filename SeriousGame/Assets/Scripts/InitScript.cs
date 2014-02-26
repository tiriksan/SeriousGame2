using UnityEngine;
using System.Collections;

public class InitScript : MonoBehaviour {

	public GameObject airbase;
	public GameObject cameraRotator;
	public GameObject light;
    public GeneratePlane genPlane;
	private bool menuVisible = true;

	void menuStart()
	{
		genPlane.generatePlane();
	}

	void OnGUI()
	{
		if (menuVisible == true)
		{
			GUI.Box(new Rect(0,0,Screen.width,Screen.height),"Aircraft startup\nThe point of the game is to check the aircrafts for any errors before dispatch.");
			if (GUI.Button (new Rect (Screen.width / 2 - 50, Screen.height / 2 - 50, 100, 30), "Start Game"))
			{
				menuStart();
				menuVisible = false;
			}
		}
	}

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
