using UnityEngine;
using System.Collections;

public class GUIScript : MonoBehaviour {

    void OnGUI()
    {
        //Start Airplane


        
        if(GUI.Button(new Rect(10, 10, 200,40),"Start left engine")){

        }

        
        if(GUI.Button(new Rect(Screen.width-210, 10, 200,40),"Start right engine")){

        }
    }
}
