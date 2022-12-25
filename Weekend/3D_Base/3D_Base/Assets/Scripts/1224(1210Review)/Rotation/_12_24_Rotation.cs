using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _12_24_Rotation : MonoBehaviour
{

    /*ȸ����Ų�ٴ� ���� �����̼��� x,y,z ���� �����ϴ� ���̴�
      ȸ���� �Ϸ���, 
     
     */

    private float yrot = 0f;
    private float xrot = 0f;

    void Start()
    {
        
    }

    void Update()
    {
        /*
         ���Ϸ� ������ : ������ ���� ���� ȸ���Ѵ� (���ε��� ��Ų��) �̷� ��� ������ ������ �߻��Ѵ�
        => ���� �ϳ��� ������������ ������ �߻��Ѵ�.
        => ������ ������ �����ϱ� ���� ���ʹϾ� (�����) �� ����Ѵ�
        => x,y,z �� �Ѳ����� ȸ���� ��Ų�� 
        
         */

        //�� �� �ٲ�
        //this.transform.rotation = Quaternion.Euler(30f, 60f, 30f);

        //���Ϸ����� �Է¹޾� ���ʹϾ����� �ٲ��ְ� �����̼ǿ� �������ش�


        //��� ȸ���ϰ� �ʹٸ�?
        yrot += 30f * Time.deltaTime;
        xrot += 20f * Time.deltaTime;
        this.transform.rotation = Quaternion.Euler(xrot, yrot, 0f);
    }
}
