using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public enum DIRECTION
{
    LEFT,
    RIGHT,
    UP,
    DOWN
}
public enum BLOCKSTATE  //������ ���¸� ��Ÿ���� (������ �̵����̸� �̵��� ���� �Ŀ� �̵��� ��Ű�� �ϱ� ���ؼ�)
{
    STOP,
    MOVE
}

public class Block : MonoBehaviour
{
    //[SerializeField] : private �ε�, �����ͻ󿡼� ������ �����ϴ�. (��ȹ�ڰ� �ǵ���� �� ������ �ν�����â�� ���̵��� ������ �Ѵ�)
    [SerializeField] private SpriteRenderer _blockImage;

    public SpriteRenderer blockImage    //������Ƽ ����
    {
        get { return _blockImage; }
    }
    public float Width { get; set; }    //���� �ʺ� ����
    private Vector3 _movePos; //������ �̵��� ��ġ���� ����
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


    void Start()
    {
        
    }
    public void Move(DIRECTION dirction)
    {
        if(CURRENTSTATE == BLOCKSTATE.MOVE) //������ �����̴� ���¶��
        {
            return; //���Ͻ����ش�
        }
        //�ᱹ���� ������ width��ŭ �����δ�
        //�ֳĸ� ������ ������ �⺻���̱� ������
        // ���� ������ �����̰� �ִµ� ������ ������ �����Ѵ�.
        switch (dirction)
        {
            case DIRECTION.LEFT:
                _movePos = transform.position;  //������ ��ġ���� ����
                _movePos.x -= Width;    //���� ��ġ�� x ������ ������ �ʺ� ���� �̵���ġ�� ���Ѵ�
                CURRENTSTATE = BLOCKSTATE.MOVE;
                direction = DIRECTION.LEFT; //�̵��� ������ ����
                break;
            case DIRECTION.RIGHT:
                _movePos = transform.position;  //������ ��ġ���� ����
                _movePos.x += Width;    //���� ��ġ�� x ������ ������ �ʺ� ���� �̵���ġ�� ���Ѵ�
                CURRENTSTATE = BLOCKSTATE.MOVE;
                direction = DIRECTION.RIGHT; //�̵��� ������ ����
                break;
            case DIRECTION.UP:
                _movePos = transform.position;  //������ ��ġ���� ����
                _movePos.y += Width;    //���� ��ġ�� x ������ ������ �ʺ� ���� �̵���ġ�� ���Ѵ�
                CURRENTSTATE = BLOCKSTATE.MOVE;
                direction = DIRECTION.UP; //�̵��� ������ ����
                break;
            case DIRECTION.DOWN:
                _movePos = transform.position;  //������ ��ġ���� ����
                _movePos.y -= Width;    //���� ��ġ�� x ������ ������ �ʺ� ���� �̵���ġ�� ���Ѵ�
                CURRENTSTATE = BLOCKSTATE.MOVE;
                direction = DIRECTION.DOWN; //�̵��� ������ ����
                break;
        }
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