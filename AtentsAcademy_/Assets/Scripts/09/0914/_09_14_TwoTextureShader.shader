Shader "Custom/_09_14_TwoTextureShader"
{
    /*
    서피스 셰이더를 먼저 생성
    텍스쳐 2장을 에디터에서 입력받는 프로퍼티
    변수선언
    입력 구조체에서 각각의 텍스쳐 UV 선언
    
    */

    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)

        _MainTex ("Albedo (RGB)", 2D) = "white" {}          //텍스쳐 2장이니까 메인텍스쳐 두 장
        _MainTex2("Albedo (RGB)", 2D) = "white" {}
        _MainTex3("Albedo (RGB)", 2D) = "white" {}          //텍스쳐 한 장 더 추가

        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0


        _Ratio("Ratio", Range(0,1)) = 0
        _Ratio2("Ratio2", Range(0,1)) = 0               //비율 추가
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;             //프로퍼티에 메인텍스쳐가 2장이니까 변수도 2개 선언
        sampler2D _MainTex2;
        sampler2D _MainTex3;            //텍스쳐 변수 3개
        struct Input
        {
            float2 uv_MainTex;
            float2 uv_MainTex2;         //구조체도 2개
            float2 uv_MainTex3;         //구조체 추가
        };

        half _Glossiness;
        half _Metallic;

        fixed4 _Color;
        fixed _Ratio;
        fixed _Ratio2;          //비율 추가

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Albedo comes from a texture tinted by color
            fixed4 c1 = tex2D (_MainTex, IN.uv_MainTex) * _Color;       //변수 2개
            fixed4 c2 = tex2D(_MainTex2, IN.uv_MainTex2) * _Color;
            fixed4 c3 = tex2D(_MainTex3, IN.uv_MainTex3) * _Color;        //변수 3개

            /*o.Albedo = c1.rgb*c2.rgb; */          //색을 섞을 때에는 곱해준다 :그러나 비율이 없기 때문에 선형보간을 해준다

            o.Albedo = lerp(c1.rgb , c2.rgb , _Ratio);        //섞는 비율 t 를 프로퍼티 변수에 넣기

            o.Albedo = lerp(o.Albedo, c3.rgb, _Ratio2);     //첫번쨰를 이용하여 연산

            // Metallic and smoothness come from slider variables
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
            o.Alpha = c1.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
