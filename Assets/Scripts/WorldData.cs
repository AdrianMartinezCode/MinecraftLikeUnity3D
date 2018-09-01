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
    public readonly static int NUM_CHUNKS = 1;
    public readonly static int SIZE_EDGE_CUBE = 1;

    // In cubes!
    public int chunkWidth = DEFAULT_CHUNK_SIZE, chunkHeight = DEFAULT_CHUNK_SIZE, chunkDepth = DEFAULT_CHUNK_SIZE;

    // In chunks! Global measurement
    public int chunksX = NUM_CHUNKS, chunksY = NUM_CHUNKS, chunksZ = NUM_CHUNKS;

    // In measure unities
    public float sizeEdgeX = SIZE_EDGE_CUBE, sizeEdgeY = SIZE_EDGE_CUBE, sizeEdgeZ = SIZE_EDGE_CUBE;

    public Chunk[,,] chunks;

    private int radiusWorldChunkX, radiusWorldChunkY, radiusWorldChunkZ; // in chunks

    //public Chunk originChunk;
    public Cube originCube;

    private void InitVariables()
    {
        //chunkWidth = chunkHeight = chunkDepth = 16;
        //chunksX = chunksY = chunksZ = 2;
        radiusWorldChunkX = chunksX / 2;
        radiusWorldChunkY = chunksY / 2;
        radiusWorldChunkZ = chunksZ / 2;
        //originChunk = new Chunk()
    }

    /*private Vector3Int GetRealChunkCoords(int x, int y, int z)
    {
        return new Vector3Int(x - radiusWorldChunkX, y - radiusWorldChunkY, z - radiusWorldChunkZ);
    }*/

    private Vector3 GetRealCoordinatesChunk(int x, int y, int z)
    {
        return new Vector3(
            x*sizeEdgeX*(chunkWidth/2),     // x edge
            y*sizeEdgeY*(chunkHeight/2),    // y edge
            z*sizeEdgeZ*(chunkDepth/2)      // z edge
        );
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
                    //GameObject chunk = (GameObject)Instantiate(newPosition, Quaternion.identity);
                    //chunk = new Chunk("Chunk@" + transform.position);
                    //chunks[x, y, z].AssignCoords(GetRealChunkCoords(x,y,z));
                    //chunks[x, y, z] = Instantiate(this, transform.position, Quaternion.identity) as Chunk;

                    /*Vector3 newPosition = new Vector3(x, y, z
                        //originChunk.transform.position.x + x,
                        //originChunk.transform.position.y + y,
                        //originChunk.transform.position.z + z
                        
                    );*/

                    chunks[x, y, z] = new Chunk();
                    //chunks[x, y, z].RealCoords(GetRealCoordinatesChunk(x, y, z));
                    chunks[x, y, z].realCoords = GetRealCoordinatesChunk(x, y, z);
                    chunks[x, y, z].Build(this, new Vector3Int(x, y, z), chunkWidth, chunkHeight, chunkDepth);

                    /*chunks[x, y, z] = Instantiate(originChunk, newPosition, Quaternion.identity);
                    chunks[x, y, z].gameObject.AddComponent<MeshFilter>();
                    chunks[x, y, z].gameObject.AddComponent<MeshRenderer>();
                    //chunks[x, y, z].gameObject.AddComponent<MeshFilter>();
                    chunks[x, y, z].name = "Chunk@[" + x + "," + y + "," + z + "]"; 
                    chunks[x, y, z].Build(this, new Vector3Int(x, y, z), chunkWidth, chunkHeight, chunkDepth);*/
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
