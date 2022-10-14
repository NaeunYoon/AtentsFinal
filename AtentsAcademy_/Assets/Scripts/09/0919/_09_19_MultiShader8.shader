Shader "Custom/_09_19_MultiShader4"
{
 /*
 �ؽ��� 4�� ���� �ڵ� �ۼ�
 
 
 */
    Properties
    {
        _Color("Color", Color) = (1,1,1,1)

        _MainTex("Albedo (RGB)", 2D) = "white" {}
        _MainTex2("Albedo (RGB)", 2D) = "white" {}                          //1. �ؽ��� �� ���� ���� �ڵ� �ۼ�(�ܺη� ����)                                //6. ������ ���� (�ܺη� ����
        _MainTex3("Albedo (RGB)", 2D) = "white" {}
        _MainTex4("Albedo (RGB)", 2D) = "white" {}
        _Glossiness("Smoothness", Range(0,1)) = 0.5
        _Metallic("Metallic", Range(0,1)) = 0.0
    }
        SubShader
        {

            Tags { "RenderType" = "Opaque" }
            LOD 200

            CGPROGRAM
            
            #pragma surface surf Standard fullforwardshadows

            
            #pragma target 3.0

            sampler2D _MainTex;
            sampler2D _MainTex2;                                                
            sampler2D _MainTex3;
            sampler2D _MainTex4;



            struct Input
            {
                float2 uv_MainTex;
                float2 uv_MainTex2;                                             
                float2 uv_MainTex3;
                float2 uv_MainTex4;

                float4 color:COLOR;                                           
            };

            half _Glossiness;
            half _Metallic;
            fixed4 _Color;


            UNITY_INSTANCING_BUFFER_START(Props)

            UNITY_INSTANCING_BUFFER_END(Props)

            void surf(Input IN, inout SurfaceOutputStandard o)     //1n : �׷���ī�忡 ���޵Ǵ� �Է°�
            {


                fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
                fixed4 d = tex2D(_MainTex2, IN.uv_MainTex2) * _Color;           //4. �ܺο��� �Է¹��� �ؽ��� 2���� ���� ���´�
                fixed4 e = tex2D(_MainTex3, IN.uv_MainTex3) * _Color;
                fixed4 f = tex2D(_MainTex4, IN.uv_MainTex4) * _Color;

               /* fixed3 n = UnpackNormal(tex2D(_BumpTex, IN.uv_BumpTex));  */          //9.(1-t)a + bt   �������� ������ �̿��ؼ� ������ ����
                o.Albedo = c.rgb;                        //5. ���ؽ��� ���� �÷�(����)�� �� �÷��� ��������             
                /*o.Normal = n; */                            //��ֵ����� ����



               /* o.Albedo = lerp(c.rgb, d.rgb, IN.color.r);*/                          //5. ���ؽ��� ���� �÷�(����)�� �� �÷��� ��������         

                o.Albedo = (1 - IN.color.r) * c.rgb + d.rgb * IN.color.r;           //5-1 �����Լ� ��ſ� ���� ��� (����� ����)
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
