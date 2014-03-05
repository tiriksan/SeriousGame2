using UnityEngine;
using System.Collections;

public class CameraRotator : MonoBehaviour {

//test
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

		//------------------Code for Zooming Out------------
		if (Input.GetAxis("Mouse ScrollWheel") <0)
		{
			if (Camera.main.fieldOfView<=100)
				Camera.main.fieldOfView +=5;
			if (Camera.main.orthographicSize<=20)
				Camera.main.orthographicSize +=0.5f;
		}

		//----------------Code for Zooming In-----------------------
		if (Input.GetAxis("Mouse ScrollWheel") > 0)
		{
			if (Camera.main.fieldOfView>2)
				Camera.main.fieldOfView -=5;
			if (Camera.main.orthographicSize>=1)
				Camera.main.orthographicSize -=0.5f;
		}
	
	}


    void checkInput(){
        if(Input.GetMouseButton(1)){
            yRot += Input.GetAxis("Mouse X");
        }
    }
}
