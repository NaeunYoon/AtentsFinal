using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _11_19_Square : MonoBehaviour
{
    void Start()
    {
        Vector3[] vertices = new Vector3[]  //���� ���ۿ� �ִ� �ε��� ���� ������ �ﰢ���� �����
        {
            new Vector3(-1.0f, -1.0f,0),
            new Vector3(-1.0f, 1.0f,0),
            new Vector3(1.0f, 1.0f,0),
            new Vector3(1.0f,-1.0f,0)
        };

        int[] triangles = new int[] { 0, 1, 2, 0, 2, 3 };

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
