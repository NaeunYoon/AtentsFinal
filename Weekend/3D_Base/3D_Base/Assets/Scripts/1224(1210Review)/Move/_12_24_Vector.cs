using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _12_24_Vector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Vectoe�� �̿��ؼ� �̵�
        //Vector �� ����� ũ�⸦ ���� ������ (�������� 5����)   
        //transform.position += new Vector3(0.01f, 0.01f, 0.0f);
        //x������ 0.01, y������ 0.01 �̵�

        transform.position += new Vector3(1.0f, 1.0f, 0.0f) * Time.deltaTime;
        //��ŸŸ�� : ������Ʈ�� ȣ��ǰ�, ���� ������Ʈ�� ȣ�� �� �� ���� �ɸ��� �ð�
        //���� �ý��ۿ����� ��ŸŸ���� ������ ���� �ý��ۿ����� ��ŸŸ���� ���
        //�츮�� ���ϴ°� ��� �ý��ۿ����� 1�ʿ� �̵��ϴ� �ð��� �����ϱ� ���ϱ� ������ 
        //����Ǵ� ��ŸŸ�Կ� ��ŸŸ���� ���ؼ� �����ϰ� �����̰� ������ش�

        //Ÿ�� ��ü ���� Ÿ�ӵ�
        Time.fixedDeltaTime = 0.5f; //0.02�ʸ��� ȣ��
        Time.timeScale = 0.5f;  //���ο��� ó���� �� (1�� ������)
                                //���� ��� ó���� �� (2�� ����)
                                //��ü���� ������Ʈ �ð� ����

    }
}
