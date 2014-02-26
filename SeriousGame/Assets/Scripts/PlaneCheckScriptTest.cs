using UnityEngine;
using System.Collections;

public class PlaneCheckScriptTest : MonoBehaviour {

    Animator anim;

	public bool rightEngineBroken;
	public bool leftEngineBroken;
	public bool leftEngineOilLeak;
	public bool rightEngineOilLeak;
    public bool leftFlapBroken;
    public bool rightFlapBroken;

    bool rightEngineStart = false;
    bool leftEngineStart = false;
    bool rightFlapStart = false;
    bool leftFlapStart = false;

    bool dispatch = false;
    bool endGame = false;

    bool leftEngineConfirm = false;
    bool rightEngineConfirm = false;
    bool rightFlapConfirm = false;
    bool leftFlapConfirm = false;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void StartAirplane() {
		StartLeftEngine ();
		StartRightEngine ();
	}

	void StartLeftEngine () {
		if (leftEngineBroken) {
            ParticleSystem s = (ParticleSystem)transform.Find("Effects/LeftEngineSmoke").GetComponent<ParticleSystem>();
			s.Play();
		}
		if (leftEngineOilLeak) {
            ParticleSystem s = (ParticleSystem)transform.Find("Effects/LeftEngineOilLeak").GetComponent<ParticleSystem>();
			s.Play();
		}
	}

	void StartRightEngine () {
		if (rightEngineBroken) {
			ParticleSystem s = (ParticleSystem) transform.Find("Effects/RightEngineSmoke").GetComponent<ParticleSystem>();
			s.Play();
		}
		if (rightEngineOilLeak) {
			ParticleSystem s = (ParticleSystem) transform.Find("Effects/RightEngineOilLeak").GetComponent<ParticleSystem>();
			s.Play();
		}
	}

    void StopLeftEngine()
    {
        if (leftEngineBroken)
        {
            ParticleSystem s = (ParticleSystem)transform.Find("Effects/LeftEngineSmoke").GetComponent<ParticleSystem>();
            s.Stop();
        }
        if (leftEngineOilLeak)
        {
            ParticleSystem s = (ParticleSystem)transform.Find("Effects/LeftEngineOilLeak").GetComponent<ParticleSystem>();
            s.Stop();
        }
    }

    void StopRightEngine()
    {
        if (rightEngineBroken)
        {
            ParticleSystem s = (ParticleSystem)transform.Find("Effects/RightEngineSmoke").GetComponent<ParticleSystem>();
            s.Stop();
        }
        if (rightEngineOilLeak)
        {

            ParticleSystem s = (ParticleSystem)transform.Find("Effects/RightEngineOilLeak").GetComponent<ParticleSystem>();
            s.Stop();
        }
    }

	void ShowButtons () {

	}

	void dispatchPlane() {

	}

	void sendToHangar() {

	}

    

    void OnGUI()
    {
        if(!leftEngineStart && !rightEngineStart && !leftFlapStart && !rightFlapStart && !endGame){
            if (!rightEngineConfirm)
            {
                if (GUI.Button(new Rect(Screen.width / 2 - 205, Screen.height - 50, 200, 40), "Start right engine"))
                {
                    StartRightEngine();
                    rightEngineStart = true;
                }
            }
            if (!leftEngineConfirm)
            {
                if (GUI.Button(new Rect(Screen.width / 2 + 5, Screen.height - 50, 200, 40), "Start left engine"))
                {
                    StartLeftEngine();
                    leftEngineStart = true;
                }
            }
            if (!rightFlapConfirm)
            {
                if (GUI.Button(new Rect(Screen.width / 2 - 205, Screen.height - 95, 200, 40), "Right flap"))
                {
                    
                    rightFlapStart = true;
                    if (!rightFlapBroken)
                    {
                        anim.SetBool("rightFlap", true);
                    }

                }
            }
            if (!leftFlapConfirm)
            {
                if (GUI.Button(new Rect(Screen.width / 2 + 5, Screen.height - 95, 200, 40), "Left flap"))
                {
                    leftFlapStart = true;
                    if (!leftFlapBroken)
                    {
                        anim.SetBool("leftFlap", true);
                    }
                }
            }
            if (leftFlapConfirm && leftEngineConfirm && rightEngineConfirm && rightFlapConfirm)
            {
                if(GUI.Button(new Rect(Screen.width /2 - 100, Screen.height-50 , 200 , 40), "Dispatch")){
                    dispatch = true;
                    endGame = true;
                }
            }
        }

        if ((leftEngineStart || rightEngineStart || leftFlapStart || rightFlapStart) && !endGame)
        {
            if(GUI.Button(new Rect(Screen.width/2 + 5, Screen.height -50 , 200, 40), "Confirm")){
                if (leftEngineStart)
                {
                    leftEngineConfirm = true;
                    leftEngineStart = false;
                    StopLeftEngine();
                }
                if (rightEngineStart)
                {
                    rightEngineConfirm = true;
                    rightEngineStart = false;
                    StopRightEngine();
                }
                if (leftFlapStart)
                {
                    leftFlapConfirm = true;
                    anim.SetBool("leftFlap", false);
                    leftFlapStart = false;
                }
                if (rightFlapStart)
                {
                    rightFlapConfirm = true;
                    anim.SetBool("rightFlap", false);
                    rightFlapStart = false;
                }
            }
            if (GUI.Button(new Rect(Screen.width / 2 -205, Screen.height - 50, 200, 40), "Something is wrong.\nSend to hangar"))
            {
                endGame = true;
            }

        }
        if (endGame)
        {
            string message;
            if (dispatch)
            {
                if (leftFlapBroken || rightFlapBroken || leftEngineOilLeak || rightEngineOilLeak || rightEngineBroken || leftEngineBroken)
                {
                    message = "The plane was broken, \nbut you dispatched it. \nIt crashed...";

                }
                else
                {
                    message = "The plane was broken. \nYou made the right decision!";                    
                }
            }
            else
            {
                if (leftFlapBroken || rightFlapBroken || leftEngineOilLeak || rightEngineOilLeak || rightEngineBroken || leftEngineBroken)
                {
                    message = "The plane was broken. \nYou made the right decision!";
                }
                else
                {
                    message = "The plane was not broken, \nbut you sent it to the hangar.";
                }
            }

            GUI.Box(new Rect(Screen.width/2 - 100 , Screen.height/2 , 200 , 100), message);
            if(GUI.Button(new Rect(Screen.width/2 - 100, Screen.height/2 + 110, 200, 50), "Next plane")){
                //TODO:
                //Remove current plane
                //Spawn new plane
                //Generate errors
            }
        }

    }


    
}
