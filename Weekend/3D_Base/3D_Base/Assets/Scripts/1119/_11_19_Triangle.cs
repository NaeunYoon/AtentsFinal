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

        int[] triangles = new int[] { 0, 1, 2, 0, 2, 1};        //인덱스버퍼

        Mesh mesh = new Mesh(); //매쉬객체를 만듬
        mesh.vertices = vertices;   //매쉬버퍼 전달
        mesh.triangles = triangles; //삼각형 버퍼 전달
        mesh.RecalculateBounds();
        mesh.RecalculateNormals();

        GetComponent<MeshFilter>().mesh = mesh; //매쉬데이터 전달
        Material material = new Material(Shader.Find("Standard"));
        GetComponent<MeshRenderer>().material = material;   

    }

    
    void Update()
    {
        rot += Time.deltaTime * 60.0f;

        this.gameObject.transform.rotation = Quaternion.Euler(0.0f, rot, 0.0f);

    }
}
