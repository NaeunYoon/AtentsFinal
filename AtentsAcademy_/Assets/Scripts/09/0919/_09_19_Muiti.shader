Shader "Custom/_09_19_Muiti2"
{/*
 
 �ؽ��� 2���� ���� �ڵ�
 R,G,B �÷��� �̿��� ���̴�
 */
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)

        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _MainTex2("Albedo (RGB)", 2D) = "white" {}      //1. �ؽ��� �߰� : �ܺη� ����

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
        sampler2D _MainTex2;        //2. �����ϱ� ���� ����
        struct Input
        {
            float2 uv_MainTex;
            float2 uv_MainTex2;     //3. uv ����
            float4 color : COLOR;        //4. vertex color �߰�
        };

        half _Glossiness;
        half _Metallic;
        fixed4 _Color;

        
        UNITY_INSTANCING_BUFFER_START(Props)
           
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
           
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;        //5. �ؽ��� �� ���� �ܺο��� �Է¹���
            fixed4 d = tex2D (_MainTex2, IN.uv_MainTex2) * _Color;

            o.Albedo = lerp(c.rgb, d.rgb, IN.color.r);       //6. �������� �÷��� ( ���ؽ��÷��� ���强������ �� �ؽ��ĸ� ��������)


            
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
