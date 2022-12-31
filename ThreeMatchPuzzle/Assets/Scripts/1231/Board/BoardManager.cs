using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BoardManager : MonoBehaviour
{

    /*
     1. �� ���� ������Ʈ�� ������Ų��
     2. �� �������� �ִ´�
     3. MakeBoard �Լ��� ����� ( �÷��� �ο� ���� �޾Ƽ� �������� �����ϴ� �ڵ�)
        (������ �������� ��ġ�Ѵ� => 0,0���� �������� ���� ��ġ��)
     4. �����ִ� ȭ���� ��ũ����ǥ 2d ������ ���� ��ġ�ϰ� �ִ� ������ 3d �����̴�

    1. ���� ��ũ����ǥ�踦 ���� ��ǥ�� ���Ѵ�

    ��ü ����� ���ϴ� �� 0.0 �� -2.8, 5,0 �̱� ������
    ��ü width ���� 5.6 height �� 10�̴�.
     */
    [SerializeField] private GameObject _blockPrefab;
    private Vector3 _screenPos; //��ũ�� 0,0 ���� ���� ��ǥ�� ����
    private float _screenwidth;   //��ũ���� ����
    private float _blockWidth; //���� ����
    private Vector3 _screenheight; //��ũ���� ����
    void Start()
    {
        //��ũ�� 0,0 ��ǥ�� ���� �������� ��ǥ������ ��ȯ 
        _screenPos = Camera.main.ScreenToWorldPoint(new Vector3(0f,0f,10f));
        Debug.Log("ScreenPos "+_screenPos);
        //3D �������� �߾��� 0.0 �̶�� �ϸ� 
        //����������� ���ϴ��� -2.8, -5.0, 0.0
        //����������� �»���� -2.8, 5.0, 0.0
        //����������� ������ 2.8,5,0
        //����������� ���ϴ��� 2.8 -5,0
        _screenPos.y = -_screenPos.y;
        _screenwidth = Mathf.Abs(_screenPos.x * 2); //��ũ���� �ʺ� ���Ѵ�
        //�� �̹����� �ȼ����� 100���� ������ �� ���̸� ���Ѵ�
        //�̹��� ũ�Ⱑ 100 �̶�� �� �� �ȼ��� ������ �ʺ�� 100 ���̷� 100�� �ִٴ� ���̴�
        //�װ��� 3d �������� �ʺ����� �ٲٴ� ����� �ȼ����� 100���� ������ �ȴ�
        //�ȼ����� 1000�̸� �̹����� �ʺ� 10�� �Ǵ� ���̵�
        //�ȼ����� 50�̸� �̹����� �ʺ� 0.5�� �Ǵ� ���̴�
        //����Ƽ �⺻���� 100�̱� ������ 100���� ���� ���̴�
        //100�ȼ��� 1�����̰� 1�����̴� => ����Ƽ����
        _blockWidth = _blockPrefab.GetComponent<Block>().blockImage.sprite.rect.size.x / 100;   //���� width�� ��������

        //���鰪�� �Է��ϰ� ����� ����ϰ��� ��


        MakeBoard(10,10);
    }

    void MakeBoard(int column, int row)
    {
        float width = _screenwidth;  //��µǴ� �ʺ� ( ������ ����)
        //���� ��� �ʺ� = ���� �ʺ� * ��ü ����
        float blockWidth = _blockWidth * row;
        //���� ���̿��� ��ũ���� ���̸� ������ ���� ����� ������ �� �ִ�
        float _blockScale = width / blockWidth; //���� ������ ��

        for (int co = 0; co < column; co++)
        {
            for (int ro = 0; ro < row; ro++)
            {
                GameObject blockObj = Instantiate<GameObject>(_blockPrefab);
                blockObj.transform.localEulerAngles = new Vector3(_blockScale,_blockScale, 0f);
                blockObj.transform.position = new Vector3(_screenPos.x+ro + 0.5f ,_screenPos.y - co -0.5f, 0f);
            }
        }
    }

    void Update()
    {
        
    }
}
