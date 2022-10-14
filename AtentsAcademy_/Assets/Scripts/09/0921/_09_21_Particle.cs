using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _09_21_Particle : MonoBehaviour
{
    /*
     ����ִ� ������Ʈ�� ��ƼŬ �ý����̶�� ������Ʈ�� �߰��ϸ� ������ �� ����
     ����Ʈ �����̳ʰ� �� ������ ����Ѵ�
     ����Ʈ�� ù���� �θ� ������Ʈ�� �ƹ��͵� ������ ���� �ʴ�

     ��ƼŬ�� ũ�⸦ Ű��� ����� �������� Ű��� ���̴�


     Resource ���� ���� fireeffect�� �����̽��ٸ� ���� ��� ������ ���� �ڽ����� �߰��Ͻÿ�

     */
    GameObject rcRhandEffect;
    Transform rHandDummy;
    //���ȣ��� �˻��ϰų� ��θ� �ϳ��ϳ� ġ���� �ؾ��� (��θ� ����ϰ� �ִ� ���)
    //string effectDummyPath = "Fox/FoxTransform/Fox_Pelvis/Fox_Spine1/Fox_Spine2/Fox_Ribcage/Fox_F_RLeg1/Fox_F_RLeg2/Fox_F_RLegAnkle/Fox_F_RLegDigit11/RHandEffect";
    string effectDummyPath1 = "RHandEffect";


    private void Awake()
    {
        rcRhandEffect = Resources.Load<GameObject>("Effect/FireEffect");
        //rHandDummy = GameObject.Find(effectDummyPath).transform;
        //GameObject.Find �Լ��� ���� : ���� ������Ʈ ��ü�� �˻��Ѵ�
                           //Ȱ��ȭ �� ���� ������Ʈ�� �˻��Ѵ�
                           //��Ȱ��ȭ �� ���ӿ�����Ʈ�� ��� Transform�� ����Լ��� ����Ͽ� �˻��Ѵ�


        /*rHandDummy= FindChildTransform("RHandEffect", transform);*///�Լ��� ��θ� ã�� ��
        rHandDummy = FindChildTransform(effectDummyPath1, transform);//�Լ��� ��θ� ã�� ��
    }

    void Start()
    {
        
    }

    public Transform FindChildTransform(string _nodeName, Transform _origin)        //���ȣ�� ����Ͽ� ��� ã�� nodeName�� ������ �ִ� _origin�� ã�ڴ�
        //���ȣ�⿡�� ������ �׻� �־�� �Ѵ� (���� ��Ȯ�ϰ�) ���ȣ���� ���������� �ݺ��Ǹ� ���� �����÷ο찡 �߻��Ѵ�.
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
