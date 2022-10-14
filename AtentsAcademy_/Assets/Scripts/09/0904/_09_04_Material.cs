using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _09_04_Material : MonoBehaviour
{
    /*
     ���� : �ؽ���, ��ü�� ����� ���� ���� �������� �÷��� ���õ� ��� ������ �����ϴ� ����
            ���� �������� ��� ���ӿ�����Ʈ�� ���͸���1�� �̻��� ����
            ������ ������ ��ο��ݰ����
            ����Ƽ���� �������� Renderer ������Ʈ���� ���� �� ����
            �ؽ��ĸ� �����Ϸ��� -> Renderer > Material > Texture 



     */

    public GameObject Cube;         //1. ���ӿ�����Ʈ�� �����س�����
    Texture2D rcTexture1;
    Texture2D rcTexture2;

    void Start()
    {
        rcTexture1 = Resources.Load<Texture2D>("Meshtint Free Knight");
        rcTexture2 = Resources.Load<Texture2D>("Substance_graph_ambientOcclusion");

    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            //�ؽ��Ŀ� �����Ϸ���, ���͸��� ����
            Cube.GetComponent<MeshRenderer>().material.SetTexture("_MainTex",rcTexture1);    //�Լ� : _MainTex(���͸��� ����� ���̴��� ������Ƽ �̸� / �ʼ�)

            /*Cube.GetComponent<MeshRenderer>().material.mainTexture=rcTexture1;*/     //������Ƽ
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            Cube.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", rcTexture2);

            /*Cube.GetComponent<MeshRenderer>().material.mainTexture = rcTexture2;*/    //������Ƽ
        }
        //�ؽ��Ŀ� �������� �����ϴ� �ڵ�
        Vector2 textureOffset = Cube.GetComponent<MeshRenderer>().material.mainTextureOffset;
        textureOffset.x += Time.deltaTime;
        Cube.GetComponent<MeshRenderer>().material.mainTextureOffset = textureOffset;
    }
}
