using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour {

    private int x, y, z;

    public void AssignCoords(Vector3Int v)
    {
        x = v.x;
        y = v.y;
        z = v.z;
    }

    public int X
    {
        get { return x;  }
        set { x = value; }
    }

    public int Y
    {
        get { return y; }
        set { y = value; }
    }

    public int Z
    {
        get { return z; }
        set { z = value; }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
