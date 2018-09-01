using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeQuadsInfo {

    /*
     * We need to save all faces for the case when player
     *  breaks a cube adjacent of any face of that cube, when
     *  it occurs, we need render that face, if we save that faces
     *  we can directly modify this face to render.
     */
    QuadInfo Top, Bottom, Left, Right, Front, Back;
    //List<Quad> quads;
    //float sizeEdge;
    //Vector3 realCoordCube;
    Cube ownCube;

    List<Vector3> allVertices;

    /**
     * By position in visibles:
     * 0 -> Top
     * 1 -> Bottom
     * 2 -> Left
     * 3 -> Right
     * 4 -> Front
     * 5 -> Back
     * 
     * realCoordCube a real position in worldSpace
     * 
     * sizeEdge is the length of any edge of cube
     * 
     */
    public CubeQuadsInfo(Cube ownCube)
    {
        Top = Bottom = Left = Right = Front = Back = null;
        this.ownCube = ownCube;


        /*this.realCoordCube = realCoordCube;
        this.sizeEdge = sizeEdge;*/

        /* Util:
         * xOffset is -1 for face Left, 1 for face Right, the rest 0
         * yOffset is -1 for face Down, 1 for face Top, the rest 0
         * zOffset is -1 for face Front, 1 for face Back, the rest 0
         */


        

    }

    public void BuildFaces(bool[] visibles)
    {
        CreateEightVertices();
        if (visibles[0])
        {
            BuildUpFace();
        }
        if (visibles[1])
        {
            BuildBottomFace();
        }
        if (visibles[2])
        {
            BuildLeftFace();
        }
        if (visibles[3])
        {
            BuildRightFace();
        }
        if (visibles[4])
        {
            BuildFrontFace();
        }
        if (visibles[5])
        {
            BuildBackFace();
        }

        /*cubes[x, y, z].gameObject.AddComponent<MeshFilter>();
        cubes[x, y, z].gameObject.AddComponent<MeshRenderer>();*/
        //cubes[x, y, z].gameObject.AddComponent<Rigidbody>();

        //cubes[x, y, z].gameObject.AddComponent<BoxCollider>();
        //Debug.Log(ownCube.name);

        
        Mesh mesh = ownCube.gameObject.AddComponent<MeshFilter>().mesh;
        /*Mesh mesh = new Mesh
        {
            vertices = GetAllCoords().ToArray(),
            normals = GetAllNormals().ToArray(),
            uv = GetAllUv().ToArray(),
            triangles = GetAllIndexs().ToArray()
        };*/

        mesh.Clear();
        //Mesh mesh = new Mesh();
        mesh.SetVertices(GetAllCoords());
        mesh.SetNormals(GetAllNormals());
        mesh.SetUVs(0, GetAllUv());
        mesh.SetTriangles(GetAllIndexs(), 0);

        MeshRenderer rend = ownCube.gameObject.AddComponent<MeshRenderer>();
        rend.material.mainTexture = ownCube.ParentChunk.mat;
        //mf.mesh = mesh;
        //mesh.RecalculateBounds();
        //mesh.RecalculateNormals();


        /*    MeshFilter mf = chunk.GetComponent<MeshFilter>();
        Mesh mesh = new Mesh
        {
            vertices = allVerts.ToArray(),
            normals = allNormals.ToArray(),
            uv = allUvs.ToArray(),
            triangles = allInds.ToArray()
        };
        mf.mesh = mesh;*/
    }

    private void CreateEightVertices()
    {
        allVertices = new List<Vector3>();

        float nsEdgeX = ownCube.ParentChunk.World.sizeEdgeX / 2;
        float nsEdgeY = ownCube.ParentChunk.World.sizeEdgeY / 2;
        float nsEdgeZ = ownCube.ParentChunk.World.sizeEdgeZ / 2;

        Vector3 posCube = ownCube.transform.position;

        allVertices.Add(new Vector3( // 0
            posCube.x - nsEdgeX,
            posCube.y - nsEdgeY,
            posCube.z - nsEdgeZ
        ));

        allVertices.Add(new Vector3( // 1
            posCube.x + nsEdgeX,
            posCube.y - nsEdgeY,
            posCube.z - nsEdgeZ
        ));

        allVertices.Add(new Vector3( // 2
            posCube.x - nsEdgeX,
            posCube.y - nsEdgeY,
            posCube.z + nsEdgeZ
        ));

        allVertices.Add(new Vector3( // 3
            posCube.x + nsEdgeX,
            posCube.y - nsEdgeY,
            posCube.z + nsEdgeZ
        ));

        allVertices.Add(new Vector3( // 4
            posCube.x - nsEdgeX,
            posCube.y + nsEdgeY,
            posCube.z - nsEdgeZ
        ));

        allVertices.Add(new Vector3( // 5
            posCube.x + nsEdgeX,
            posCube.y + nsEdgeY,
            posCube.z - nsEdgeZ
        ));

        allVertices.Add(new Vector3( // 6
            posCube.x - nsEdgeX,
            posCube.y + nsEdgeY,
            posCube.z + nsEdgeZ
        ));

        allVertices.Add(new Vector3( // 7
            posCube.x + nsEdgeX,
            posCube.y + nsEdgeY,
            posCube.z + nsEdgeZ
        ));

        /*allVertices

        Vector3 one = new Vector3(
                posCube.x - nsEdge.x,

            )
        coords[0].x = posCube.x + -nsEdgeX;
        coords[0].y = posCube.y + nsEdgeY;
        coords[0].z = posCube.z + -nsEdgeZ;*/
    }

    public List<int> AddValue(List<int> inds, int value)
    {
        for (int i = 0; i < inds.Count; i++)
        {
            inds[i] += value;
        }
        return inds;
    }

    public KeyValuePair<List<int>, int> AddAndIncrement(QuadInfo q, List<int> allInds, int numVerts)
    {
        List<int> inds = q.Triangles;
        inds = AddValue(inds, numVerts);
        allInds.AddRange(inds);
        numVerts += q.GetNumVertices();
        return new KeyValuePair<List<int>, int>(allInds, numVerts);
    }

    public int GetTotalNumVertices()
    {
        int numverts = 0;
        if (Top != null)
        {
            numverts += Top.GetNumVertices();
        }
        if (Bottom != null)
        {
            numverts += Bottom.GetNumVertices();
        }
        if (Left != null)
        {
            numverts += Left.GetNumVertices();
        }
        if (Right != null)
        {
            numverts += Right.GetNumVertices();
        }
        if (Front != null)
        {
            numverts += Front.GetNumVertices();
        }
        if (Back != null)
        {
            numverts += Back.GetNumVertices();
        }
        return numverts;
    }


    public List<Vector3> GetAllCoords()
    {
        List<Vector3> allCoords = new List<Vector3>();
        if (Top != null)
        {
            allCoords.AddRange(Top.Vertices);
        }
        if (Bottom != null)
        {
            allCoords.AddRange(Bottom.Vertices);
        }
        if (Left != null)
        {
            allCoords.AddRange(Left.Vertices);
        }
        if (Right != null)
        {
            allCoords.AddRange(Right.Vertices);
        }
        if (Front != null)
        {
            allCoords.AddRange(Front.Vertices);
        }
        if (Back != null)
        {
            allCoords.AddRange(Back.Vertices);
        }
        return allCoords;
    }

    public List<Vector3> GetAllNormals()
    {
        List<Vector3> allCoords = new List<Vector3>();
        if (Top != null)
        {
            allCoords.AddRange(Top.Normals);
        }
        if (Bottom != null)
        {
            allCoords.AddRange(Bottom.Normals);
        }
        if (Left != null)
        {
            allCoords.AddRange(Left.Normals);
        }
        if (Right != null)
        {
            allCoords.AddRange(Right.Normals);
        }
        if (Front != null)
        {
            allCoords.AddRange(Front.Normals);
        }
        if (Back != null)
        {
            allCoords.AddRange(Back.Normals);
        }
        return allCoords;
    }

    public List<Vector2> GetAllUv()
    {
        List<Vector2> allCoords = new List<Vector2>();
        if (Top != null)
        {
            allCoords.AddRange(Top.Uv);
        }
        if (Bottom != null)
        {
            allCoords.AddRange(Bottom.Uv);
        }
        if (Left != null)
        {
            allCoords.AddRange(Left.Uv);
        }
        if (Right != null)
        {
            allCoords.AddRange(Right.Uv);
        }
        if (Front != null)
        {
            allCoords.AddRange(Front.Uv);
        }
        if (Back != null)
        {
            allCoords.AddRange(Back.Uv);
        }
        return allCoords;
    }

    public List<int> GetAllIndexs()
    {
        int numVerts = 0;
        List<int> allInds = new List<int>();
        if (Top != null)
        {
            KeyValuePair<List<int>, int>  kvp = AddAndIncrement(Top, allInds, numVerts);
            allInds = kvp.Key;
            numVerts = kvp.Value;
        }
        if (Bottom != null)
        {
            KeyValuePair<List<int>, int> kvp = AddAndIncrement(Bottom, allInds, numVerts);
            allInds = kvp.Key;
            numVerts = kvp.Value;
        }
        if (Left != null)
        {
            KeyValuePair<List<int>, int> kvp = AddAndIncrement(Left, allInds, numVerts);
            allInds = kvp.Key;
            numVerts = kvp.Value;
        }
        if (Right != null)
        {
            KeyValuePair<List<int>, int> kvp = AddAndIncrement(Right, allInds, numVerts);
            allInds = kvp.Key;
            numVerts = kvp.Value;
        }
        if (Front != null)
        {
            KeyValuePair<List<int>, int> kvp = AddAndIncrement(Front, allInds, numVerts);
            allInds = kvp.Key;
            numVerts = kvp.Value;
        }
        if (Back != null)
        {
            KeyValuePair<List<int>, int> kvp = AddAndIncrement(Back, allInds, numVerts);
            allInds = kvp.Key;
            numVerts = kvp.Value;
        }
        return allInds;
    }

    public void BuildUpFace()
    {


        List<Vector3> coords = new List<Vector3> { allVertices[4], allVertices[5], allVertices[6], allVertices[7] };

        Top = new QuadInfo(Vector3.up, coords, new List<int>() { 0, 2, 1, 2, 3, 1 });
    }

    public void BuildBottomFace()
    {

        List<Vector3> coords = new List<Vector3> { allVertices[0], allVertices[1], allVertices[2], allVertices[3] };
        Bottom = new QuadInfo(Vector3.down, coords, new List<int>() { 0, 1, 2, 2, 1, 3 });
    }

    public void BuildLeftFace()
    {

        List<Vector3> coords = new List<Vector3> { allVertices[0], allVertices[2], allVertices[4], allVertices[6] };
        Left = new QuadInfo(Vector3.left, coords, new List<int>() { 0, 3, 2, 0, 1, 3 });
    }

    public void BuildRightFace()
    {

        List<Vector3> coords = new List<Vector3> { allVertices[1], allVertices[3], allVertices[5], allVertices[7] };
        Right = new QuadInfo(Vector3.right, coords, new List<int>() { 0, 2, 3, 0, 3, 1 });
    }


    public void BuildFrontFace()
    {

        List<Vector3> coords = new List<Vector3> { allVertices[0], allVertices[1], allVertices[4], allVertices[5] };
        Front = new QuadInfo(Vector3.back, coords, new List<int>() { 0, 2, 3, 0, 3, 1 });
    }

    public void BuildBackFace()
    {
        List<Vector3> coords = new List<Vector3> { allVertices[2], allVertices[3], allVertices[6], allVertices[7] };

        Back = new QuadInfo(Vector3.forward, coords, new List<int>() { 0, 1, 2, 2, 1, 3 });
    }

    public Cube OwnCube
    {
        get
        {
            return ownCube;
        }

        set
        {
            ownCube = value;
        }
    }
    /*public static Vector3[] FrontCoords(Vector3 centerQuad, float sizeEdge)
    {
        Vector3[] coords = new Vector3[4];
        float nsEdge = sizeEdge / 2;
        
        
    }*/
}
