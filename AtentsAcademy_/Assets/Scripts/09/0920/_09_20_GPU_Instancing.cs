using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _09_20_GPU_Instancing : MonoBehaviour
{
    /*
    [GPU Instancing] : 동일한 메시의 복제본을 한번에 그리거나 렌더링 하는 것, 씬에서 반복적으로 나타내는 건물 풀 나무와 같은 것을 그릴 떄 유용
    MeshRenderer를 사용하는 게임 오브젝트에서만 가능하고 드로우 콜을 줄여준다

    인스펙터 창에서 사용 선택 (Material > enable GPU Instancing 체크)
    GPU Instancing 셰이더 프로그램 코드 작성 (셰이더를 오브젝트 material에 적용)
    오브젝트를 프리팹으로 만들어 리소스 폴더에 보관
    생성시 프로퍼티 블럭을 사용 (빈 오브젝트에 스크립트 추가)

    사용할만한 정보의 코드를 가지고 있어야죠~~~!
    1. 마우스 왼쪽 버튼 누를 시 gpu Instancing 기능을 사용한 게임 오브젝트 생성
    2. 화명상에서 게임 오브젝트 선택 시 선택한 게임 오브젝트의 컬러를 검정으로 변경하는 프로그램 코드 작성

    문제의 핵심은 gpu instancing 기능을 사용하는 게임 오브젝트의 색상을 실행 중 변경


     */

    List<GameObject> objects;

    void Start()
    {
        objects = new List<GameObject>();       

        GameObject tmp = Resources.Load<GameObject>("Sphere");      //게임오브젝트를 리소스 폴더에 보관하고 불러온다
        for(int i = 0; i<10; i++)
        {
            GameObject createObjects = GameObject.Instantiate<GameObject>(tmp);     //보관되어있는 오브젝트들을 인스턴시에이트 한다
            objects.Add(createObjects);         // 인스턴시에이트 된 오브젝트들을 리스트에 추가한다
        }

        MaterialPropertyBlock props = new MaterialPropertyBlock();  //자료형    //가비지콜렉터가 작동함..한번 뉴 한 것은 아껴써야함
        MeshRenderer renderer;

        foreach (GameObject obj in objects)     //리스트에 추가된 오브젝트들을 반복문에 돌린다
        {
            float r = Random.Range(0.0f, 1.0f);         //컬러 변경(RGB 값을 랜덤으로 바꿈)
            float g = Random.Range(0.0f, 1.0f);
            float b = Random.Range(0.0f, 1.0f);

            /*프로퍼티 블록을 사용하는 절차(중요) */

            props.SetColor("_Color", new Color(r, g, b));           //컬러라는 프로퍼티 블록 활성화

            renderer = obj.GetComponent<MeshRenderer>();        //랜더러의 값을 가져와서 
            renderer.SetPropertyBlock(props);               //셋 프로퍼티 블록을 해준다(겟과 셋은 각각 다르게 해야함)
        }
    }

    //=>화면에 10개의 프리팹의 색이 다 다른 상태로 생성된다

    
    void Update()
    {
        
    }
}
