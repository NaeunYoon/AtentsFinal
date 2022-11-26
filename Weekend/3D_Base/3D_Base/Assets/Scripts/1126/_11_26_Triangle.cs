using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _11_26_Triangle : MonoBehaviour
{
    float rot=0.0f;
    [SerializeField] private Texture _texture;
    void Start()
    {
        Vector3[] vertices = new Vector3[]  //정점버퍼
        {
            new Vector3(-1.0f,-1.0f,0.0f),  //0
            new Vector3(-1.0f,1.0f,0.0f),  //1
            new Vector3(1.0f,1.0f,0.0f)     //2
        };

        int[] triangles = new int[] { 0, 1, 2};        //인덱스버퍼


        Vector2[] uvs = new Vector2[]   //uv좌표로 어느정도 나올 지
        {
            new Vector2(0.0f,0.0f),
            new Vector2(0.0f,1.0f),
            new Vector2(1.0f,1.0f),
        };


        Mesh mesh = new Mesh(); //매쉬객체를 만듬

        mesh.vertices = vertices;   //매쉬버퍼 전달
        mesh.triangles = triangles; //삼각형 버퍼 전달
        mesh.uv = uvs;

        mesh.RecalculateBounds();
        mesh.RecalculateNormals();

        GetComponent<MeshFilter>().mesh = mesh; //매쉬데이터 전달
        Material material = new Material(Shader.Find("Standard"));
        material.SetTexture("_MainTex", _texture);

        GetComponent<MeshRenderer>().material = material;

    }


    void Update()
    {
        rot += Time.deltaTime * 60.0f;

        this.gameObject.transform.rotation = Quaternion.Euler(0.0f, rot, 0.0f);

    }
}
