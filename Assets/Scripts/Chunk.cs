using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour {

    private int x, y, z;
    private Cube[,,] cubes;
    private MeshBuilder meshBuilder;
    private WorldData world;

    /**
     * WorldData MUST inicializes de Chunk!
     */
    void Start()
    {
        //cubes = new Cube[]

    }

    public void Build(WorldData world, Vector3Int v, int xLength, int yLength, int zLength)
    {
        this.world = world;
        AssignCoords(v);
        GenerateCubes(xLength, yLength, zLength);
    }

    public void AssignCoords(Vector3Int v)
    {
        x = v.x;
        y = v.y;
        z = v.z;
    }

    public void GenerateCubes(int xLength, int yLength, int zLength)
    {
        
        /*int xLenght = Cubes.GetLength(0);
        int yLength = Cubes.GetLength(1);
        int zLength = Cubes.GetLength(2);*/
        cubes = new Cube[xLength, yLength, zLength];

        for (int x = 0; x < xLength; x++)
        {
            for (int y = 0; y < yLength; y++)
            {
                for (int z = 0; z < zLength; z++)
                {
                    cubes[x, y, z] = new Cube(1);
                }
            }
        }
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
    }
}
