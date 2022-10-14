using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _09_07_ShaderFind : MonoBehaviour
{
    /*
     
    �ȼ����̴� (���ǽ� ���̴� ) : �޸� ���� ������ ȭ���� ����� ���� �� �̿� ������ ����, ������ �׸� �� �ִ� �޸� ����
    fx : ����� �۷��� ȿ�� ���̴�
    GUI : UI ���̴�
    Mobile : ����� ����̽��� ���� ���� ���̴�
    Nature : ���� �� �ͷ����� ���� ���̴�
    Particle :  ��ƼŬ �ý��� ȿ�� ���̴�
    Skybox : ���ȭ���� ���� ���̴�
    Sprite :2D Sprite �ý����� ���� ���̴�
    Toon : ī�� ��Ÿ�� �������� ���� ���̴�
    Unlit : ��� ����� �׸��ڸ� ������ �����ϴ� ���̴�
    Legacy : ���ٴٵ� ���̴��� ��ü�� ���� ���̴� �÷���
     
    ���� : �л� ���ݻ� ...

    �÷��� ���ڷ� ǥ���ϴ� ��� RGB(100%,100%,100%) = RGB(255,255,255) = float3(1.0,1.0,1.0) : �� ������ �ִ��� 1�̴�.


     ���̴��� �ǽð����� ��ü�ϴ� ���α׷� �ۼ�
     */

    
    void Start()
    {
        //Renderer��� �̸��� ������Ʈ�� �ڽ��� ���ӿ�����Ʈ���� GetComponent

        SkinnedMeshRenderer renderer = gameObject.GetComponentInChildren<SkinnedMeshRenderer>();    //�Ѵܰ� �Ʒ��� �ƴ϶� �Ʒ� �Ʒ��� ���
        if(renderer != null)
        {   //�ǽð� ���̴� ��ü ���
            renderer.material.shader = Shader.Find("Mobile/Diffuse");
        }

        //SkinnedMeshRenderer renderer = GetComponentInParent<SkinnedMeshRenderer>();
        List<SkinnedMeshRenderer> resultList = new List<SkinnedMeshRenderer>();
        //GetComponentInChildren<SkinnedMeshRenderer>(resultList);
        foreach(SkinnedMeshRenderer one in resultList)
        {
            Debug.Log(one);

        }


    }

    //Transform FindGameObjectInChild(string _name, Transform _tr)
    //{

    //}
    
    void Update()
    {
        
    }
}
