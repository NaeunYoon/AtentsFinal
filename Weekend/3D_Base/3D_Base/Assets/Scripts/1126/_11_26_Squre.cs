using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _11_26_Squre : MonoBehaviour
{
    float rot;
    [SerializeField] private Texture _texture;

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

        Vector2[] uvs = new Vector2[]   //uv��ǥ�� ������� ���� ��
       {
            new Vector2(0.0f,0.0f),
            new Vector2(0.0f,1.0f),
            new Vector2(1.0f,0.0f),
            new Vector2(1.0f,1.0f),
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


    /*
    1. 3d�� ����
    2. ��������� ��ġ
    3. ���������� ���� ���
    4. ������ ����
    5. ī�޶� ������ ����
    6. �ø�
    7. ����(����)
    8. Ŭ����ó��
    9. ����
    10. ����Ʈ ����
    11. ������ �¾� ( �����Ͷ���¡ )
    12. �ȼ� ����������
    13. �ؽ��� ����
    14. �����鿣��
    15. ���
     
     
     */
}
