using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _09_21_Particle : MonoBehaviour
{
    /*
     비어있는 오브젝트에 파티클 시스템이라는 컴포넌트를 추가하면 뭔가가 막 날림
     이펙트 디자이너가 이 영역을 담당한다
     이펙트의 첫번쨰 부모 오브젝트는 아무것도 가지고 있지 않다

     파티클의 크기를 키우는 방법은 스케일을 키우는 것이다


     Resource 폴더 안의 fireeffect를 스페이스바를 누를 경우 오른손 더미 자식으로 추가하시오

     */
    GameObject rcRhandEffect;
    Transform rHandDummy;
    //재귀호출로 검색하거나 경로를 하나하나 치던가 해야함 (경로를 기억하고 있는 방법)
    //string effectDummyPath = "Fox/FoxTransform/Fox_Pelvis/Fox_Spine1/Fox_Spine2/Fox_Ribcage/Fox_F_RLeg1/Fox_F_RLeg2/Fox_F_RLegAnkle/Fox_F_RLegDigit11/RHandEffect";
    string effectDummyPath1 = "RHandEffect";


    private void Awake()
    {
        rcRhandEffect = Resources.Load<GameObject>("Effect/FireEffect");
        //rHandDummy = GameObject.Find(effectDummyPath).transform;
        //GameObject.Find 함수의 단점 : 씬의 오브젝트 전체를 검사한다
                           //활성화 된 게임 오브젝트만 검사한다
                           //비활성화 된 게임오브젝트일 경우 Transform의 멤버함수를 사용하여 검색한다


        /*rHandDummy= FindChildTransform("RHandEffect", transform);*///함수로 경로를 찾을 때
        rHandDummy = FindChildTransform(effectDummyPath1, transform);//함수로 경로를 찾을 때
    }

    void Start()
    {
        
    }

    public Transform FindChildTransform(string _nodeName, Transform _origin)        //재귀호출 사용하여 경로 찾기 nodeName을 가지고 있는 _origin을 찾겠다
        //재귀호출에는 리턴이 항상 있어야 한다 (끝이 명확하게) 재귀호출이 무한적으로 반복되면 스택 오버플로우가 발생한다.
    {
        if(_origin.name == _nodeName)
        {
            return _origin;
        }
        for(int i =0; i<_origin.childCount; i++)
        {
            Transform findTr = FindChildTransform(_nodeName, _origin.GetChild(i));
            if(findTr != null)
            {
                return findTr;
            }
        }
        return null;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject ins_effect = GameObject.Instantiate<GameObject>(rcRhandEffect, rHandDummy.position, Quaternion.identity, rHandDummy);
            //rcRhandEffect.transform.position = rHandDummy.transform.position;
            //rcRhandEffect.transform.SetParent(rHandDummy);
        }
    }
}
