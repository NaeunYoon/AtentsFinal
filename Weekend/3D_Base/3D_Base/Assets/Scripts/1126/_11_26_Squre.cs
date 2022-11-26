using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _11_26_Squre : MonoBehaviour
{
    float rot;
    [SerializeField] private Texture _texture;

    void Start()
    {
        Vector3[] vertices = new Vector3[]  //정점 버퍼에 있는 인덱스 값을 가지고 삼각형을 드로잉
        {
            new Vector3(-1.0f, -1.0f,0),
            new Vector3(-1.0f, 1.0f,0),
            new Vector3(1.0f, 1.0f,0),
            new Vector3(1.0f,-1.0f,0)
        };

        int[] triangles = new int[] { 0, 1, 2, 0, 2, 3 };

        Vector2[] uvs = new Vector2[]   //uv좌표로 어느정도 나올 지
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
    1. 3d모델 구축
    2. 가상공간에 배치
    3. 정점단위의 음영 계산
    4. 정점의 증감
    5. 카메라 공간의 전개
    6. 컬링
    7. 조명(광원)
    8. 클리핑처리
    9. 투영
    10. 뷰포트 전개
    11. 폴리곤 셋업 ( 래스터라이징 )
    12. 픽셀 파이프라인
    13. 텍스쳐 적용
    14. 랜더백엔드
    15. 출력
     
     
     */
}
