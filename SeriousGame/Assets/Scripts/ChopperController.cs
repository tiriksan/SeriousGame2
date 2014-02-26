using UnityEngine;
using System.Collections;

public class ChopperController : MonoBehaviour {


    Animator anim;
    CharacterController cc;

    float throt = 0;

    public float maxUpSpeed = 20;
    Vector3 gravity = Physics.gravity;

	// Use this for initialization
	void Start () {
        this.cc = GetComponent<CharacterController>();
        this.anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        checkInput();
        anim.SetFloat("Speed", throt);
        move();
	}

    void checkInput()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            throt += Time.deltaTime;
            if (throt > 1)
            {
                throt = 1;
            }
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            throt -= Time.deltaTime;
            if (throt < 0)
            {
                throt = 0;
            }
        }
        float hori = Input.GetAxis("Horizontal");
        float verti = Input.GetAxis("Vertical");


        transform.RotateAround(Vector3.up, hori * Time.deltaTime);
        transform.Rotate(Vector3.left, -verti);

        gravity += (Physics.gravity + transform.up * throt * maxUpSpeed) * Time.deltaTime;
        if (gravity.y > Physics.gravity.y)
        {
            gravity = Physics.gravity;
        }
        if (cc.isGrounded)
        {
            gravity = Physics.gravity;
        }


    }

    void move()
    {
        Debug.Log(transform.up * throt * maxUpSpeed + Physics.gravity + "");
        cc.Move((transform.up*throt * maxUpSpeed + gravity) * Time.deltaTime);
    }


    void OnGUI()
    {
        GUI.Label(new Rect(0,0,100,20), throt+"");
    }
}
