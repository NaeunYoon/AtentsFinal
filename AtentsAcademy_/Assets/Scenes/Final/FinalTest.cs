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
        Debug.Log("�ν��Ͻ��� �����Ǿ����ϴ�");
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
        
        Debug.Log("�����Լ� ���");
    }
    public void Defence(float defence)
    {
        Debug.Log("����Լ� ���");
    }
    public void LevelUp(int lev)
    {
        LEVEL = lev;
        Debug.Log("LevelUp ���");
    }

    public void CharInfo()
    {
        NAME = "������";
        AGE = 29;
        ISFEMALE = true;
        LEVEL = 0;
        Health = 100;
    }

    //public IEnumerator PlayerInfo()
    //{
    //    yield return new WaitForSeconds(3f);
    //    Debug.Log("3�ʰ�� �Ǿ����ϴ�");
    //    Debug.Log($"�̸��� = {NAME} �Դϴ�");
    //    Debug.Log($"���̴� = {AGE} �Դϴ�");
    //    Debug.Log($"������ = {ISFEMALE} �Դϴ�");
    //    Debug.Log($"������ = {LEVEL} �Դϴ�");
    //    Debug.Log($"ü���� = {Health} �Դϴ�");
    //}

}
