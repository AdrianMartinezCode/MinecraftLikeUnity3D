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

    private int id;
    private CubeQuadsInfo quadsInfo;
    private Chunk parentChunk;
    private Vector3 position;
    

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    /*public Cube(int id)
    {
        this.id = id;
    }*/

    public int Id
    {
        get { return id; }
        set { id = value; }
    }

    public CubeQuadsInfo QuadsInfo
    {
        get
        {
            return quadsInfo;
        }

        set
        {
            quadsInfo = value;
        }
    }

    public Chunk ParentChunk
    {
        get
        {
            return parentChunk;
        }

        set
        {
            parentChunk = value;
        }
    }

    public Vector3 Position
    {
        get
        {
            return position;
        }

        set
        {
            position = value;
        }
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
