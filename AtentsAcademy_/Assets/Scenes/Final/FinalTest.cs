using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class FinalTest 
{
    

    private string name="";
    private int age=0;
    private bool isfemale=true;
    private int level=0;
    private float health=0f;

    public string NAME
    {
        get { return name; }
        set { name = value; }
    }
    public int AGE  
    {
        get { return age; }
        set { age = value; }
    }
    public bool ISFEMALE
    {
        get { return isfemale; }
        set {isfemale = value; }
    }
    public int LEVEL
    {
        get { return level; }
        set { level = value; }
    }
    public float Health
    {
        get { return health; }
        set { health = value; }
    }



    private void Awake()
    {
        Debug.Log("인스턴스가 생성되었습니다");
        CharInfo();
        
    }
    void Start()
    {
        //Nothing();
        Attack(1);
        Defence(1);
        LevelUp(1);
        //StartCoroutine(PlayerInfo());
    }

    //public void Nothing()
    //{
    //    Attack(1);
    //    Defence(1);
    //    LevelUp(1);
    //    StartCoroutine(PlayerInfo());
    //}

    void Update()
    {
        
    }

    public void Attack(float attackDamage)
    {
        
        Debug.Log("공격함수 출력");
    }
    public void Defence(float defence)
    {
        Debug.Log("방어함수 출력");
    }
    public void LevelUp(int lev)
    {
        LEVEL = lev;
        Debug.Log("LevelUp 출력");
    }

    public void CharInfo()
    {
        NAME = "윤나은";
        AGE = 29;
        ISFEMALE = true;
        LEVEL = 0;
        Health = 100;
    }

    //public IEnumerator PlayerInfo()
    //{
    //    yield return new WaitForSeconds(3f);
    //    Debug.Log("3초경과 되었습니다");
    //    Debug.Log($"이름은 = {NAME} 입니다");
    //    Debug.Log($"나이는 = {AGE} 입니다");
    //    Debug.Log($"성별은 = {ISFEMALE} 입니다");
    //    Debug.Log($"레벨은 = {LEVEL} 입니다");
    //    Debug.Log($"체력은 = {Health} 입니다");
    //}

}
