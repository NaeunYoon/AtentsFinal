Shader "Custom/_09_15_BumpMap"
{/*
 텍스쳐 2장을 기본으로 사용하기 떄문에 연산량이 많아진다
 
 
 
 */
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}  //일반텍스쳐

                                    //범프맵 프로퍼티를 추가
                                    _BumpTex("Normal map", 2D) = "bump"{}

        _Glossiness ("Smoothness", Range(0,1)) = 0.5
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

                                    //연산을 하기 위한 자료형 선언
                                    sampler2D _BumpTex;

        struct Input
        {
            float2 uv_MainTex;

                                    //uv 추가
                                    float2 uv_BumpTex;
        };

        half _Glossiness;
        half _Metallic;
        fixed4 _Color;

       
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Albedo comes from a texture tinted by color
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;    //일반텍스쳐의 rgb 반환하는 것

                                    //UnpackNormal(flaot4) : 연산된 노멀을 반환시켜주는 함수(x,y,z값만 필요하므로 fixed3), 자료형은 folat4
                                    fixed3 n = UnpackNormal(tex2D(_BumpTex, IN.uv_BumpTex));

            o.Albedo = c.rgb;
                                    //출력형식 구조체 
                                    o.Normal = n;

            // Metallic and smoothness come from slider variables
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
           /* o.Gloss = _Glossiness*/
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
