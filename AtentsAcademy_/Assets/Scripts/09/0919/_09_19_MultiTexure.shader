Shader "Custom/_09_19_MultiTexure8"
{/*
 텍스쳐 8장 섞는 코드 작성
 
 
 */
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)

        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _BumpTex("BumpMap",2D) = "white" {}

        _MainTex2 ("Albedo (RGB)", 2D) = "white" {}                          //1. 텍스쳐 두 장을 섞는 코드 작성(외부로 공개)
        _BumpTex2("BumpMap",2D) = "white" {}                                //6. 범프맵 적용 (외부로 공개

        _MainTex3("Albedo (RGB)", 2D) = "white" {}
        _BumpTex3("BumpMap",2D) = "white" {}

        _MainTex4("Albedo (RGB)", 2D) = "white" {}
        _BumpTex4("BumpMap",2D) = "white" {}

        _Glos_BumpTex("BumpMap",2D) = "white" {}siness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
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

        sampler2D _MainTex;
        sampler2D _MainTex2;                                                //2.연산을 하기 위해 변수 선언(텍스쳐
        sampler2D _MainTex3;
        sampler2D _MainTex4;

        sampler2D _BumpTex;                                                    //7. 범프맵 선언
        sampler2D _BumpTex2;
        sampler2D _BumpTex3;
        sampler2D _BumpTex4;


        struct Input
        {
            float2 uv_MainTex;
            float2 uv_MainTex2;                                             //3.uv좌표 선언(텍스쳐의uv좌표
            float2 uv_MainTex3;
            float2 uv_MainTex4;

            float uv_BumpTex;                                               //8. 범프맵이 다 들어가지 않으므로 하나만 선언

            float4 color:COLOR;                                           //4. Vertex color 추가 (정점의 색)
        };

        half _Glossiness;
        half _Metallic;
        fixed4 _Color;

        
        UNITY_INSTANCING_BUFFER_START(Props)
            
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutputStandard o)     //1n : 그래픽카드에 전달되는 입력값
        {
            

            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            fixed4 d = tex2D (_MainTex2, IN.uv_MainTex2) * _Color;           //4. 외부에서 입력받은 텍스쳐 2장을 색을 섞는다
            fixed4 e = tex2D (_MainTex3, IN.uv_MainTex3) * _Color;
            fixed4 f = tex2D (_MainTex4, IN.uv_MainTex4) * _Color;

            fixed3 n = UnpackNormal(tex2D(_BumpTex, IN.uv_BumpTex));   //9.(1-t)a + bt   선형보간 공식을 이용해서 범프맵 적용
            o.Albedo = c.rgb;                        //5. 버텍스의 레드 컬러(성분)로 두 컬러를 보간해줌             
            o.Normal = n;                             //노멀데이터 보간



           /* o.Albedo = lerp(c.rgb, d.rgb, IN.color.r);*/                          //5. 버텍스의 레드 컬러(성분)로 두 컬러를 보간해줌         

            o.Albedo = (1 - IN.color.r) * c.rgb + d.rgb * IN.color.r;           //5-1 러프함수 대신에 공식 사용 (결과는 동일)
            o.Albedo = lerp(o.Albedo, e.rgb, IN.color.g);
            o.Albedo = lerp(o.Albedo, f.rgb, IN.color.b);

            // Metallic and smoothness come from slider variables
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
            o.Alpha = c.a;
            /*o.Emission = IN.color.rgb;*/
        }
        ENDCG
    }
    FallBack "Diffuse"
}
