using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _11_26_CubeCreator : MonoBehaviour
{
    float rot;
    [SerializeField] private Texture _texture;

    void Start()
    {
        Vector3[] vertices = new Vector3[]  //정점 버퍼에 있는 인덱스 값을 가지고 삼각형을 드로잉
        {
            new Vector3(-1.0f, -1.0f,-1.0f),    //0
            new Vector3(-1.0f, 1.0f,-1.0f),  //1
            new Vector3(1.0f, 1.0f, -1.0f),  //2
            new Vector3(1.0f,-1.0f,-1.0f),  //3
            new Vector3(-1.0f,-1.0f,1.0f),   //4
            new Vector3(-1.0f,1.0f,1.0f),   //5
            new Vector3(1.0f,1.0f,1.0f),   //6
            new Vector3(1.0f,-1.0f,1.0f)
        };

        int[] triangles = new int[] 
            { 0, 1, 2, 
            0, 2, 3,
            3,2,6,
            3,6,7,
            7,6,5,
            7,5,4,
            4,5,1,
            4,1,0,
            1,5,6,
            1,6,2,
            0,4,7,
            0,7,3};

        Vector2[] uvs = new Vector2[]   //uv좌표로 어느정도 나올 지
       {
            new Vector2(0.0f,0.0f),
            new Vector2(0.3f,0.33f),
            new Vector2(0.5f,0.33f),
            new Vector2(0.5f,0.0f),

            new Vector2(0.0f,1.0f),
            new Vector2(0.0f,0.66f),
            new Vector2(0.5f,0.66f),
            new Vector2(0.5f,1.0f),
            //new Vector2(0.5f,0.0f),

       };

        Mesh mesh = new Mesh();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uvs;

        mesh.RecalculateBounds();
        mesh.RecalculateNormals();

        GetComponent<MeshFilter>().mesh = mesh;

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
