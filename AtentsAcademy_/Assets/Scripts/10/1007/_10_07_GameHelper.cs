using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class _10_07_GameHelper   //�����ϰ� �ϳ��� �����ص� �������
{   //���� ��ƿ��Ƽ�� ��Ƴ��� Ŭ����
        
    public static Vector3 GetHeightMapPos(Vector3 _origin)
    {
        Vector3 origin = _origin;   //�ʻ��� ��ġ�� �˾Ƴ��� ��
        origin.y += 200f;   //������ ���̸� �ø� ���¿��� �߻��Ѵ�
        RaycastHit hitInfo;
        int layerMask = 1 << LayerMask.NameToLayer("Player");       //�÷��̾ ����
        layerMask = ~layerMask;
        if(Physics.Raycast(origin,Vector3.down,out hitInfo, Mathf.Infinity,layerMask))
        {
            return hitInfo.point;
        }return Vector3.zero;
    }
 

}
