using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public enum BLOCKSTATE
    {
        STOP,
        MOVE
    };


    public enum DIRECTION
    {
        LEFT,
        RIGHT,
        UP,
        DOWN
    };


public class Block_T : MonoBehaviour
{

    public int Type { set; get; }   // �� Ÿ��

    [SerializeField] private SpriteRenderer _BlockImage;

    public BLOCKSTATE State { set; get; } = BLOCKSTATE.STOP;

    private DIRECTION _direct;  // �̵����� ����.

    public float Speed { set; get; } = 0.01f;

    private Vector3 _movePos; // ���� �̵��� ��ġ���� ����
    public Vector3 MovePos
    {
        get => _movePos;
        set => _movePos = value;
    }


    public float Width { set; get; }    // �� �ʺ� ����

    public SpriteRenderer BlockImage
    {
        get
        {
            return _BlockImage;
        }
    }

    public int Column { set; get; } // ���� ���� column
    public int Row { set; get; }    // ���� ���� row

    // Start is called before the first frame update
    void Start()
    {

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
        Column = column;
        Row = row;
        Type = type;
        _BlockImage.sprite = sprite;
    }


    /// <summary>
    /// ���� up, down, left, right�� ��ĭ�̵��ϴ� �Լ�
    /// </summary>
    /// <param name="direct"></param>
    public void Move(DIRECTION direct)
    {
        if (State == BLOCKSTATE.MOVE) return;   // ���� ���� �����̰� �ִµ� ����� ������ �����Ѵ�.


        switch (direct)
        {
            case DIRECTION.LEFT:
                {
                    _movePos = transform.position;  // ������ ��ġ���� ����
                    _movePos.x -= Width;    // ���� ��ġ�� x������ ���� �ʺ� ���� �̵���ġ�� ���Ѵ�.
                    State = BLOCKSTATE.MOVE;
                    _direct = DIRECTION.LEFT;   // �̵��� ������ ����

                }

                break;

            case DIRECTION.RIGHT:
                {
                    _movePos = transform.position;  // ������ ��ġ���� ����
                    _movePos.x += Width;    // ���� ��ġ�� x������ ���� �ʺ� ���ؼ� �̵���ġ�� ���Ѵ�.
                    State = BLOCKSTATE.MOVE;
                    _direct = DIRECTION.RIGHT;   // �̵��� ������ ����

                }
                break;

            case DIRECTION.UP:
                {
                    _movePos = transform.position;  // ������ ��ġ���� ����
                    _movePos.y += Width;    // ���� ��ġ�� y������ ���� �ʺ� ���ؼ� �̵���ġ�� ���Ѵ�.
                    State = BLOCKSTATE.MOVE;
                    _direct = DIRECTION.UP;   // �̵��� ������ ����

                }
                break;

            case DIRECTION.DOWN:
                {
                    _movePos = transform.position;  // ������ ��ġ���� ����
                    _movePos.y -= Width;    // ���� ��ġ�� y������ ���� �ʺ� ���� �̵���ġ�� ���Ѵ�.
                    State = BLOCKSTATE.MOVE;
                    _direct = DIRECTION.DOWN;   // �̵��� ������ ����

                }

                break;
        }

    }

    public void Move(DIRECTION direct, int moveCount)
    {
        switch (direct)
        {
            case DIRECTION.LEFT:
                {
                    _direct = DIRECTION.LEFT;
                    State = BLOCKSTATE.MOVE;
                }
                break;

            case DIRECTION.RIGHT:
                {
                    _direct = DIRECTION.LEFT;
                    State = BLOCKSTATE.MOVE;
                }
                break;

            case DIRECTION.UP:
                {
                    _direct = DIRECTION.UP;
                    State = BLOCKSTATE.MOVE;
                }
                break;

            case DIRECTION.DOWN:
                {
                    _direct = DIRECTION.DOWN;
                    State = BLOCKSTATE.MOVE;
                }
                break;

        }
    }


    // Update is called once per frame
    void Update()
    {
        if (State == BLOCKSTATE.MOVE)
        {
            switch (_direct)
            {
                case DIRECTION.LEFT:
                    {
                        transform.Translate(Vector3.left * Speed);

                        if (transform.position.x <= _movePos.x)
                        {
                            transform.position = _movePos;
                            State = BLOCKSTATE.STOP;
                        }
                    }
                    break;

                case DIRECTION.RIGHT:
                    {
                        transform.Translate(Vector3.right * Speed);

                        if (transform.position.x >= _movePos.x)
                        {
                            transform.position = _movePos;
                            State = BLOCKSTATE.STOP;
                        }
                    }
                    break;

                case DIRECTION.UP:
                    {
                        transform.Translate(Vector3.up * Speed);

                        if (transform.position.y >= _movePos.y)
                        {
                            transform.position = _movePos;
                            State = BLOCKSTATE.STOP;
                        }
                    }
                    break;

                case DIRECTION.DOWN:
                    {
                        transform.Translate(Vector3.down * Speed);

                        if (transform.position.y <= _movePos.y)
                        {
                            transform.position = _movePos;
                            State = BLOCKSTATE.STOP;
                        }
                    }
                    break;
            }

        }


    }
}