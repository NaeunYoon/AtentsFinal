using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _11_26_Triangle : MonoBehaviour
{
    float rot=0.0f;
    [SerializeField] private Texture _texture;
    void Start()
    {
        Vector3[] vertices = new Vector3[]  //��������
        {
            new Vector3(-1.0f,-1.0f,0.0f),  //0
            new Vector3(-1.0f,1.0f,0.0f),  //1
            new Vector3(1.0f,1.0f,0.0f)     //2
        };

        int[] triangles = new int[] { 0, 1, 2};        //�ε�������


        Vector2[] uvs = new Vector2[]   //uv��ǥ�� ������� ���� ��
        {
            new Vector2(0.0f,0.0f),
            new Vector2(0.0f,1.0f),
            new Vector2(1.0f,1.0f),
        };


        Mesh mesh = new Mesh(); //�Ž���ü�� ����

        mesh.vertices = vertices;   //�Ž����� ����
        mesh.triangles = triangles; //�ﰢ�� ���� ����
        mesh.uv = uvs;

        mesh.RecalculateBounds();
        mesh.RecalculateNormals();

        GetComponent<MeshFilter>().mesh = mesh; //�Ž������� ����
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
