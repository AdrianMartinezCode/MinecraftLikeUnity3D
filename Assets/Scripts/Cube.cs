using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube {

    /*
     *  ID  -   Name
     *  ----------------------
     *  0   -   Air
     *  1   -   Rock
     * 
     */

    public int id;

    public Cube(int id)
    {
        this.id = id;
    }

    public int Id
    {
        get { return id; }
        set { id = value; }
    }

    public bool IsTransparentCube()
    {
        return id == 0;
    }

    public bool IsNotRenderCube()
    {
        return id == 0;
    }
}
