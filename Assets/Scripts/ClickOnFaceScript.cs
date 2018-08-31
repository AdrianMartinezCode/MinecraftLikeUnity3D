using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickOnFaceScript : MonoBehaviour {

    public Vector3 delta;

    public void OnMouseOver()
    {
        
        
        if (Input.GetMouseButtonDown(0)) {
            Debug.Log("Left click");
            Destroy(this.transform.parent.gameObject);
        }
        if (Input.GetMouseButtonDown(1)) {
            Debug.Log("Right click");
            WorldGenerator.CloneAndPlace(this.transform.parent.transform.position + delta, this.transform.parent.gameObject);
        }
    }

    /*void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)) {
            Debug.Log(Camera.current);

            //Ray castPoint = Camera.main.ScreenPointToRay(new Vector3(Screen.width/2, Screen.height/2, 0));
            Ray castPoint = GameObject.Find("MainCamera").GetComponent<Camera>().ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));



            RaycastHit hit;
            if (Physics.Raycast(castPoint, out hit, Mathf.Infinity))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Debug.Log("Left click");
                    Destroy(this.transform.parent.gameObject);
                }
                if (Input.GetMouseButtonDown(1))
                {
                    Debug.Log("Right click");
                    WorldGenerator.CloneAndPlace(this.transform.parent.transform.position + delta, this.transform.parent.gameObject);
                }
            }
        }
        
    }*/
}
