using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _09_30_UIUX : MonoBehaviour
{
    /*
     ��ȹ���� ���Խ��Ѿ� �� ����

    �����÷����� Ư¡�� ����� ������ ���⼺�� ���
    ��ü ����ȭ���� ���� �� �帧
    ȭ�� ������ ����ȭ�� �̹����� ����
    ���� ���� ����ȯ�濡 ������ ȭ�� �̹��� ����

    ���η������� �̿���....(?
     

    1. ť���� �������� ���� �߻�Ǵ� ray�� �̿��Ͽ� Ÿ�������� ����
    2. ������ ������ 4�ʸ��� �ѹ��� ���ӿ�����Ʈ capsule�� �����ϰ� �÷��̾�(ť��) �������� �̵��ϴ� ���͸� ����
       ���͸� �����ϴ� ����?
       ���Ϳ��Դ� ��ũ��Ʈ�� �ʿ��ұ��?
       ���͸� �����̰� �ϴ� ����?
    3. ť���� ������ ���Ϳ� �ε����� ��� ���ʹ� �����ȴ�

    => ������ �ٽ��� ������ �����Ӱ� ����ĳ��Ʈ���� ����ϴ� ���̿��� �������� ���ƾ���

            ���͸� �����Ű�� ���ӿ�����Ʈ�� �ʿ�
     
     */

    //���η������� �˰� �־�� ��
    public LineRenderer lineRenderer;
    Vector3 end;    //����
    Vector3 targetPos; //��ǥ����
    float moveSpeed;
    void Start()
    {
        lineRenderer.SetPosition(0,transform.position); //���η������� �������� �� ��ġ�� ��
        end = transform.position;
        /*targetPos = new Vector3(transform.position.x, transform.position.y,10f);*/    //z������ 10��ŭ �̵�
        moveSpeed = 6f;
        FindTargetPosition();

    }

   
    void Update()
    {
        FindTargetPosition();
        DrawLine();
        FindInterSectionPosition();
        end = Vector3.MoveTowards(end, targetPos, Time.deltaTime * moveSpeed);
        lineRenderer.SetPosition(1,end);
    }

    void FindTargetPosition()       //Ÿ�ٰ� �ε����� ��
    {
        RaycastHit hitInfo;
        if(Physics.Raycast(transform.position,transform.forward,out hitInfo, Mathf.Infinity))
        {
            targetPos = hitInfo.point;      //�������� Ÿ�������ǿ� ������
            Debug.Log(targetPos);
        }
    }

    void DrawLine()
    {
        Debug.DrawRay(transform.position, transform.forward,Color.blue);
    }

    void FindInterSectionPosition()
    {
        Vector3 dir = end - transform.position;
        RaycastHit hitInfo;
        if(Physics.Raycast(transform.position,dir.normalized,out hitInfo, Mathf.Infinity))
        {
            if (hitInfo.collider.CompareTag("Monster"))
            {
                GameObject.Destroy(hitInfo.collider.gameObject);

            }
            targetPos = hitInfo.point;
            lineRenderer.SetPosition(0, transform.position);
        }

    }
}
