using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Character : MonoBehaviour
{

    FinalTest final = new FinalTest();
    private void Awake()
    {
        Debug.Log("�ν��Ͻ��� �����Ǿ����ϴ�");
        final.CharInfo();
    }

    
    void Start()
    {
        final.Attack(1);
        final.Defence(1);
        final.LevelUp(1);
        StartCoroutine(PlayerInfo());

    }

    void Update()
    {
        
    }

    public IEnumerator PlayerInfo()
    {
        yield return new WaitForSeconds(3f);
        Debug.Log("3�ʰ�� �Ǿ����ϴ�");
        Debug.Log($"�̸��� = {final.NAME} �Դϴ�");
        Debug.Log($"���̴� = {final.AGE} �Դϴ�");
        Debug.Log($"������ = {final.ISFEMALE} �Դϴ�");
        Debug.Log($"������ = {final.LEVEL} �Դϴ�");
        Debug.Log($"ü���� = {final.Health} �Դϴ�");
    }

}
