using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{

    //private float realX, realY, realZ;
    private Vector3 realCoords;
    private int x, y, z;
    private Cube[,,] cubes;
    private MeshBuilder meshBuilder;
    private WorldData world;

    

    //public Chunk(float )

    /**
     * WorldData MUST inicializes de Chunk!
     */
    void Start()
    {
        //cubes = new Cube[]
        Build(new Vector3Int(x, y, z), world.chunkWidth, world.chunkHeight, world.chunkDepth);

    }

    public void Build(Vector3Int v, int xLength, int yLength, int zLength)
    {
        //mat = Resources.Load("Textures/top") as Texture;
        //this.world = world;
        AssignCoords(v);
        GenerateCubes(xLength, yLength, zLength);
        meshBuilder = new MeshBuilder(this);
        meshBuilder.BuildAllCubes();
    }

    public void AssignCoords(Vector3Int v)
    {
        x = v.x;
        y = v.y;
        z = v.z;
    }

    /**
     * xLength, yLength, zLength in cubes!
     * 
     */ 
    public void GenerateCubes(int xLength, int yLength, int zLength)
    {

        //Texture tex = Resources.Load<Texture>("")
        

        /*int xLenght = Cubes.GetLength(0);
        int yLength = Cubes.GetLength(1);
        int zLength = Cubes.GetLength(2);*/
        cubes = new Cube[xLength, yLength, zLength];
        //Debug.Log(((int)(Random.value * 20)) % 2);
        for (int x = 0; x < xLength; x++)
        {
            for (int y = 0; y < yLength; y++)
            {
                for (int z = 0; z < zLength; z++)
                {
                    /*Vector3 newPosition = new Vector3(x, y, z
                        //originChunk.transform.position.x + x,
                        //originChunk.transform.position.y + y,
                        //originChunk.transform.position.z + z
                        
                    );*/

                    /*chunks[x, y, z] = new Chunk();
                    chunks[x, y, z].RealCoords(GetRealCoordinatesChunk(x, y, z));
                    chunks[x, y, z].Build(this, new Vector3Int(x, y, z), chunkWidth, chunkHeight, chunkDepth);*/

                    //Transform trCube = world.originCube.transform;
                    //trCube.position = GetRealCoordinatesForCube(x, y, z);

                    cubes[x, y, z] = new Cube();
                    cubes[x, y, z].ParentChunk = this;
                    cubes[x, y, z].Position = GetRealCoordinatesForCube(x, y, z);
                    //cubes[x, y, z].Id
                    //cubes[x, y, z] = GameObject.Instantiate<Cube>(world.originCube, GetRealCoordinatesForCube(x, y, z), Quaternion.identity);

                    //cubes[x, y, z].gameObject.AddComponent<Rigidbody>();
                    //cubes[x, y, z].gameObject.AddComponent<MeshFilter>();
                    //cubes[x, y, z].gameObject.AddComponent<BoxCollider>();
                    //cubes[x, y, z].gameObject.AddComponent<MeshRenderer>();



                    //cubes[x, y, z].name = "Cube@[" + x + ", " + y + ", " + z + "]";

                    /*if (x%3 == 0 && y%3 == 0 && z%3 == 0)
                    {
                        cubes[x, y, z].Id = ((int)(Random.value * 20)) % 4 + 1;
                    }
                    else
                    {
                        cubes[x, y, z].Id = 8;
                    }*/
                    cubes[x, y, z].Id = ((int)(Random.value*20)%2)*(((int)(Random.value * 255)) % 255);
                    //cubes[x, y, z].Id = 1;
                    //cubes[x, y, z].ParentChunk = this;

                    //Debug.Log("Cube@[" + cubes[x, y, z].transform.position.x + ", " + cubes[x, y, z].transform.position.y + ", " + cubes[x, y, z].transform.position.z + "]");


                    /*chunks[x, y, z] = Instantiate(originChunk, newPosition, Quaternion.identity);
                    chunks[x, y, z].gameObject.AddComponent<MeshFilter>();
                    chunks[x, y, z].gameObject.AddComponent<MeshRenderer>();
                    //chunks[x, y, z].gameObject.AddComponent<MeshFilter>();
                    chunks[x, y, z].name = "Chunk@[" + x + "," + y + "," + z + "]"; 
                    chunks[x, y, z].Build(this, new Vector3Int(x, y, z), chunkWidth, chunkHeight, chunkDepth);*/


                    //cubes[x, y, z] = new Cube(((int)(Random.value * 20)) % 2);
                }
            }
        }
    }

    public Vector3 GetRealCoordinatesForCube(int x, int y, int z)
    {
        return new Vector3(
            realCoords.x + x*(world.sizeEdgeX/2),
            realCoords.y + y* (world.sizeEdgeY / 2),
            realCoords.z + z* (world.sizeEdgeZ / 2)
        /*chunk.Xchunk * chunk.World.chunkWidth + x,
        chunk.Ychunk * chunk.World.chunkHeight + y,
        chunk.Zchunk * chunk.World.chunkDepth + z*/
        /*chunk.transform.position.x + x,
        chunk.transform.position.y + y,
        chunk.transform.position.z + z*/
        );
    }

    public int Xchunk
    {
        get { return x;  }
        set { x = value; }
    }

    public int Ychunk
    {
        get { return y; }
        set { y = value; }
    }

    public int Zchunk
    {
        get { return z; }
        set { z = value; }
    }

    public Cube[,,] Cubes
    {
        get { return cubes; }
    }

    public WorldData World
    {
        get { return world; }
        set { world = value; }
    }

    public Vector3 RealCoords
    {
        get { return realCoords; }
        set { realCoords = value; }
    }

    public WorldData World1
    {
        get
        {
            return world;
        }

        set
        {
            world = value;
        }
    }
}
