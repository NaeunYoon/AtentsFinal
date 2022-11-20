using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class _11_19_Triangle : MonoBehaviour
{
    float rot;
    void Start()
    {
        Vector3[] vertices = new Vector3[]
        {
            new Vector3(0,1.0f,0),  //0
            new Vector3(-1,-1f,0),  //1
            new Vector3(1,-1,0)     //2
        };

        int[] triangles = new int[] { 0, 1, 2, 0, 2, 1};        //�ε�������

        Mesh mesh = new Mesh(); //�Ž���ü�� ����
        mesh.vertices = vertices;   //�Ž����� ����
        mesh.triangles = triangles; //�ﰢ�� ���� ����
        mesh.RecalculateBounds();
        mesh.RecalculateNormals();

        GetComponent<MeshFilter>().mesh = mesh; //�Ž������� ����
        Material material = new Material(Shader.Find("Standard"));
        GetComponent<MeshRenderer>().material = material;   

    }

    
    void Update()
    {
        rot += Time.deltaTime * 60.0f;

        this.gameObject.transform.rotation = Quaternion.Euler(0.0f, rot, 0.0f);

    }
}
