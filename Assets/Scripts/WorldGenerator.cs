using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGenerator : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void CloneAndPlace(Vector3 newPosition, GameObject originalGameobject)
    {
        GameObject clone = (GameObject)Instantiate(originalGameobject, newPosition, Quaternion.identity);
        clone.transform.position = newPosition;
        clone.name = "Voxel@" + clone.transform.position;
    }
}
