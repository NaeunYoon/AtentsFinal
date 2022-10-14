using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _09_07_ShaderFind : MonoBehaviour
{
    /*
     
    픽셀셰이더 (서피스 셰이더 ) : 메모리 영역 가상의 화면을 만들어 놓는 데 이와 유사한 개념, 가상의 그릴 수 있는 메모리 영역
    fx : 조명과 글레스 효과 셰이더
    GUI : UI 셰이더
    Mobile : 모바일 디바이스를 위한 고성능 셰이더
    Nature : 나무 및 터레인을 위한 셰이더
    Particle :  파티클 시스템 효과 셰이더
    Skybox : 배경화면을 위한 셰이더
    Sprite :2D Sprite 시스템을 위한 셰이더
    Toon : 카툰 스타일 랜더링을 위한 셰이더
    Unlit : 모든 조명과 그림자를 완전히 무시하는 셰이더
    Legacy : 스텐다드 셰이더로 대체된 이전 셰이더 컬렉션
     
    조명 : 분산 전반사 ...

    컬러를 숫자로 표현하는 방법 RGB(100%,100%,100%) = RGB(255,255,255) = float3(1.0,1.0,1.0) : 값 성분의 최댓값은 1이다.


     셰이더를 실시간으로 교체하는 프로그램 작성
     */

    
    void Start()
    {
        //Renderer라는 이름의 컴포넌트를 자식의 게임오브젝트에서 GetComponent

        SkinnedMeshRenderer renderer = gameObject.GetComponentInChildren<SkinnedMeshRenderer>();    //한단계 아래가 아니라 아래 아래를 사용
        if(renderer != null)
        {   //실시간 셰이더 교체 방법
            renderer.material.shader = Shader.Find("Mobile/Diffuse");
        }

        //SkinnedMeshRenderer renderer = GetComponentInParent<SkinnedMeshRenderer>();
        List<SkinnedMeshRenderer> resultList = new List<SkinnedMeshRenderer>();
        //GetComponentInChildren<SkinnedMeshRenderer>(resultList);
        foreach(SkinnedMeshRenderer one in resultList)
        {
            Debug.Log(one);

        }


    }

    //Transform FindGameObjectInChild(string _name, Transform _tr)
    //{

    //}
    
    void Update()
    {
        
    }
}
