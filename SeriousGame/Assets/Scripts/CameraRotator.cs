using UnityEngine;
using System.Collections;

public class CameraRotator : MonoBehaviour {


	float yRot = 0;

    public Vector3 distanceVector;

	// Use this for initialization
	void Start () {
        Camera.main.transform.position = Camera.main.transform.parent.transform.position + distanceVector;
	}
	
	// Update is called once per frame
	void Update () {
        checkInput();
        transform.rotation = Quaternion.Euler(new Vector3(0, yRot, 0));
        Camera.main.transform.forward = transform.position - Camera.main.transform.position;
	}


    void checkInput(){
        if(Input.GetMouseButton(1)){
            yRot += Input.GetAxis("Mouse X");
        }
    }
}
