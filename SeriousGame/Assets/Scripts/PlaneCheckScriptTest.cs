using UnityEngine;
using System.Collections;

public class PlaneCheckScriptTest : MonoBehaviour
{

    Animator anim;

    public bool rightEngineBroken;
    public bool leftEngineBroken;
    public bool leftEngineOilLeak;
    public bool rightEngineOilLeak;
    public bool leftFlapBroken;
    public bool rightFlapBroken;
    public bool centerEngineOilLeak;
    public bool centerEngineBroken;

    Vector3 hangarPosition;
    Vector3 dispatchPosition;

    bool rightEngineStart = false;
    bool leftEngineStart = false;
    bool rightFlapStart = false;
    bool leftFlapStart = false;
    bool centerEngineStart = false;

    bool dispatch = false;
    bool endGame = false;

    bool leftEngineConfirm = false;
    bool rightEngineConfirm = false;
    bool rightFlapConfirm = false;
    bool leftFlapConfirm = false;
    bool centerEngineConfirm = false;

    // Use this for initialization
    void Start ()
    {
        anim = GetComponent<Animator>();
        dispatchPosition = new Vector3(-70f, transform.position.y, 110f);
        hangarPosition = new Vector3(-45, transform.position.y, -35);
    }

    // Update is called once per frame
    void Update ()
    {

    }

    void StartAirplane ()
    {
        StartLeftEngine();
        StartRightEngine();
    }

    void StartLeftEngine ()
    {
        if(tag == "C130")
        {
            anim.SetBool("leftEngine", true);
        } else
		{
			ParticleRenderer s = (ParticleRenderer)transform.Find("Effects/LeftEngine").GetComponent<ParticleRenderer>();
            s.particleEmitter.emit = true;
            //s.enabled = true;
		}
        if(leftEngineBroken)
        {
            ParticleSystem s = (ParticleSystem)transform.Find("Effects/LeftEngineSmoke").GetComponent<ParticleSystem>();
            s.Play();
        }
        if(leftEngineOilLeak)
        {
            ParticleSystem s = (ParticleSystem)transform.Find("Effects/LeftEngineOilLeak").GetComponent<ParticleSystem>();
            s.Play();
        }
    }

    void StartRightEngine ()
    {
        if(tag == "C130")
        {
            anim.SetBool("rightEngine", true);
		} else
		{
			ParticleRenderer s = (ParticleRenderer)transform.Find("Effects/RightEngine").GetComponent<ParticleRenderer>();
            s.particleEmitter.emit = true;
		}
        if(rightEngineBroken)
        {
            ParticleSystem s = (ParticleSystem)transform.Find("Effects/RightEngineSmoke").GetComponent<ParticleSystem>();
            s.Play();
        }
        if(rightEngineOilLeak)
        {
            ParticleSystem s = (ParticleSystem)transform.Find("Effects/RightEngineOilLeak").GetComponent<ParticleSystem>();
            s.Play();
        }
    }

    void StopLeftEngine ()
    {
        if(tag == "C130")
        {
            anim.SetBool("leftEngine", false);
		} else
		{
			ParticleRenderer s = (ParticleRenderer)transform.Find("Effects/LeftEngine").GetComponent<ParticleRenderer>();
            s.particleEmitter.emit = false;
			//s.enabled = false;
		}
        if(leftEngineBroken)
        {
            ParticleSystem s = (ParticleSystem)transform.Find("Effects/LeftEngineSmoke").GetComponent<ParticleSystem>();
            s.Stop();
        }
        if(leftEngineOilLeak)
        {
            ParticleSystem s = (ParticleSystem)transform.Find("Effects/LeftEngineOilLeak").GetComponent<ParticleSystem>();
            s.Stop();
        }
    }

