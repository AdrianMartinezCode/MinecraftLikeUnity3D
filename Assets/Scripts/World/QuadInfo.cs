using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadInfo {

    List<Vector3> vertices; // 4 vertices max
    List<Vector3> normals; // 4 normals, one for vertex
    List<Vector2> uv; // tex space
    List<int> triangles;

    
    public QuadInfo(Vector3 normal, List<Vector3> verts, List<int> triangles, Cube origin)
    {
        //uv = new Vector2[] { , new Vector2(1, 0), new Vector2(0, 1), new Vector2(1, 1) };
        /*uv = new List<Vector2>
        {
            new Vector2(0, 0),
            new Vector2(1, 0),
            new Vector2(0, 1),
            new Vector2(1, 1)
        };*/

        


        //triangles = new List<int>() { 0, 2, 1, 2, 3, 1 };
        this.triangles = triangles;

        //uv.rem

        normals = new List<Vector3> { normal, normal, normal, normal };

        vertices = verts;

        AssignUvCoords(origin);
        
    }


    public void AssignUvCoords(Cube origin)
    {
        float width = origin.ParentChunk.World.texture.width;
        float height = origin.ParentChunk.World.texture.height;


        float pixPColumn = origin.ParentChunk.World.pixelsPerTilePerColumn;
        float pixPRow = origin.ParentChunk.World.pixelsPerTilePerRow;

        float tilesPerRow = width / pixPRow;
        float tilesPerColumn = height / pixPColumn;

        float uinic = (origin.Id % tilesPerRow) * pixPRow;
        float vinic = ((int)(origin.Id / tilesPerColumn)) * pixPColumn;

        float duinic = uinic + pixPRow;
        float dvinic = vinic + pixPRow;

        float uif = uinic / width;
        float vif = 1 - vinic / height;

        float duif = duinic / width;
        float dvif = 1 - dvinic / height;



        uv = new List<Vector2>
        {
            new Vector2(duif, dvif),
            
            new Vector2(uif, dvif),
            new Vector2(duif, vif),
            new Vector2(uif, vif)

        };
        //Debug.Log("uif: " + uif + " ; vif: " + vif + " ; duif: " + duif + " ; dvif: " + dvif);

        //origin.ParentChunk.World.mat.
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
