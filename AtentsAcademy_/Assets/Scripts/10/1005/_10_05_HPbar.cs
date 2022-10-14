using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _10_05_HPbar : MonoBehaviour
{
    /*
     캔버스 설정
    1. 스크린공간 - 오버레이 셋팅 : 캔버스가 화면에 맞게 스케일 된 후에 씬이나 카메라의 레퍼런스 없이 직접 랜더링
                                    스크린의 크기나 해상도가 변경되면 ui는 자동으로 맞춤 스케일

       스크린공간 - 카메라셋팅 : 캔버스는 주어진 카메라 앞에서 어느 정도 거리에 있는 평면 객체에 그려진 것처럼 랜더링
                                 유아이의 화면 크기는 카메라 절투체 내에 정확히 맞게 조정되므로 항상 거리에 따라 다름
                                 화면의 크기나 해상도 또는 카메라 절두체가 변경되면 ui가 자동으로 조정

       월드공간 셋팅 : ui를 장면의 평면 객체처럼 랜더링
                       스크린공간 모드와 달리 평면은 카메라를 향할 필요가 없으며 원하는대로 방향을 지정
                       캔버스의 크기는 렉트 트랜스폼을 사용하여 설정할 수 있지만 화면크기는 카메라의 시야각 및 거리에 따라 다름
                       다른 장면 개체는 캔버스를 통과할 수 있음

       렉스 트랜스폼 : ui전용 transform, ui의 위치 회전 스케일 앵커 프로퍼티 정보 포함되어 있다
       앵커 : ui의 기준점을 의미한다
       Image : UI의 이미지를 출력하는 컴포넌트
               SourceImage : 2d sprite 형식
               Color
               Material

       ImageType : simple : 전체 이미지를 보여줌
                   sliced : 9 슬라이싱
                   tiled : 원본 이미지를 크기에 맞도록 재조정하여 채움
                   filed : 이미지의 일부를 보여주는 방식
       ScrollView : ScrollRect : 스크롤뷰의 속성을 결정 
                    ViewPort : 뷰포트 밖의 영역은 화면에서 그려지지 않고 뷰포트 안의 내용이 화면에 보임
                    Content : 실제 스크롤 내용이 보여질 영역으로 스크롤되는 내용을 추가

       Text : TextComponent : ui 상의 글자를 출력하는 컴포넌트 ( 폰트 글자크기 색상 정렬방식 조정)
              OutLine : 텍스트의 외곽선 구현
       Button : Image :ui 상의 이미지를 출력하는 컴포넌트 /이미지의 타입은 sprite 2D 형식
                Button : 버튼 이벤트 처리
                Text : 버튼의 이름을 기입할 때 사용
       EventMethod : 버튼 클릭했을 시 호출되는 메소드
                     1) + 버튼 클릭
                     2) 게임 오브젝트 등록(Runtime Only)
                     3) 스크립트의 메소드 선택

     
     */




    public Image hpimg;
    Vector3 screenPos;
    public Transform hpPosition;
    public Image frame;
    private void Awake()
    {
        
    }
    void Start()
    {
        screenPos = Camera.main.WorldToScreenPoint(hpPosition.transform.position); //월드공간의 좌표의 현재 위치를 화면좌표로 변환 
    }

    
    void Update()
    {
        hpimg.transform.position = screenPos;       //렉트 트렌스폼을 사용해도 상관없음
        frame.transform.position = screenPos;
        screenPos = Camera.main.WorldToScreenPoint(hpPosition.transform.position); //월드공간의 좌표의 현재 위치를 화면좌표로 변환 
        hpimg.fillAmount -= Time.deltaTime;
    }
}
