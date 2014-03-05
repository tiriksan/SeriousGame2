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
			GUI.Box(new Rect(0,0,Screen.width,Screen.height),"\n\nAIRCRAFT STARTUP\n\nThe point of the game is to " +
				"check the aircrafts for any errors before dispatch. " +
			        "\nUse the buttons on the bottom of the screen to issue commands to the pilot,\n " +
				"and press and hold the right mouse button to look around the aircraft.");
			if (GUI.Button (new Rect (Screen.width / 2 - 50, Screen.height / 2 + 40, 100, 30), "Start Game"))
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
