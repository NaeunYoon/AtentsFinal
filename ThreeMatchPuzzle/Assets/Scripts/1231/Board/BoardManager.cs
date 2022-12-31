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
    private float _screenWidth;   //��ũ���� ����
    private float _blockWidth; //���� ����
    //private Vector3 _screenheight; //��ũ���� ����

    public float _xMargin=2f;
    public float _yMargin=4f;
    private float _blockScale = 0.0f;    // ���� ������ �� ����
    public Transform _parents;

    private GameObject[,] _gameBoard; //���� ����� ����

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
        _screenWidth = Mathf.Abs(_screenPos.x * 2); //��ũ���� �ʺ� ���Ѵ�
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
        float width = _screenWidth - (_xMargin*2);  //��µǴ� �ʺ� ( ������ ����)
        //���� ��� �ʺ� = ���� �ʺ� * ��ü ����
        float blockWidth = _blockWidth * row;
        //���� ���̿��� ��ũ���� ���̸� ������ ���� ����� ������ �� �ִ�
        _blockScale = width / blockWidth; //���� ������ ��
        _gameBoard = new GameObject[column, row];
        for (int co = 0; co < column; co++)
        {
            for (int ro = 0; ro < row; ro++)
            {
                _gameBoard[co,ro] = Instantiate<GameObject>(_blockPrefab);
                _gameBoard[co, ro].transform.SetParent(_parents);
                _gameBoard[co, ro].transform.localScale = new Vector3(_blockScale, _blockScale, 0f);
                _gameBoard[co, ro].transform.position = new Vector3(_screenPos.x + _xMargin + ro * (_blockWidth * _blockScale) + (_blockWidth * _blockScale / 2f),
                                                         _screenPos.y - _yMargin - co * (_blockWidth * _blockScale) - (_blockWidth * _blockScale / 2f),
                                                          0f);
                _gameBoard[co, ro].GetComponent<Block>().Width = _blockWidth*_blockScale;
                _gameBoard[co, ro].GetComponent<Block>().MovePos = _gameBoard[co, ro].transform.position;
                //_gameBoard[co, ro].GetComponent<Block>().Move(DIRECTION.LEFT);

                //GameObject blockObj = Instantiate<GameObject>(_blockPrefab);
                //blockObj.transform.SetParent(_parents);
                //blockObj.transform.localScale = new Vector3(_blockScale,_blockScale, 0f);
                //blockObj.transform.position = new Vector3(_screenPos.x + _xMargin + ro*(_blockWidth*_blockScale) + (_blockWidth * _blockScale/2f) ,
                //                                          _screenPos.y - _yMargin - co * (_blockWidth * _blockScale) - (_blockWidth * _blockScale / 2f),
                //                                          0f);
                //blockObj.GetComponent<Block>().Width = _blockWidth; //���� �ʺ��� ���� ����
                //blockObj.GetComponent<Block>().MovePos = blockObj.transform.position;   //������ġ�� ����
                //blockObj.GetComponent<Block>().Move(DIRECTION.LEFT);    
            }
        }
    }

    public void MoveBlocksLeft()
    {
        foreach (var item in _gameBoard)
        {
            item.GetComponent<Block>().Move(DIRECTION.LEFT);
        }
    }
    public void MoveBlocksRight()
    {
        foreach (var item in _gameBoard)
        {
            item.GetComponent<Block>().Move(DIRECTION.RIGHT);
        }
    }
    public void MoveBlocksUp()
    {
        foreach (var item in _gameBoard)
        {
            item.GetComponent<Block>().Move(DIRECTION.UP);
        }
    }
    public void MoveBlocksDown()
    {
        foreach (var item in _gameBoard)
        {
            item.GetComponent<Block>().Move(DIRECTION.DOWN);
        }
    }


    void Update()
    {
        
    }
}
