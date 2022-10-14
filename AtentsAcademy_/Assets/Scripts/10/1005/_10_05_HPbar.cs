using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _10_05_HPbar : MonoBehaviour
{
    /*
     ĵ���� ����
    1. ��ũ������ - �������� ���� : ĵ������ ȭ�鿡 �°� ������ �� �Ŀ� ���̳� ī�޶��� ���۷��� ���� ���� ������
                                    ��ũ���� ũ�⳪ �ػ󵵰� ����Ǹ� ui�� �ڵ����� ���� ������

       ��ũ������ - ī�޶���� : ĵ������ �־��� ī�޶� �տ��� ��� ���� �Ÿ��� �ִ� ��� ��ü�� �׷��� ��ó�� ������
                                 �������� ȭ�� ũ��� ī�޶� ����ü ���� ��Ȯ�� �°� �����ǹǷ� �׻� �Ÿ��� ���� �ٸ�
                                 ȭ���� ũ�⳪ �ػ� �Ǵ� ī�޶� ����ü�� ����Ǹ� ui�� �ڵ����� ����

       ������� ���� : ui�� ����� ��� ��üó�� ������
                       ��ũ������ ���� �޸� ����� ī�޶� ���� �ʿ䰡 ������ ���ϴ´�� ������ ����
                       ĵ������ ũ��� ��Ʈ Ʈ�������� ����Ͽ� ������ �� ������ ȭ��ũ��� ī�޶��� �þ߰� �� �Ÿ��� ���� �ٸ�
                       �ٸ� ��� ��ü�� ĵ������ ����� �� ����

       ���� Ʈ������ : ui���� transform, ui�� ��ġ ȸ�� ������ ��Ŀ ������Ƽ ���� ���ԵǾ� �ִ�
       ��Ŀ : ui�� �������� �ǹ��Ѵ�
       Image : UI�� �̹����� ����ϴ� ������Ʈ
               SourceImage : 2d sprite ����
               Color
               Material

       ImageType : simple : ��ü �̹����� ������
                   sliced : 9 �����̽�
                   tiled : ���� �̹����� ũ�⿡ �µ��� �������Ͽ� ä��
                   filed : �̹����� �Ϻθ� �����ִ� ���
       ScrollView : ScrollRect : ��ũ�Ѻ��� �Ӽ��� ���� 
                    ViewPort : ����Ʈ ���� ������ ȭ�鿡�� �׷����� �ʰ� ����Ʈ ���� ������ ȭ�鿡 ����
                    Content : ���� ��ũ�� ������ ������ �������� ��ũ�ѵǴ� ������ �߰�

       Text : TextComponent : ui ���� ���ڸ� ����ϴ� ������Ʈ ( ��Ʈ ����ũ�� ���� ���Ĺ�� ����)
              OutLine : �ؽ�Ʈ�� �ܰ��� ����
       Button : Image :ui ���� �̹����� ����ϴ� ������Ʈ /�̹����� Ÿ���� sprite 2D ����
                Button : ��ư �̺�Ʈ ó��
                Text : ��ư�� �̸��� ������ �� ���
       EventMethod : ��ư Ŭ������ �� ȣ��Ǵ� �޼ҵ�
                     1) + ��ư Ŭ��
                     2) ���� ������Ʈ ���(Runtime Only)
                     3) ��ũ��Ʈ�� �޼ҵ� ����

     
     */




    public Image hpimg;
    Vector3 screenPos;
    public Transform hpPosition;
    public Image frame;
    private void Awake()
    {
        
    }
    void Start()
    {
        screenPos = Camera.main.WorldToScreenPoint(hpPosition.transform.position); //��������� ��ǥ�� ���� ��ġ�� ȭ����ǥ�� ��ȯ 
    }

    
    void Update()
    {
        hpimg.transform.position = screenPos;       //��Ʈ Ʈ�������� ����ص� �������
        frame.transform.position = screenPos;
        screenPos = Camera.main.WorldToScreenPoint(hpPosition.transform.position); //��������� ��ǥ�� ���� ��ġ�� ȭ����ǥ�� ��ȯ 
        hpimg.fillAmount -= Time.deltaTime;
    }
}
