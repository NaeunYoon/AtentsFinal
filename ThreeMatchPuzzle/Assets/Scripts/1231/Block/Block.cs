using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public enum DIRECTION1
{
    LEFT,
    RIGHT,
    UP,
    DOWN
}
public enum BLOCKSTATE1  //���� ���¸� ��Ÿ���� (���� �̵����̸� �̵��� ���� �Ŀ� �̵��� ��Ű�� �ϱ� ���ؼ�)
{
    STOP,
    MOVE
}

public class Block : MonoBehaviour
{
    //[SerializeField] : private �ε�, �����ͻ󿡼� ������ �����ϴ�. (��ȹ�ڰ� �ǵ���� �� ������ �ν�����â�� ���̵��� ������ �Ѵ�)
    //=============================================================================================01
    //�� �̹����� �����´�
    [SerializeField] private SpriteRenderer _blockImage;
    //==============================================================================================02
    //�ܺο��� ������ �� �ֵ��� ������Ƽ�� ������ش� (�����տ� ��ũ��Ʈ�� �����Ѵ�)
    public SpriteRenderer blockImage    //������Ƽ ����
    {
        get { return _blockImage; }
    }
    public float Width { get; set; }    //�� �ʺ� ����
    private Vector3 _movePos; //���� �̵��� ��ġ���� ����
    public Vector3 MovePos
    {
        get { return _movePos; }
        set { _movePos = value; } 
    }

    private DIRECTION direction;
    public float SPEED
    { set; get; } = 0.01f;


    public BLOCKSTATE CURRENTSTATE 
    { set; 
      get; } = BLOCKSTATE.STOP;

    //20230107
    public int _column { set; get; }
    public int _row { set; get; }

    //�̹����� Ÿ���� �������ش� (������Ƽ)
    public int Type { set; get; }


    void Start()
    {
        
    }

    /// <summary>
    /// ���� up, down, left, right�� ��ĭ�̵��ϴ� �Լ�
    /// </summary>
    /// <param name="dirction"></param>
    public void Move(DIRECTION dirction)
    {
        if(CURRENTSTATE == BLOCKSTATE.MOVE) //���� �����̴� ���¶��
        {
            return; //���Ͻ����ش�
        }
        //�ᱹ���� ���� width��ŭ �����δ�
        //�ֳĸ� ���� ������ �⺻���̱� ������
        // ���� ���� �����̰� �ִµ� ����� ������ �����Ѵ�.
        switch (dirction)
        {
            case DIRECTION.LEFT:
                _movePos = transform.position;  //������ ��ġ���� ����
                _movePos.x -= Width;    //���� ��ġ�� x ������ ���� �ʺ� ���� �̵���ġ�� ���Ѵ�
                CURRENTSTATE = BLOCKSTATE.MOVE;
                direction = DIRECTION.LEFT; //�̵��� ������ ����
                break;
            case DIRECTION.RIGHT:
                _movePos = transform.position;  //������ ��ġ���� ����
                _movePos.x += Width;    //���� ��ġ�� x ������ ���� �ʺ� ���� �̵���ġ�� ���Ѵ�
                CURRENTSTATE = BLOCKSTATE.MOVE;
                direction = DIRECTION.RIGHT; //�̵��� ������ ����
                break;
            case DIRECTION.UP:
                _movePos = transform.position;  //������ ��ġ���� ����
                _movePos.y += Width;    //���� ��ġ�� x ������ ���� �ʺ� ���� �̵���ġ�� ���Ѵ�
                CURRENTSTATE = BLOCKSTATE.MOVE;
                direction = DIRECTION.UP; //�̵��� ������ ����
                break;
            case DIRECTION.DOWN:
                _movePos = transform.position;  //������ ��ġ���� ����
                _movePos.y -= Width;    //���� ��ġ�� x ������ ���� �ʺ� ���� �̵���ġ�� ���Ѵ�
                CURRENTSTATE = BLOCKSTATE.MOVE;
                direction = DIRECTION.DOWN; //�̵��� ������ ����
                break;
        }
    }

    public void Move (DIRECTION direct, int moveCount)
    {
        switch (direct)
        {
            case DIRECTION.LEFT:
                {
                    direct= DIRECTION.LEFT;
                    CURRENTSTATE = BLOCKSTATE.MOVE;
                }
                break;
            case DIRECTION.RIGHT:
                {
                    direct = DIRECTION.RIGHT;
                    CURRENTSTATE = BLOCKSTATE.MOVE;
                }
                break;
            case DIRECTION.UP:
                {
                    direct = DIRECTION.UP;
                    CURRENTSTATE = BLOCKSTATE.MOVE;
                }
                break;
            case DIRECTION.DOWN:
                {
                    direct = DIRECTION.DOWN;
                    CURRENTSTATE = BLOCKSTATE.MOVE;
                }
                break;
        }
    }
    /// <summary>
    /// �� ���� �ʱ�ȭ �Լ�
    /// </summary>
    /// <param name="column"></param>
    /// <param name="row"></param>
    /// <param name="type"></param>
    /// <param name="sprite"></param>
    public void Init(int column, int row, int type, Sprite sprite)
    {
        _column = column;
        _row = row;
        Type = type;
        blockImage.sprite = sprite;
    }

    void Update()
    {
        if(CURRENTSTATE == BLOCKSTATE.MOVE)
        {
            switch (direction)
            {
                case DIRECTION.LEFT:
                    {
                        transform.Translate(Vector3.left * SPEED);
                        if(transform.position.x <= _movePos.x)
                        {
                            transform.position = _movePos;
                            CURRENTSTATE = BLOCKSTATE.STOP;
                        }
                        
                    }
                    break;
                case DIRECTION.RIGHT:
                    {
                        transform.Translate(Vector3.right * SPEED);
                        if (transform.position.x >= _movePos.x)
                        {
                            transform.position = _movePos;
                            CURRENTSTATE = BLOCKSTATE.STOP;
                        }
                    }
                    break;
                case DIRECTION.UP:
                    {
                        transform.Translate(Vector3.up * SPEED);
                        if (transform.position.y >= _movePos.y)
                        {
                            transform.position = _movePos;
                            CURRENTSTATE = BLOCKSTATE.STOP;
                        }
                    }
                    break;
                case DIRECTION.DOWN:
                    {
                        transform.Translate(Vector3.down * SPEED);
                        if (transform.position.y <= _movePos.y)
                        {
                            transform.position = _movePos;
                            CURRENTSTATE = BLOCKSTATE.STOP;
                        }
                    }
                    break;
            }

        }
    }
}
