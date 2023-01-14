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

    public int Type { set; get; }   // 블럭 타입

    [SerializeField] private SpriteRenderer _BlockImage;

    public BLOCKSTATE State { set; get; } = BLOCKSTATE.STOP;

    private DIRECTION _direct;  // 이동방향 저장.

    public float Speed { set; get; } = 0.01f;

    private Vector3 _movePos; // 블럭의 이동할 위치값을 저장
    public Vector3 MovePos
    {
        get => _movePos;
        set => _movePos = value;
    }


    public float Width { set; get; }    // 블럭 너비 저장

    public SpriteRenderer BlockImage
    {
        get
        {
            return _BlockImage;
        }
    }

    public int Column { set; get; } // 현재 블럭의 column
    public int Row { set; get; }    // 현재 블럭의 row

    // Start is called before the first frame update
    void Start()
    {

    }


    /// <summary>
    /// 블럭 정보 초기화 함수
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
    /// 블럭을 up, down, left, right로 한칸이동하는 함수
    /// </summary>
    /// <param name="direct"></param>
    public void Move(DIRECTION direct)
    {
        if (State == BLOCKSTATE.MOVE) return;   // 현재 블럭이 움직이고 있는데 명령이 들어오면 무시한다.


        switch (direct)
        {
            case DIRECTION.LEFT:
                {
                    _movePos = transform.position;  // 현재의 위치값을 저장
                    _movePos.x -= Width;    // 현재 위치의 x값에서 블럭의 너비를 빼서 이동위치를 구한다.
                    State = BLOCKSTATE.MOVE;
                    _direct = DIRECTION.LEFT;   // 이동할 방향을 저장

                }

                break;

            case DIRECTION.RIGHT:
                {
                    _movePos = transform.position;  // 현재의 위치값을 저장
                    _movePos.x += Width;    // 현재 위치의 x값에서 블럭의 너비를 더해서 이동위치를 구한다.
                    State = BLOCKSTATE.MOVE;
                    _direct = DIRECTION.RIGHT;   // 이동할 방향을 저장

                }
                break;

            case DIRECTION.UP:
                {
                    _movePos = transform.position;  // 현재의 위치값을 저장
                    _movePos.y += Width;    // 현재 위치의 y값에서 블럭의 너비를 더해서 이동위치를 구한다.
                    State = BLOCKSTATE.MOVE;
                    _direct = DIRECTION.UP;   // 이동할 방향을 저장

                }
                break;

            case DIRECTION.DOWN:
                {
                    _movePos = transform.position;  // 현재의 위치값을 저장
                    _movePos.y -= Width;    // 현재 위치의 y값에서 블럭의 너비를 빼서 이동위치를 구한다.
                    State = BLOCKSTATE.MOVE;
                    _direct = DIRECTION.DOWN;   // 이동할 방향을 저장

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