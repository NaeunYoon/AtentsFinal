Shader "Custom/_09_15_Lambert"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        /*_Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0*/

        _Alpha("test", Range(0,1)) = 1
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue"="Transparent"}    //추가
        LOD 200
        Zwrite Off
        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Lambert alpha:fade     //Lambert라는 조명이 있음 + 알파 추가

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
        };

        /*half _Glossiness;
        half _Metallic;*/
        fixed4 _Color;
                fixed _Alpha;

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutput o)     //최종 출력 구조체 Srandard 제거(Lambert 조명을 쓰려면 SurfaceOutput 써야함)
        {
            // Albedo comes from a texture tinted by color
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            o.Albedo = c.rgb;
            // Metallic and smoothness come from slider variables
            /*o.Metallic = _Metallic;*/             //Metalic 제거
            /*o.Smoothness = _Glossiness;*/         //moothness 제거
            /*o.Alpha = c.a;*/
            o.Alpha = _Alpha;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
