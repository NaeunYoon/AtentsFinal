using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Character : MonoBehaviour
{

    FinalTest final = new FinalTest();
    private void Awake()
    {
        Debug.Log("인스턴스가 생성되었습니다");
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
        Debug.Log("3초경과 되었습니다");
        Debug.Log($"이름은 = {final.NAME} 입니다");
        Debug.Log($"나이는 = {final.AGE} 입니다");
        Debug.Log($"성별은 = {final.ISFEMALE} 입니다");
        Debug.Log($"레벨은 = {final.LEVEL} 입니다");
        Debug.Log($"체력은 = {final.Health} 입니다");
    }

}
