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
			GUI.Box(new Rect(0,0,Screen.width,Screen.height),"\n\n\n\n\n\nSUPERVISING AIRCRAFT STARTUP\n\n\n\n\nThe point of the game is to " +
				"check the aircrafts for any errors before dispatch. " +
			        "\n\nUse the buttons on the bottom of the screen to issue commands to the pilot,\n\n " +
			        "and press and hold the right mouse button to look around the aircraft.\n\n\n\nPress 'Esc' to quit.");
			if (GUI.Button (new Rect (Screen.width / 2 - 50, Screen.height / 2 + 70, 100, 30), "Start Game"))
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
		if(Input.GetKeyDown("escape")) {//When a key is pressed down it see if it was the escape key if it was it will execute the code
			Application.Quit(); // Quits the game
		}
	}
}
