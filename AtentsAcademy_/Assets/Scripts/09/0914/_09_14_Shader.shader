Shader "Custom/_09_14_Shader"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        /*_Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0*/

        _Alpha("Alpha",Range(0,1))=1
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" "Queue"="Transparent"}
        LOD 200

        CGPROGRAM
        
        #pragma surface surf Standard fullforwardshadows

        
        #pragma target 3.0

        /*sampler2D _MainTex;*/

        struct Input
        {
            float2 uv_MainTex;
        };

        /*half _Glossiness;
        half _Metallic;*/


        fixed4 _Color;
        fixed4 _Alpha;
        sampler2D _MainTex;

            // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
            // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
            // #pragma instancing_options assumeuniformscaling
            UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
            UNITY_INSTANCING_BUFFER_END(Props)

            void surf(Input IN, inout SurfaceOutputStandard o)
        { 
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            o.Emission = fixed3(0, 0, 1);
            o.Alpha = _Alpha;
            o.Albedo = c.rgb;

            // Metallic and smoothness come from slider variables
            /*o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;*/
            /*o.Alpha = c.a;*/
        }
        ENDCG
    }
    FallBack "Diffuse"
}