    void StopRightEngine ()
    {
        if(tag == "C130")
        {
            anim.SetBool("rightEngine", false);
		} else
		{
			ParticleRenderer s = (ParticleRenderer)transform.Find("Effects/RightEngine").GetComponent<ParticleRenderer>();
            s.particleEmitter.emit = false;
		}
        if(rightEngineBroken)
        {
            ParticleSystem s = (ParticleSystem)transform.Find("Effects/RightEngineSmoke").GetComponent<ParticleSystem>();
            s.Stop();
        } 
        if(rightEngineOilLeak)
        {

            ParticleSystem s = (ParticleSystem)transform.Find("Effects/RightEngineOilLeak").GetComponent<ParticleSystem>();
            s.Stop();
        }
    }

    void StartCenterEngine ()
    {
        anim.SetBool("centerEngine", true);
        if(centerEngineBroken)
        {
            ParticleSystem s = (ParticleSystem)transform.Find("Effects/CenterEngineSmoke").GetComponent<ParticleSystem>();
            s.Play();
        }
        if(centerEngineOilLeak)
        {
            ParticleSystem s = (ParticleSystem)transform.Find("Effects/CenterEngineOilLeak").GetComponent<ParticleSystem>();
            s.Play();
        }
    }
    void StopCenterEngine ()
    {
        anim.SetBool("centerEngine", false);
        if(centerEngineBroken)
        {
            ParticleSystem s = (ParticleSystem)transform.Find("Effects/CenterEngineSmoke").GetComponent<ParticleSystem>();
            s.Stop();
        }
        if(centerEngineOilLeak)
        {
            ParticleSystem s = (ParticleSystem)transform.Find("Effects/CenterEngineOilLeak").GetComponent<ParticleSystem>();
            s.Stop();
        }
    }

    void ShowButtons ()
    {

    }

    IEnumerator dispatchPlane ()
    {
		GetComponent<FadeObjectInOut> ().FadeOut();
        while(transform.position != dispatchPosition)
        {
			if(tag == "Cessna")
			{
				StartCenterEngine();
			} else if(tag == "C130")
			{
				StartLeftEngine();
				StartRightEngine();
			} else if (tag == "Learjet60")
			{
				StartLeftEngine();
				StartRightEngine();
			}
            transform.forward = Vector3.Slerp(transform.forward, (dispatchPosition - transform.position), Time.deltaTime / 10);
            transform.position += transform.forward * Time.deltaTime / 2;
            if(Vector3.Distance(transform.position, dispatchPosition) < 5)
            {
                transform.position = dispatchPosition;
            }
            yield return null;
        }
        yield return null;
    }

    IEnumerator sendToHangar ()
    {
		GetComponent<FadeObjectInOut> ().FadeOut();
        while(transform.position != hangarPosition)
        {
            transform.forward = Vector3.Slerp(transform.forward, (hangarPosition - transform.position), Time.deltaTime / 10);
            transform.forward.Normalize();
            transform.position += transform.forward * Time.deltaTime / 2;
            if(Vector3.Distance(transform.position, hangarPosition) < 5)
            {
                transform.position = hangarPosition;
            }
            yield return null;
        }
        yield return null;
    }

