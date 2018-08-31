using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Vector3Int
{
    public int x, y, z;
    public Vector3Int(int x, int y, int z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }
}

public class WorldData : MonoBehaviour {

    //public 
    public int chunkWidth, chunkHeight, chunkDepth;
    public int chunksX, chunksY, chunksZ;

    public Chunk[,,] chunks;
    public int radiusWorldChunkX, radiusWorldChunkY, radiusWorldChunkZ;

    private void InitVariables()
    {
        chunkWidth = chunkHeight = chunkDepth = 16;
        chunksX = chunksY = chunksZ = 8;
        radiusWorldChunkX = chunksX / 2;
    }

    private Vector3Int GetRealChunkCoords(int x, int y, int z)
    {
        return new Vector3Int(x - radiusWorldChunkX, y - radiusWorldChunkY, z - radiusWorldChunkZ);
    }

    private void InitChunkGrid()
    {
        chunks = new Chunk[chunksX, chunksY, chunksZ];
        for (int x = 0; x < chunksX; x++)
        {
            for (int y = 0; y < chunksY; y++)
            {
                for (int z = 0; z < chunksZ; z++)
                {
                    chunks[x, y, z] = new Chunk();
                    chunks[x, y, z].AssignCoords(GetRealChunkCoords(x,y,z));
                }
            }
        }
    }

    // Use this for initialization
    void Start () {
        InitVariables();
        InitChunkGrid();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
