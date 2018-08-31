using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*public struct Vector3Int
{
    public int x, y, z;
    public Vector3Int(int x, int y, int z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }
}*/

public class WorldData : MonoBehaviour
{
    public readonly static int DEFAULT_CHUNK_SIZE = 16;
    public readonly static int NUM_CHUNKS = 4;
    public readonly static int SIZE_EDGE_CUBE = 1;

    // In cubes!
    public int chunkWidth = DEFAULT_CHUNK_SIZE, chunkHeight = DEFAULT_CHUNK_SIZE, chunkDepth = DEFAULT_CHUNK_SIZE;

    // In chunks!
    public int chunksX = NUM_CHUNKS, chunksY = NUM_CHUNKS, chunksZ = NUM_CHUNKS;

    // In measure unities
    public float sizeEdgeX = SIZE_EDGE_CUBE, sizeEdgeY = SIZE_EDGE_CUBE, sizeEdgeZ = SIZE_EDGE_CUBE;

    public Chunk[,,] chunks;
    public int radiusWorldChunkX, radiusWorldChunkY, radiusWorldChunkZ; // in chunks

    private void InitVariables()
    {
        //chunkWidth = chunkHeight = chunkDepth = 16;
        //chunksX = chunksY = chunksZ = 2;
        radiusWorldChunkX = chunksX / 2;
        radiusWorldChunkY = chunksY / 2;
        radiusWorldChunkZ = chunksZ / 2;
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
                    //chunks[x, y, z] = new Chunk();
                    GameObject chunk = GameObject.Instantiate<Chunk>()
                    //chunks[x, y, z].AssignCoords(GetRealChunkCoords(x,y,z));
                    chunks[x, y, z].Build(this, new Vector3Int(x, y, z), chunkWidth, chunkHeight, chunkDepth);
                }
            }
        }
    }

    // Use this for initialization
    public void Start () {
        InitVariables();
        InitChunkGrid();
    }
	
	// Update is called once per frame
	public void Update () {
		
	}
}
