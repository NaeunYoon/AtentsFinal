using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _09_06_Light : MonoBehaviour
{
    /*
     빛은 입자와 파동의 성질을 동시에 갖고 있다 ( 빛의 입자는 광자 )
     물체를 볼 수 있다 -> 광자가 물체의 표면에 부딪혀 사람의 눈에 도달
     (1. 태양이나 형광등과 같은 광원에 의한 광자
      2. 재질로부터 발산되는 광자)

    광원의 종류
    1. 방향광 : 조명을 받는 어떤 물체로부터 무한한 거리에 위치한 광원 (좁은고깔)
                방향이 가장 중요하다 ( 방향이 있음)
    2. 점광 : 한 점으로부터 광자가 방출되는 광원 (햇빛모양)
              점으로부터 사방으로 퍼짐
    3. 집중광 : 방향광과 점광을 혼합, 빛을 비추는 방향과 범위를 갖고 있다
                조명의 방향을 나타내는 방향벡터와 조명 범위각으로 표현되는 고깔모양으로 정의 (넓은고깔모양)
                카메라처럼위에서 아래를 비춤

    눈에 보이는 색상 :
    방사재질
    분산색상
    전반사 색상
    주변광 색상

    난반사 + 전반사 + 주변광 +
    라이트닝 > 환경 > 환경광 밝기 조절
    라이트닝..인바이러먼트 라이트닝을 조절 : 전체 화면 밝기

    재질(Material) : 매시에 색을 칠할 수 있게 해주는 성분
                     주변 재질 색상 : 다른 물체에 의해 반사되어 나타나는 주변 반사광의 색상의 지점
                     난반사 재질 색상 : 물체 표면 자체의 색상을 표현
                     전반사 재질 생삭 : 광원이 반사되어 물체의 가장 빛나는 부분의 색상 지정
                     방사 재질 색상 : 발광체의 물체를 표현할 때 사용하는 재직

    => Shader를 어떻게 연산하느냐에 따라서 물체의 색이 달라진다

     
    조명모델 : 눈에 보이는 과정의 상호작용을 수학적으로 모델링한 것
               = 분산성분 + 전반사성분 + 주변성분 //색 합산은 더하는게 아니라 곱해준다
               빨강 녹색을 섞고싶다면 빨강과 녹색을 곱해주는 것

      1) 분산성분 : 빛이 모든 방향으로(방향은 일정치 않은) 똑같은 양을 반사하는 난반사체를 모델링
                    반사되는 광령은 일부는 재질 표면에 흡수되기 떄문에 재질과 밀접한 관련이 있다
      2) 전반사성분 : 우리가 바라보는 시갸에 따라 반짝이는 물체들은 모두 전반사
                      전반사 성분은 눈의 위치, 시점이 매우 중요한 결정요소
                      빛이 반사되어 나오는 하이라이트 전반사 재질 색상과 그 표면이 얼마나 반짝이는지를 나타내는 반사도에 영향을 미침
                      Shiness 값이 작으면 반사도가 올라가는 것 처럼 보인다
      3) 주변성분 : 주변광 특성과 주변광 재질간의 상호관계를 표현하는 성분
                    난반사와 전반사를 통해 직접적으로 조명 받지 않고, 물체에 반사된 간접 조명만을 표현하지 못함
                    주변광 성분을 표시하려 그럴듯하게 조명효과를 처리

    건물과 바닥과 같은 오브젝트는 베이크한다 ( 포인트라이트 )
    베이크 된 오브젝트들은 조명을 꺼도 자동으로 라이트맵이 생성되지만
    새로운 오브젝트나 프리팹은 조명의 영향을 받지 않는다
    새로운 조명을 받게 하고 싶으면 베이크드 라이트닝 맵에서 클리어,
    그리고 씬에서 오토 제네레이트 해준다

     */


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