    void OnGUI ()
    {
        if(!leftEngineStart && !rightEngineStart && !leftFlapStart && !rightFlapStart && !centerEngineStart && !endGame)
        {
            if(!rightEngineConfirm && tag != "Cessna")
            {
                if(GUI.Button(new Rect(Screen.width / 2 - 205, Screen.height - 50, 200, 40), "Start right engine"))
                {
                    StartRightEngine();
                    rightEngineStart = true;
                }
            }
            if(!leftEngineConfirm && tag != "Cessna")
            {
                if(GUI.Button(new Rect(Screen.width / 2 + 5, Screen.height - 50, 200, 40), "Start left engine"))
                {
                    StartLeftEngine();
                    leftEngineStart = true;
                }
            }
            if(!centerEngineConfirm && tag == "Cessna")
            {
                if(GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height - 50, 200, 40), "Start center engine"))
                {
                    StartCenterEngine();
                    centerEngineStart = true;
                }
            }
            if(!rightFlapConfirm && tag == "Learjet60")
            {
                if(GUI.Button(new Rect(Screen.width / 2 - 205, Screen.height - 95, 200, 40), "Right flap"))
                {
                    rightFlapStart = true;
                    if(!rightFlapBroken)
                    {
                        anim.SetBool("rightFlap", true);
                    }
                }
            }
            if(!leftFlapConfirm && tag == "Learjet60")
            {
                if(GUI.Button(new Rect(Screen.width / 2 + 5, Screen.height - 95, 200, 40), "Left flap"))
                {
                    leftFlapStart = true;
                    if(!leftFlapBroken)
                    {
                        anim.SetBool("leftFlap", true);
                    }
                }
            }
            if(tag == "Learjet60")
            {
                if(leftFlapConfirm && leftEngineConfirm && rightEngineConfirm && rightFlapConfirm)
                {
                    if(GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height - 50, 200, 40), "Dispatch"))
                    {
                        dispatch = true;
                        endGame = true;
                    }
                }
            } else if(tag == "Cessna")
            {
                if(centerEngineConfirm)
                {
                    if(GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height - 50, 200, 40), "Dispatch"))
                    {
                        dispatch = true;
                        endGame = true;
                    }
                }
            } else if(tag == "C130")
            {
                if(leftEngineConfirm && rightEngineConfirm)
                {
                    if(GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height - 50, 200, 40), "Dispatch"))
                    {
                        dispatch = true;
                        endGame = true;
                    }
                }
            }
        }
        if((leftEngineStart || rightEngineStart || leftFlapStart || rightFlapStart || centerEngineStart) && !endGame)
        {
            if(GUI.Button(new Rect(Screen.width / 2 + 5, Screen.height - 50, 200, 40), "Confirm"))
            {
                if(leftEngineStart)
                {
                    leftEngineConfirm = true;
                    leftEngineStart = false;
                    StopLeftEngine();
                }
                if(rightEngineStart)
                {
                    rightEngineConfirm = true;
                    rightEngineStart = false;
                    StopRightEngine();
                }
                if(leftFlapStart)
                {
                    leftFlapConfirm = true;
                    anim.SetBool("leftFlap", false);
                    leftFlapStart = false;
                }
                if(rightFlapStart)
                {
                    rightFlapConfirm = true;
                    anim.SetBool("rightFlap", false);
                    rightFlapStart = false;
                }
                if(centerEngineStart)
                {
                    centerEngineConfirm = true;
                    centerEngineStart = false;
                    StopCenterEngine();
                }
            }
            if(GUI.Button(new Rect(Screen.width / 2 - 205, Screen.height - 50, 200, 40), "Something is wrong.\nSend to hangar"))
            {
                endGame = true;
            }
        }
        if(endGame)
        {
            string message;
            if(dispatch)
            {
                StartCoroutine("dispatchPlane");
                if(leftFlapBroken || rightFlapBroken || leftEngineOilLeak || rightEngineOilLeak || rightEngineBroken || leftEngineBroken || centerEngineBroken || centerEngineOilLeak)
                {
                    message = "The plane was broken, \nbut you dispatched it. \nIt crashed...";

                } else
                {
                    message = "The plane was not broken. \nYou made the right decision!";
                }
            } else
            {
                StartCoroutine("sendToHangar");
                if(leftFlapBroken || rightFlapBroken || leftEngineOilLeak || rightEngineOilLeak || rightEngineBroken || leftEngineBroken || centerEngineBroken || centerEngineOilLeak)
                {
                    message = "The plane was broken. \nYou made the right decision!";
                } else
                {
                    message = "The plane was not broken, \nbut you sent it to the hangar.";
                }
            }

            GUI.Box(new Rect(Screen.width / 2 - 100, Screen.height / 2, 200, 100), message);
            if(GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 110, 200, 50), "Next plane"))
            {
                GameObject.Destroy(this.gameObject);
                GameObject.Find("InitScript").GetComponent<GeneratePlane>().generatePlane();
            }
        }

    }
}
