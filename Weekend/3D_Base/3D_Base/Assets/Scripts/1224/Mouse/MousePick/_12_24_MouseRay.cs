using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class _12_24_MouseRay : MonoBehaviour
{
    [SerializeField] private GameObject obj;

    void Start()
    {
        
    }

    void Update()
    {
        //마우스로 찍은 스크린 좌표계를 광선으로 만들어 준다
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //이 직선과 교차하는 지점을 찾는다
        RaycastHit hitInfo;
        //교차한 지점을 전달
        //만들어진 광선을 넣고, 부딫힌 물체에 대한 정보를 넣는다
        if(Physics.Raycast(ray,out hitInfo))
        {
            Debug.Log("HitPoint = "+ hitInfo.point);
            //교차점의 위치를 찾아서 이동
            obj.GetComponent<_12_24_MouseMoveSlow>().SetPosition(hitInfo.point);
            Debug.Log(hitInfo.collider.gameObject.name);
            //교차점의 콜라이더를 삭제
            //Destroy(hitInfo.collider.gameObject);
        }
    }
}
