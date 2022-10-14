Shader "Custom/_09_13_Blue"
{

    /*
    
    1. 조명연산을 고려하지 않은 Blue 값을 갖는 셰이더 코드 작성
    
    2. 0에서 1까지의 범위를 갖는 프로퍼티를 선언하시오, 단, 프로퍼티 이름은 _Alpha 이다.
    3. 2번의 문제를 연산에 사용하기 위한 선언을 하시오
    4. _Alpha의 값을 출력 결과 구조체에 적용하시오
    
    */
    Properties //외부에 공개되는 변수 : 연산에 사용하기 위해 외부에서 대입하기 위해
    {
        _Color ("Color", Color) = (1,1,1,1)

        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0

        _Alpha ("_Alpha",Range(0,1))=1                        //2번 문제
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue"="Transparent"}              //6번
        /*
        랜더타입과 랜더큐를 결정해야 한다

        
        */


        LOD 200     //level of detail 거리를 의미

        CGPROGRAM       //시작을 의미
        
        #pragma surface surf Standard alpha:fade                                                //5번 문제
        //Standard : 내장되어있는 조명
        //alpha:fade => 알파블랜드 옵션 
        
        #pragma target 3.0

        //연산에 사용 할 변수와 구조체 선언 (프로퍼티에 대입한 것들을 선언)

        sampler2D _MainTex; //프로퍼티 : _MainTex ("Albedo (RGB)", 2D) = "white" {} / 샘플러2D로 메인텍스의 자료형 사용

        //인풋 구조체 : 그래픽 카드에 전달되는 입력 데이터 (무조건 존재해야 한다)
        struct Input
        {
            float2 uv_MainTex; //=> 텍스쳐의 UV좌표를 그래픽카드에 전달되는 입력값 ( 변경하지 않는다 )
        };

        //flaot < half < fixed4

        half _Glossiness;       //Range형 변수는 Half 로 선언
        half _Metallic;

        fixed4 _Color;          //fixed4 자료형은 컬러값에 사용 (half보다 더 작은 실수) : 틴트컬러
        half _Alpha;            //3. 선언

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutputStandard o) 
            //inout 들어올 수도 있고 나갈 수 있음, SurfaceOutputStandard 출력 형식의 구조체
        {
            // Albedo comes from a texture tinted by color

            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;        //텍스쳐와uv를 매개변수로 전달받아서 색상이 포함된 fixed4 형식을 반환
                                                                        //메인텍스쳐의 색상을 화면에 출력하기 위해 fixed4 형식으로 바꿔준다
                                                                        //텍스쳐가 클수록 연산량이 많음 uv 좌표를 전달한다
                                                                        //색을 섞는 연산은 더하기가 아니라 곱하기 이다. 따라서 곱함
                                                                        //최종적인 컬러 형식은 fixed4 이고 변수 c에 담아둔다
            /*o.Albedo = c.rgb;*/       //rgb 컬러를 Albedo에 대입한다. Albedo : 조명연산을 고려한 RGB 값 (텍스쳐와 틴트컬러를 대입한 RGB)

            /*o.Albedo = float3(1,1,0);*/

            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
            o.Alpha = c.a;  //출력형식 구조체의 알파값에 대입한 것.
            o.Emission = fixed3(0, 0, 1);           //1번 문제(컬러를 직접 대입한 것)
            o.Alpha = _Alpha;                       //4번 문제
        }
        ENDCG       //끝을 의미
    }
    FallBack "Diffuse"
}
