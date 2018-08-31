using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadInfo {

    List<Vector3> vertices; // 4 vertices max
    List<Vector3> normals; // 4 normals, one for vertex
    List<Vector2> uv; // tex space
    List<int> triangles;

    
    public QuadInfo(Vector3 normal, Vector3[] verts)
    {
        //uv = new Vector2[] { , new Vector2(1, 0), new Vector2(0, 1), new Vector2(1, 1) };
        uv = new List<Vector2>
        {
            new Vector2(0, 0),
            new Vector2(1, 0),
            new Vector2(0, 1),
            new Vector2(1, 1)
        };

        triangles = new List<int>() { 0, 2, 1, 2, 3, 1 };

        normals = new List<Vector3> { normal, normal, normal, normal };

        vertices = new List<Vector3>(verts);
        
    }

    public int GetNumVertices()
    {
        return vertices.Count;
    }

    public List<int> Triangles
    {
        get { return triangles;  }
    }
    public List<Vector3> Vertices
    {
        get { return vertices;  }
    }
    public List<Vector3> Normals
    {
        get { return normals; }
    }
    public List<Vector2> Uv
    {
        get { return uv; }
    }
}
