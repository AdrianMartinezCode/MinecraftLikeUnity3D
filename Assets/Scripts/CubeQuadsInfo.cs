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
    float sizeEdge;
    Vector3 realCoordCube;

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
    public CubeQuadsInfo(bool[] visibles, Vector3 realCoordCube, float sizeEdge)
    {
        Top = Bottom = Left = Right = Front = Back = null;

        this.realCoordCube = realCoordCube;
        this.sizeEdge = sizeEdge;

        /* Util:
         * xOffset is -1 for face Left, 1 for face Right, the rest 0
         * yOffset is -1 for face Down, 1 for face Top, the rest 0
         * zOffset is -1 for face Front, 1 for face Back, the rest 0
         */


        if (visibles[0])
        {
            // Top Face
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
        List<int> inds = Bottom.Triangles;
        inds = AddValue(inds, numVerts);
        allInds.AddRange(inds);
        numVerts += Bottom.GetNumVertices();
        return new KeyValuePair<List<int>, int>(allInds, numVerts);
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
        float nsEdge = sizeEdge / 2;
        Vector3[] coords = new Vector3[4];
        coords[0].x = realCoordCube.x + -nsEdge;
        coords[0].y = realCoordCube.y + nsEdge;
        coords[0].z = realCoordCube.z + -nsEdge;

        coords[1].x = realCoordCube.x + nsEdge;
        coords[1].y = realCoordCube.y + nsEdge;
        coords[1].z = realCoordCube.z + -nsEdge;

        coords[2].x = realCoordCube.x + -nsEdge;
        coords[2].y = realCoordCube.y + nsEdge;
        coords[2].z = realCoordCube.z + nsEdge;

        coords[3].x = realCoordCube.x + nsEdge;
        coords[3].y = realCoordCube.y + nsEdge;
        coords[3].z = realCoordCube.z + nsEdge;

        Top = new QuadInfo(Vector3.up, coords);
    }

    public void BuildBottomFace()
    {
        float nsEdge = sizeEdge / 2;
        Vector3[] coords = new Vector3[4];
        coords[0].x = realCoordCube.x + -nsEdge;
        coords[0].y = realCoordCube.y + -nsEdge;
        coords[0].z = realCoordCube.z + -nsEdge;

        coords[1].x = realCoordCube.x + nsEdge;
        coords[1].y = realCoordCube.y + -nsEdge;
        coords[1].z = realCoordCube.z + -nsEdge;

        coords[2].x = realCoordCube.x + -nsEdge;
        coords[2].y = realCoordCube.y + -nsEdge;
        coords[2].z = realCoordCube.z + nsEdge;

        coords[3].x = realCoordCube.x + nsEdge;
        coords[3].y = realCoordCube.y + -nsEdge;
        coords[3].z = realCoordCube.z + nsEdge;

        Bottom = new QuadInfo(Vector3.down, coords);
    }

    public void BuildLeftFace()
    {
        float nsEdge = sizeEdge / 2;
        Vector3[] coords = new Vector3[4];
        coords[0].x = realCoordCube.x + -nsEdge;
        coords[0].y = realCoordCube.y + nsEdge;
        coords[0].z = realCoordCube.z + -nsEdge;

        coords[1].x = realCoordCube.x + -nsEdge;
        coords[1].y = realCoordCube.y + nsEdge;
        coords[1].z = realCoordCube.z + nsEdge;

        coords[2].x = realCoordCube.x + -nsEdge;
        coords[2].y = realCoordCube.y + -nsEdge;
        coords[2].z = realCoordCube.z + -nsEdge;

        coords[3].x = realCoordCube.x + -nsEdge;
        coords[3].y = realCoordCube.y + -nsEdge;
        coords[3].z = realCoordCube.z + nsEdge;

        Left = new QuadInfo(Vector3.left, coords);
    }

    public void BuildRightFace()
    {
        float nsEdge = sizeEdge / 2;
        Vector3[] coords = new Vector3[4];
        coords[0].x = realCoordCube.x + nsEdge;
        coords[0].y = realCoordCube.y + nsEdge;
        coords[0].z = realCoordCube.z + -nsEdge;

        coords[1].x = realCoordCube.x + nsEdge;
        coords[1].y = realCoordCube.y + nsEdge;
        coords[1].z = realCoordCube.z + nsEdge;

        coords[2].x = realCoordCube.x + nsEdge;
        coords[2].y = realCoordCube.y + -nsEdge;
        coords[2].z = realCoordCube.z + -nsEdge;

        coords[3].x = realCoordCube.x + nsEdge;
        coords[3].y = realCoordCube.y + -nsEdge;
        coords[3].z = realCoordCube.z + nsEdge;

        Right = new QuadInfo(Vector3.right, coords);
    }


    public void BuildFrontFace()
    {
        float nsEdge = sizeEdge / 2;
        Vector3[] coords = new Vector3[4];
        coords[0].x = realCoordCube.x + -nsEdge;
        coords[0].y = realCoordCube.y + -nsEdge;
        coords[0].z = realCoordCube.z + -nsEdge;

        coords[1].x = realCoordCube.x + nsEdge;
        coords[1].y = realCoordCube.y + -nsEdge;
        coords[1].z = realCoordCube.z + -nsEdge;

        coords[2].x = realCoordCube.x + -nsEdge;
        coords[2].y = realCoordCube.y + nsEdge;
        coords[2].z = realCoordCube.z + -nsEdge;

        coords[3].x = realCoordCube.x + nsEdge;
        coords[3].y = realCoordCube.y + nsEdge;
        coords[3].z = realCoordCube.z + -nsEdge;

        Front = new QuadInfo(Vector3.forward, coords);
    }

    public void BuildBackFace()
    {
        float nsEdge = sizeEdge / 2;
        Vector3[] coords = new Vector3[4];
        coords[0].x = realCoordCube.x + -nsEdge;
        coords[0].y = realCoordCube.y + -nsEdge;
        coords[0].z = realCoordCube.z + -nsEdge;

        coords[1].x = realCoordCube.x + nsEdge;
        coords[1].y = realCoordCube.y + -nsEdge;
        coords[1].z = realCoordCube.z + -nsEdge;

        coords[2].x = realCoordCube.x + -nsEdge;
        coords[2].y = realCoordCube.y + nsEdge;
        coords[2].z = realCoordCube.z + -nsEdge;

        coords[3].x = realCoordCube.x + nsEdge;
        coords[3].y = realCoordCube.y + nsEdge;
        coords[3].z = realCoordCube.z + -nsEdge;

        Front = new QuadInfo(Vector3.back, coords);
    }


    /*public static Vector3[] FrontCoords(Vector3 centerQuad, float sizeEdge)
    {
        Vector3[] coords = new Vector3[4];
        float nsEdge = sizeEdge / 2;
        
        
    }*/
}
