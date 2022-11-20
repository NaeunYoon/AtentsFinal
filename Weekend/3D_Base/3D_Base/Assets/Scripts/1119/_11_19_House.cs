using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _11_19_House : MonoBehaviour
{

    void Start()
    {
        Vector3[] vertices = new Vector3[]
        {
            new Vector3(0,0,0),
            new Vector3(0,1,0),
            new Vector3(1,2,0),
            new Vector3(2,1,0),
            new Vector3(2,0,0)
        };

        int[] triangles = new int[] { 0, 1, 3, 1, 2, 3, 3, 4, 0 };

        Mesh mesh = new Mesh();
        mesh.vertices = vertices;
        mesh.triangles = triangles;

        mesh.RecalculateBounds();
        mesh.RecalculateNormals();

        GetComponent<MeshFilter>().mesh = mesh;

        Material material = new Material(Shader.Find("Standard"));
        GetComponent<MeshRenderer>().material = material;

    }


    void Update()
    {
        
    }
}
