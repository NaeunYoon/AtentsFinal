using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _09_20_GPU_Instancing : MonoBehaviour
{
    /*
    [GPU Instancing] : ������ �޽��� �������� �ѹ��� �׸��ų� ������ �ϴ� ��, ������ �ݺ������� ��Ÿ���� �ǹ� Ǯ ������ ���� ���� �׸� �� ����
    MeshRenderer�� ����ϴ� ���� ������Ʈ������ �����ϰ� ��ο� ���� �ٿ��ش�

    �ν����� â���� ��� ���� (Material > enable GPU Instancing üũ)
    GPU Instancing ���̴� ���α׷� �ڵ� �ۼ� (���̴��� ������Ʈ material�� ����)
    ������Ʈ�� ���������� ����� ���ҽ� ������ ����
    ������ ������Ƽ ���� ��� (�� ������Ʈ�� ��ũ��Ʈ �߰�)

    ����Ҹ��� ������ �ڵ带 ������ �־����~~~!
    1. ���콺 ���� ��ư ���� �� gpu Instancing ����� ����� ���� ������Ʈ ����
    2. ȭ��󿡼� ���� ������Ʈ ���� �� ������ ���� ������Ʈ�� �÷��� �������� �����ϴ� ���α׷� �ڵ� �ۼ�

    ������ �ٽ��� gpu instancing ����� ����ϴ� ���� ������Ʈ�� ������ ���� �� ����


     */

    List<GameObject> objects;

    void Start()
    {
        objects = new List<GameObject>();       

        GameObject tmp = Resources.Load<GameObject>("Sphere");      //���ӿ�����Ʈ�� ���ҽ� ������ �����ϰ� �ҷ��´�
        for(int i = 0; i<10; i++)
        {
            GameObject createObjects = GameObject.Instantiate<GameObject>(tmp);     //�����Ǿ��ִ� ������Ʈ���� �ν��Ͻÿ���Ʈ �Ѵ�
            objects.Add(createObjects);         // �ν��Ͻÿ���Ʈ �� ������Ʈ���� ����Ʈ�� �߰��Ѵ�
        }

        MaterialPropertyBlock props = new MaterialPropertyBlock();  //�ڷ���    //�������ݷ��Ͱ� �۵���..�ѹ� �� �� ���� �Ʋ������
        MeshRenderer renderer;

        foreach (GameObject obj in objects)     //����Ʈ�� �߰��� ������Ʈ���� �ݺ����� ������
        {
            float r = Random.Range(0.0f, 1.0f);         //�÷� ����(RGB ���� �������� �ٲ�)
            float g = Random.Range(0.0f, 1.0f);
            float b = Random.Range(0.0f, 1.0f);

            /*������Ƽ ����� ����ϴ� ����(�߿�) */

            props.SetColor("_Color", new Color(r, g, b));           //�÷���� ������Ƽ ��� Ȱ��ȭ

            renderer = obj.GetComponent<MeshRenderer>();        //�������� ���� �����ͼ� 
            renderer.SetPropertyBlock(props);               //�� ������Ƽ ����� ���ش�(�ٰ� ���� ���� �ٸ��� �ؾ���)
        }
    }

    //=>ȭ�鿡 10���� �������� ���� �� �ٸ� ���·� �����ȴ�

    
    void Update()
    {
        
    }
}
