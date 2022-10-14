Shader "Custom/_09_13_SurfaceBasic"     //셰이더 이름 ( 유니티 내장 자체 스크립트)
//눈에 보이는 색을 연산하는 것이 셰이더이다. 벡터에 대한 연산을 직접 연산하는 것이 셰이더 프로그램
//동일한 캐릭터인데도 다르게 보여질 수 있다.
{

    /*
    프로퍼티 선언 -> 태그 설정 -> #pragma ->변수 선언 -> INPUT 구조체 정의 -> 연산함수 작성

       프로퍼티 선언 - 에디터에 공개되는 데이터
       태그 설정 - 랜더파이프와 랜더큐 결정
       #pragma - 조명과 그림자 설정
       변수 선언 - 연산에 사용할 변수 선언
       INPUT 구조체 정의 - 그래픽카드에 전달할 입력 데이터 정의
       연산함수 작성 - 출력 데이터 형식에 연산결과 적용
    
    */

    Properties      //프로퍼티 (외부로 공개되는 문자열은 큰따옴표)
    {
        _Color ("Color", Color) = (1,1,1,1)     //프로퍼티이름(변수), 문자열 : 에디터에 공개되는 이름, 자료형(데이터타입) = 초기값
        _MainTex ("Albedo (RGB)", 2D) = "white" {}      //텍스쳐를 의미,_MainTex이름은 변경할 수 없다. 2D : 텍스쳐 (Sampler 2D)
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
        Alpha ("Alpha",Range(0,2))=1 //실수 한 개의 데이터 
        
    }

    SubShader       //섭 셰이더(연산이 이뤄지는 곳) : 실질적인 부분
    {
        Tags { "RenderType"="Opaque" }      //랜더타입과 랜더큐 결정
        /*
        
        Tags {"RenderType" = "Opaque" "Queue" = "Transparent"} => 쉼표로 구분하지 않는다

         랜더타입 : 씬을 랜더링 하기 위한 정보를 얻기 위해 사용되는 Replace Shader를 위한 설정
                    씬을 랜더링하기 위해서는 생략할 수 없으며 정확한 Tag를 사용해야 함

                    * Opaque : 대부분의 불투명 셰이더에 사용
                    * Tranparent : 대부분의 알파블랜딩 셰이더에 사용
                    * TransparentCutout : 알파테스팅 셰이더에 사용
                    BackGround : 스카이박스 셰이더에 사용
                    Overlay : GUI텍스쳐, 후광(Halo), 플레어 셰이더 (Flare shader) 에 사용
                    TreeOpaque : 터레인 나무 줄기 부분에 사용
                    TreeTransparentCutout : 터레인 나뭇잎 부분에 사용
                    TreeBillboard : 터레인 나무 빌보드에 사용
                    Grass : 터레인 나무 풀에 사용
                    GrassBillboard : 터레인 나무 풀의 빌보드에 사용


         랜더 큐 : 큐는 랜더링 순서에 대한 태그
                   큐를 사용하여 오브젝트를 그리는 순서를 결정할 수 있음
                   번호가 낮을수록 빠르게 그려진다

                   Background : 1000
                   Geometry : 2000
                   AlphaTest : 2500
                   Transparent : 3000
                   Overlay : 4000
        */


        LOD 200

        CGPROGRAM               //프로그램의 시작
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows        //옵션설정, standard : 조명, fullforwardshadows :그림자

            /*
            #pragma 다음에 함수, 사용조명, 그림자와 테셀레이션 등 옵션을 지정할 수 있음

            surface : 서피스 셰이더
            surf : 연산함수
            Standard : 사용조명
            fullforwardshadows : 그림자옵션
            */



            //#pragma surface surf Lambert fullforwardshadows      => Lambert일 경우에는 input이 SurfaceOut 으로 바뀐다
            
        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0      //버전

        /*sampler2D _MainTex;*/

        struct Input    //그래픽 카드에 전달되는 입력(입력 구조체 반드시 필요 : 생략 불가능)
        {
            float2 uv_MainTex;      //실수 두 개 u와v값 : 그래픽카드의 입력을 텍스쳐의 uv 좌표에 전달
        };

        /*half _Glossiness;
        half _Metallic;*/
        fixed4 _Color;      //프로퍼티를 사용하기 위해 변수 선언을 한 번 해야함.

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutputStandard o)     //rgb 결정(실제 연산함수 작성)
                                                                //Input IN : 그래픽카드에 전달되는 인풋 구조체 입력의 매개변수
                                                                //연산 결과(출력 결과)를  SurfaceOutputStandard 구조체에 값을 채워준다
                                                                //출력형식의 구조체는 3가지 종류가 있다

            /*출력 형식의 구조체는 조명에 따라 달라진다.
            * 
            * 
            SurfaceOutputStandard                   SurfaceOutputStandardSpecular                   SurfaceOutput
            {                                       {                                               {
            fixed3 Albedo; 조명연산을 고려한 RGB    fixed3 Albedo;                                  fixed3 Albedo;
            fixed3 Normal; 노멀벡터                 fixed3 Specular; 전반사 색상(파워 0~1)          fixed3 Normal; 
            half3 Emission; 조명반영안하는RGB(음영X)fixed3 Normal;                                  fixed3 Emission;
            자신의 색을 그대로 보여주며 자체적으로 밝게
            half Metallic; 금속성분                 half3 Emission;                                 half Specular; 이건 데이터가 3개가 아님 강도.
            half Smoothness;  부드러움              half Smoothness;                                fixed Gloss; 강도
            (0 : 거침 1: 부드러움)
            half Occlusion; 오브젝트에 가리워진 값  half Occlusion;                                 fixed Alpha;
            fixed Alpha; 반투명값 (투명도)          fixed Alpha;                                    }
            }                                       }
            
            */


        {
            // Albedo comes from a texture tinted by color
            /*fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;*/

            o.Albedo = _Color;      //조명을 반영한 rgb에 컬러를 채워준다

            /*o.Albedo = float4(0,0,0,0);*/     //연산 결과를 o의 멤버에 채워준다

            /*o.Emission = _Color;  */       //조명을 반영하지 않는 RGB값 (음영이 없음)


            // Metallic and smoothness come from slider variables
            /*o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
            o.Alpha = c.a;*/
        }
        ENDCG               //프로그램의 끝
    }
    FallBack "Diffuse"
}


/*

유니티 셰이더 프로그램 구조

Shader "셰이더 이름"
{
    Properties : 유니티에 공개되는 정보
    {

    }
    Subshader ; 한개 이상의 Subshader가 존재해야 한다
    {
        Pass : Pass 블록은 오브젝트 지오메트리를 한 번만 연산
        {

        }
    }
}



자료형

Half : float(실수)의 1/2 크기
       정밀도가 필요한 것은 half, 그 밖에는 float

fixed : Half보다 더 작은 크기
        컬러나 벡터의 길이를 표현하기에 충분
        11비트의 자료형
float4 : float3 이미지에 알파채널이 포함된다면 사용
         flaot4 (1.0, 1.0, 1.0, 0.5) => 흰색 반투명
                  R     G     B    A
Sampler2D : 유니티에서 제공하는 텍스쳐 샘플링을 하기 위한 데이터 타입



*/