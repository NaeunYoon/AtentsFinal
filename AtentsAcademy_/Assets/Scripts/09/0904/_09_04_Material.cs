using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _09_04_Material : MonoBehaviour
{
    /*
     재질 : 텍스쳐, 물체의 색상과 같이 눈에 보여지는 컬러에 관련된 모든 정보에 관여하는 성분
            눈에 보여지는 모든 게임오브젝트는 머터리얼1개 이상을 포함
            재질의 개수는 드로우콜과비례
            유니티에서 재질정보 Renderer 컴포넌트에서 얻어올 수 있음
            텍스쳐를 변경하려면 -> Renderer > Material > Texture 



     */

    public GameObject Cube;         //1. 게임오브젝트를 저장해놔야함
    Texture2D rcTexture1;
    Texture2D rcTexture2;

    void Start()
    {
        rcTexture1 = Resources.Load<Texture2D>("Meshtint Free Knight");
        rcTexture2 = Resources.Load<Texture2D>("Substance_graph_ambientOcclusion");

    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            //텍스쳐에 접근하려면, 머터리얼에 접근
            Cube.GetComponent<MeshRenderer>().material.SetTexture("_MainTex",rcTexture1);    //함수 : _MainTex(머터리얼에 적용된 쉐이더의 프로퍼티 이름 / 필수)

            /*Cube.GetComponent<MeshRenderer>().material.mainTexture=rcTexture1;*/     //프로퍼티
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            Cube.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", rcTexture2);

            /*Cube.GetComponent<MeshRenderer>().material.mainTexture = rcTexture2;*/    //프로퍼티
        }
        //텍스쳐에 오프셋을 변경하는 코드
        Vector2 textureOffset = Cube.GetComponent<MeshRenderer>().material.mainTextureOffset;
        textureOffset.x += Time.deltaTime;
        Cube.GetComponent<MeshRenderer>().material.mainTextureOffset = textureOffset;
    }
}
