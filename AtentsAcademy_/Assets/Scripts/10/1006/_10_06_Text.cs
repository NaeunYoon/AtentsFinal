using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _10_06_Text : MonoBehaviour
{
    // Start is called before the first frame update

    public Text scoreText;
    string converSation;
    void Start()
    {
        //scoreText.text = "�������� <color=#ff0000>���</color>�� ��ġ���ּ���";

        converSation = "�������� <color=#ff0000>���</color>�� ��ġ���ּ���";
        scoreText.text =string.Empty;

        char [] arrayObj = converSation.ToCharArray();
        StartCoroutine(DisplayString(arrayObj));
    }

    //<color=#ff0000>��</color> <color=#ff0000>��</color> <color=#ff0000>��</color>
    IEnumerator DisplayString(char[]_arrayObj)
    {   string[] tmp = {"��","��","��","��","<color=#ff0000>��</color>", "<color=#ff0000>��</color>", "<color=#ff0000>��</color>",
            "��", "��","ġ","��","��","��","��"};
        for(int i=0;i< tmp.Length;i++)//(int i=0;i< arrayObj.Length;i++)
        {
            //scoreText.text += _arrayObj[i];
            yield return new WaitForSeconds(0.2f);
            scoreText.text += tmp[i];
        }
        
        



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}/*
  �ڷ�ƾ : ��Ƽ������� �ƴϳ� �����۾��� �� �� �ִ� ���
           ���� : StartCoroutine(�Լ�ȣ��)

    IEnumerator(){
    yield return new WaitForSeconds(float Time) : ���ϴ� �ð���ŭ ��ٸ��� ��
    yield return new WaitForSecondsRealTime(flaot Time) : TimeScale�� ������ ���� �ʰ� ���� �ð����� �۵�
    yield return new WaitForFixedUpdate() : ���� FixedUpdate�� ����� �� ���� ��ٸ���
    yield return new WaitForEndOfFrame(): �ϳ��� ������ ���� ������ ������ �� ȣ��
                                          Update,LateUpdate �̺�Ʈ�� ��� ����ǰ� ȭ�鿡 �������� ���� ���Ŀ� ȣ��
    yield return null; : ���� Update�� ����� �� ���� ��ٸ��ٴ� �ǹ�.
                         Update�� ���� ����ǰ� null�� ��ȯ�ߴ� �ڷ�ƾ�� �̾ ����� �� LateUpdate�� ����
    yield return new WaitUntil (System.Func<Bool>predicate); : Ư�� ���ǽ��� ������ �� ���� ��ٸ��� ���
                               ��ȯ������ �Ұ��� ��������Ʈ/���ٽ�

    }   

     yield return StartCoroutine(Ienumerator coroutine): �ڷ�ƾ ���ο��� �� �ٸ� �ڷ�ƾ�� ȣ��
                                                         �ڷ�ƾ�� �Ϸ�ɶ����� ��ٸ��� ���� �۾��� ����
    StopCoroutine(IEnumerator coroutine)
  
    ��ŸƮ �Լ��� IEnumerator Start �� �� �ִ�
  
  
  
  */
