using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MeshBuilder
{

    private Chunk chunk;
    private Dictionary<Vector3Int, CubeQuadsInfo> cubes;

    public MeshBuilder(Chunk chunk)
    {
        this.chunk = chunk;
        BuildAllCubes();




    }

    public void BuildAllCubes()
    {
        cubes = new Dictionary<Vector3Int, CubeQuadsInfo>();

        BuildDataFaces();

        


        List<Vector3> allVerts = new List<Vector3>();
        List<Vector3> allNormals = new List<Vector3>();
        List<Vector2> allUvs = new List<Vector2>();
        List<int> allInds = new List<int>();
        int currInds = 0;
        foreach(KeyValuePair<Vector3Int, CubeQuadsInfo> p in cubes ) {
            allVerts.AddRange(p.Value.GetAllCoords());
            allNormals.AddRange(p.Value.GetAllNormals());
            allUvs.AddRange(p.Value.GetAllUv());

            List<int> values = p.Value.GetAllIndexs();
            for (int i = 0; i < values.Count; i++)
            {
                values[i] += currInds;
            }
            allInds.AddRange(values);
            currInds += values.Count;

        }

        MeshFilter mf = chunk.GetComponent<MeshFilter>();
        Mesh mesh = new Mesh
        {
            vertices = allVerts.ToArray(),
            normals = allNormals.ToArray(),
            uv = allUvs.ToArray(),
            triangles = allInds.ToArray()
        };
        mf.mesh = mesh;
        //mesh.RecalculateBounds();


    }

    // x, y, z in the current chunk
    public Vector3 GetRealCoordinates(int x, int y, int z)
    {
        return new Vector3(
            chunk.Xchunk * chunk.World.chunkWidth + x,
            chunk.Ychunk * chunk.World.chunkHeight + y,
            chunk.Zchunk * chunk.World.chunkDepth + z
        );
    }

    public void BuildDataFaces()
    {
        int xLength = chunk.Cubes.GetLength(0);
        int yLength = chunk.Cubes.GetLength(1);
        int zLength = chunk.Cubes.GetLength(2);

        for (int x = 0; x < xLength; x++)
        {
            for (int y = 0; y < yLength; y++)
            {
                for (int z = 0; z < zLength; z++)
                {
                    if (!chunk.Cubes[x, y, z].IsNotRenderCube())
                    {
                        KeyValuePair<bool[], bool> vis = FaceVisibles(x, y, z, xLength, yLength, zLength);
                        if (vis.Value)
                        {
                            cubes.Add(new Vector3Int(x, y, z), new CubeQuadsInfo(vis.Key, GetRealCoordinates(x, y, z), chunk.World.sizeEdgeX));
                        }
                    }
                }
            }
        }
    }


    public KeyValuePair<bool[],bool> FaceVisibles(int x, int y, int z, int xLength, int yLength, int zLength)
    {
        // Down face
        bool anyFaceVisible = false;

        bool[] bfaces = new bool[6];
        if (y == 0)
        {
            bfaces[1] = true;
        }
        else
        {
            bfaces[1] = chunk.Cubes[x, y - 1, z].IsTransparentCube();
        }

        anyFaceVisible = anyFaceVisible || bfaces[1];

        // Up face
        if (y == xLength - 1)
        {
            bfaces[0] = true;
        }
        else
        {
            bfaces[0] = chunk.Cubes[x, y + 1, z].IsTransparentCube();
        }
        anyFaceVisible = anyFaceVisible || bfaces[0];
        // Left face
        if (x == 0) {
            bfaces[2] = true;
        } else {
            bfaces[2] = chunk.Cubes[x - 1, y, z].IsTransparentCube();
        }
        anyFaceVisible = anyFaceVisible || bfaces[2];

        // Right face
        if (x == xLength - 1) {
            bfaces[3] = true;
        } else {
            bfaces[3] = chunk.Cubes[x + 1, y, z].IsTransparentCube();
        }
        anyFaceVisible = anyFaceVisible || bfaces[3];

        // Front face
        if (z == 0)
        {
            bfaces[4] = true;
        }
        else
        {
            bfaces[4] = chunk.Cubes[x, y, z - 1].IsTransparentCube();
        }
        anyFaceVisible = anyFaceVisible || bfaces[4];
        // Back face
        if (z == xLength - 1)
        {
            bfaces[5] = true;
        }
        else
        {
            bfaces[5] = chunk.Cubes[x, y, z + 1].IsTransparentCube();
        }
        anyFaceVisible = anyFaceVisible || bfaces[5];


        return new KeyValuePair<bool[], bool>(bfaces, anyFaceVisible);
    }


}

    
