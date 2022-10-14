Shader "Custom/TwoTextureShader"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _MainTex2("Albedo (RGB)", 2D) = "white" {}
        _MainTex3("Albedo (RGB)", 2D) = "white" {}
        _Ratio("Ratio", Range(0,1)) = 0
        _Ratio2("Ratio", Range(0,1)) = 0
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200
        CGPROGRAM
        #pragma surface surf Standard fullforwardshadows
        #pragma target 3.0
        sampler2D _MainTex;
        sampler2D _MainTex2;
        sampler2D _MainTex3;
        struct Input
        {
            float2 uv_MainTex;
            float2 uv_MainTex2;
            float2 uv_MainTex3;
        };
        half _Glossiness;
        half _Metallic;
        fixed4 _Color;
        fixed _Ratio;
        fixed _Ratio2;
        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)
        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Albedo comes from a texture tinted by color
            fixed4 c1 = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            fixed4 c2 = tex2D (_MainTex2, IN.uv_MainTex2) * _Color;
            fixed4 c3 = tex2D (_MainTex3, IN.uv_MainTex3) * _Color;
            o.Albedo = lerp(c1.rgb, c2.rgb, _Ratio);
            o.Albedo = lerp(o.Albedo, c3.rgb, _Ratio2);
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
            o.Alpha = c1.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
