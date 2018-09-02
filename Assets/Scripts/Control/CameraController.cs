using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public float velX, velY;

    float axisX, axisY;

    void OnGUI()
    {
        //GUILayout.



        GUILayout.BeginArea(new Rect(20, 20, 250, 120));
        GUILayout.Label("Mouse position: [" + axisX + "," + axisY + "]");
        GUILayout.Label("World position: " + transform.position.ToString("F3"));

        GUILayout.EndArea();
    }

    // Use this for initialization
    void Start () {
        axisX = 0;
        axisY = 0;
        Cursor.lockState = CursorLockMode.Locked;
    }

    
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Escape))
        {
            if (Cursor.lockState == CursorLockMode.Locked)
                Cursor.lockState = CursorLockMode.None;
            else
                Cursor.lockState = CursorLockMode.Locked;
        }

        if (Cursor.lockState == CursorLockMode.Locked)
        {
            axisX += velX * Input.GetAxis("Mouse X");
            axisY -= velY * Input.GetAxis("Mouse Y");


            transform.eulerAngles = new Vector3(axisY, axisX, 0.0f);
        }

        //transform.direc
        //Physics.Raycast(transform.position, transform.forward);
    }

}
