Shader "Custom/_09_13_Blue"
{

    /*
    
    1. �������� ������� ���� Blue ���� ���� ���̴� �ڵ� �ۼ�
    
    2. 0���� 1������ ������ ���� ������Ƽ�� �����Ͻÿ�, ��, ������Ƽ �̸��� _Alpha �̴�.
    3. 2���� ������ ���꿡 ����ϱ� ���� ������ �Ͻÿ�
    4. _Alpha�� ���� ��� ��� ����ü�� �����Ͻÿ�
    
    */
    Properties //�ܺο� �����Ǵ� ���� : ���꿡 ����ϱ� ���� �ܺο��� �����ϱ� ����
    {
        _Color ("Color", Color) = (1,1,1,1)

        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0

        _Alpha ("_Alpha",Range(0,1))=1                        //2�� ����
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue"="Transparent"}              //6��
        /*
        ����Ÿ�԰� ����ť�� �����ؾ� �Ѵ�

        
        */


        LOD 200     //level of detail �Ÿ��� �ǹ�

        CGPROGRAM       //������ �ǹ�
        
        #pragma surface surf Standard alpha:fade                                                //5�� ����
        //Standard : ����Ǿ��ִ� ����
        //alpha:fade => ���ĺ��� �ɼ� 
        
        #pragma target 3.0

        //���꿡 ��� �� ������ ����ü ���� (������Ƽ�� ������ �͵��� ����)

        sampler2D _MainTex; //������Ƽ : _MainTex ("Albedo (RGB)", 2D) = "white" {} / ���÷�2D�� �����ؽ��� �ڷ��� ���

        //��ǲ ����ü : �׷��� ī�忡 ���޵Ǵ� �Է� ������ (������ �����ؾ� �Ѵ�)
        struct Input
        {
            float2 uv_MainTex; //=> �ؽ����� UV��ǥ�� �׷���ī�忡 ���޵Ǵ� �Է°� ( �������� �ʴ´� )
        };

        //flaot < half < fixed4

        half _Glossiness;       //Range�� ������ Half �� ����
        half _Metallic;

        fixed4 _Color;          //fixed4 �ڷ����� �÷����� ��� (half���� �� ���� �Ǽ�) : ƾƮ�÷�
        half _Alpha;            //3. ����

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutputStandard o) 
            //inout ���� ���� �ְ� ���� �� ����, SurfaceOutputStandard ��� ������ ����ü
        {
            // Albedo comes from a texture tinted by color

            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;        //�ؽ��Ŀ�uv�� �Ű������� ���޹޾Ƽ� ������ ���Ե� fixed4 ������ ��ȯ
                                                                        //�����ؽ����� ������ ȭ�鿡 ����ϱ� ���� fixed4 �������� �ٲ��ش�
                                                                        //�ؽ��İ� Ŭ���� ���귮�� ���� uv ��ǥ�� �����Ѵ�
                                                                        //���� ���� ������ ���ϱⰡ �ƴ϶� ���ϱ� �̴�. ���� ����
                                                                        //�������� �÷� ������ fixed4 �̰� ���� c�� ��Ƶд�
            /*o.Albedo = c.rgb;*/       //rgb �÷��� Albedo�� �����Ѵ�. Albedo : �������� ����� RGB �� (�ؽ��Ŀ� ƾƮ�÷��� ������ RGB)

            /*o.Albedo = float3(1,1,0);*/

            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
            o.Alpha = c.a;  //������� ����ü�� ���İ��� ������ ��.
            o.Emission = fixed3(0, 0, 1);           //1�� ����(�÷��� ���� ������ ��)
            o.Alpha = _Alpha;                       //4�� ����
        }
        ENDCG       //���� �ǹ�
    }
    FallBack "Diffuse"
}
