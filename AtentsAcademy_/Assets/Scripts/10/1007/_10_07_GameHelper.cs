using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class _10_07_GameHelper   //유일하게 하나만 존재해도 상관없음
{   //게임 유틸리티를 모아놓은 클래스
        
    public static Vector3 GetHeightMapPos(Vector3 _origin)
    {
        Vector3 origin = _origin;   //맵상의 위치를 알아내는 것
        origin.y += 200f;   //광선의 높이를 올린 상태에서 발사한다
        RaycastHit hitInfo;
        int layerMask = 1 << LayerMask.NameToLayer("Player");       //플레이어만 제외
        layerMask = ~layerMask;
        if(Physics.Raycast(origin,Vector3.down,out hitInfo, Mathf.Infinity,layerMask))
        {
            return hitInfo.point;
        }return Vector3.zero;
    }
 

}
