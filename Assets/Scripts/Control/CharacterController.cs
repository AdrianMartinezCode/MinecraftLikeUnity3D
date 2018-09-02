using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {

    public float vel;
    
	// Use this for initialization
	void Start () {
        
	}

    
	
	// Update is called once per frame
	void Update () {
        //GameObject.Find("MainCamera").gameObject<Camera>().
        if (Input.GetKeyDown(KeyCode.W))
        {

            Vector3 dir = Camera.main.transform.forward;
            transform.position = transform.position + dir*vel;
        }
        

	}

    void FixedUpdate()
    {
        
    }

    void Run()
    {
        
    }


}
