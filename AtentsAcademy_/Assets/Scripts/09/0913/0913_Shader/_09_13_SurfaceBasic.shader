Shader "Custom/_09_13_SurfaceBasic"     //���̴� �̸� ( ����Ƽ ���� ��ü ��ũ��Ʈ)
//���� ���̴� ���� �����ϴ� ���� ���̴��̴�. ���Ϳ� ���� ������ ���� �����ϴ� ���� ���̴� ���α׷�
//������ ĳ�����ε��� �ٸ��� ������ �� �ִ�.
{

    /*
    ������Ƽ ���� -> �±� ���� -> #pragma ->���� ���� -> INPUT ����ü ���� -> �����Լ� �ۼ�

       ������Ƽ ���� - �����Ϳ� �����Ǵ� ������
       �±� ���� - ������������ ����ť ����
       #pragma - ����� �׸��� ����
       ���� ���� - ���꿡 ����� ���� ����
       INPUT ����ü ���� - �׷���ī�忡 ������ �Է� ������ ����
       �����Լ� �ۼ� - ��� ������ ���Ŀ� ������ ����
    
    */

    Properties      //������Ƽ (�ܺη� �����Ǵ� ���ڿ��� ū����ǥ)
    {
        _Color ("Color", Color) = (1,1,1,1)     //������Ƽ�̸�(����), ���ڿ� : �����Ϳ� �����Ǵ� �̸�, �ڷ���(������Ÿ��) = �ʱⰪ
        _MainTex ("Albedo (RGB)", 2D) = "white" {}      //�ؽ��ĸ� �ǹ�,_MainTex�̸��� ������ �� ����. 2D : �ؽ��� (Sampler 2D)
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
        Alpha ("Alpha",Range(0,2))=1 //�Ǽ� �� ���� ������ 
        
    }

    SubShader       //�� ���̴�(������ �̷����� ��) : �������� �κ�
    {
        Tags { "RenderType"="Opaque" }      //����Ÿ�԰� ����ť ����
        /*
        
        Tags {"RenderType" = "Opaque" "Queue" = "Transparent"} => ��ǥ�� �������� �ʴ´�

         ����Ÿ�� : ���� ������ �ϱ� ���� ������ ��� ���� ���Ǵ� Replace Shader�� ���� ����
                    ���� �������ϱ� ���ؼ��� ������ �� ������ ��Ȯ�� Tag�� ����ؾ� ��

                    * Opaque : ��κ��� ������ ���̴��� ���
                    * Tranparent : ��κ��� ���ĺ��� ���̴��� ���
                    * TransparentCutout : �����׽��� ���̴��� ���
                    BackGround : ��ī�̹ڽ� ���̴��� ���
                    Overlay : GUI�ؽ���, �ı�(Halo), �÷��� ���̴� (Flare shader) �� ���
                    TreeOpaque : �ͷ��� ���� �ٱ� �κп� ���
                    TreeTransparentCutout : �ͷ��� ������ �κп� ���
                    TreeBillboard : �ͷ��� ���� �����忡 ���
                    Grass : �ͷ��� ���� Ǯ�� ���
                    GrassBillboard : �ͷ��� ���� Ǯ�� �����忡 ���


         ���� ť : ť�� ������ ������ ���� �±�
                   ť�� ����Ͽ� ������Ʈ�� �׸��� ������ ������ �� ����
                   ��ȣ�� �������� ������ �׷�����

                   Background : 1000
                   Geometry : 2000
                   AlphaTest : 2500
                   Transparent : 3000
                   Overlay : 4000
        */


        LOD 200

        CGPROGRAM               //���α׷��� ����
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows        //�ɼǼ���, standard : ����, fullforwardshadows :�׸���

            /*
            #pragma ������ �Լ�, �������, �׸��ڿ� �׼����̼� �� �ɼ��� ������ �� ����

            surface : ���ǽ� ���̴�
            surf : �����Լ�
            Standard : �������
            fullforwardshadows : �׸��ڿɼ�
            */



            //#pragma surface surf Lambert fullforwardshadows      => Lambert�� ��쿡�� input�� SurfaceOut ���� �ٲ��
            
        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0      //����

        /*sampler2D _MainTex;*/

        struct Input    //�׷��� ī�忡 ���޵Ǵ� �Է�(�Է� ����ü �ݵ�� �ʿ� : ���� �Ұ���)
        {
            float2 uv_MainTex;      //�Ǽ� �� �� u��v�� : �׷���ī���� �Է��� �ؽ����� uv ��ǥ�� ����
        };

        /*half _Glossiness;
        half _Metallic;*/
        fixed4 _Color;      //������Ƽ�� ����ϱ� ���� ���� ������ �� �� �ؾ���.

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutputStandard o)     //rgb ����(���� �����Լ� �ۼ�)
                                                                //Input IN : �׷���ī�忡 ���޵Ǵ� ��ǲ ����ü �Է��� �Ű�����
                                                                //���� ���(��� ���)��  SurfaceOutputStandard ����ü�� ���� ä���ش�
                                                                //��������� ����ü�� 3���� ������ �ִ�

            /*��� ������ ����ü�� ���� ���� �޶�����.
            * 
            * 
            SurfaceOutputStandard                   SurfaceOutputStandardSpecular                   SurfaceOutput
            {                                       {                                               {
            fixed3 Albedo; �������� ����� RGB    fixed3 Albedo;                                  fixed3 Albedo;
            fixed3 Normal; ��ֺ���                 fixed3 Specular; ���ݻ� ����(�Ŀ� 0~1)          fixed3 Normal; 
            half3 Emission; ����ݿ����ϴ�RGB(����X)fixed3 Normal;                                  fixed3 Emission;
            �ڽ��� ���� �״�� �����ָ� ��ü������ ���
            half Metallic; �ݼӼ���                 half3 Emission;                                 half Specular; �̰� �����Ͱ� 3���� �ƴ� ����.
            half Smoothness;  �ε巯��              half Smoothness;                                fixed Gloss; ����
            (0 : ��ħ 1: �ε巯��)
            half Occlusion; ������Ʈ�� �������� ��  half Occlusion;                                 fixed Alpha;
            fixed Alpha; ������ (����)          fixed Alpha;                                    }
            }                                       }
            
            */


        {
            // Albedo comes from a texture tinted by color
            /*fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;*/

            o.Albedo = _Color;      //������ �ݿ��� rgb�� �÷��� ä���ش�

            /*o.Albedo = float4(0,0,0,0);*/     //���� ����� o�� ����� ä���ش�

            /*o.Emission = _Color;  */       //������ �ݿ����� �ʴ� RGB�� (������ ����)


            // Metallic and smoothness come from slider variables
            /*o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
            o.Alpha = c.a;*/
        }
        ENDCG               //���α׷��� ��
    }
    FallBack "Diffuse"
}


/*

����Ƽ ���̴� ���α׷� ����

Shader "���̴� �̸�"
{
    Properties : ����Ƽ�� �����Ǵ� ����
    {

    }
    Subshader ; �Ѱ� �̻��� Subshader�� �����ؾ� �Ѵ�
    {
        Pass : Pass ����� ������Ʈ ������Ʈ���� �� ���� ����
        {

        }
    }
}



�ڷ���

Half : float(�Ǽ�)�� 1/2 ũ��
       ���е��� �ʿ��� ���� half, �� �ۿ��� float

fixed : Half���� �� ���� ũ��
        �÷��� ������ ���̸� ǥ���ϱ⿡ ���
        11��Ʈ�� �ڷ���
float4 : float3 �̹����� ����ä���� ���Եȴٸ� ���
         flaot4 (1.0, 1.0, 1.0, 0.5) => ��� ������
                  R     G     B    A
Sampler2D : ����Ƽ���� �����ϴ� �ؽ��� ���ø��� �ϱ� ���� ������ Ÿ��



*/