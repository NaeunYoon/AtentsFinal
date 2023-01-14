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
public enum BLOCKSTATE1  //블럭의 상태를 나타낸다 (블럭이 이동중이면 이동이 끝난 후에 이동을 시키게 하기 위해서)
{
    STOP,
    MOVE
}

public class Block : MonoBehaviour
{
    //[SerializeField] : private 인데, 에디터상에서 수정이 가능하다. (기획자가 건드려야 할 값들은 인스펙터창에 보이도록 만들어야 한다)
    //=============================================================================================01
    //블럭 이미지를 가져온다
    [SerializeField] private SpriteRenderer _blockImage;
    //==============================================================================================02
    //외부에서 접근할 수 있도록 프로퍼티를 만들어준다 (프리팹에 스크립트를 장착한다)
    public SpriteRenderer blockImage    //프로퍼티 생성
    {
        get { return _blockImage; }
    }
    public float Width { get; set; }    //블럭 너비 저장
    private Vector3 _movePos; //블럭의 이동할 위치값을 저장
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

    //이미지의 타입을 지정해준다 (프로퍼티)
    public int Type { set; get; }


    void Start()
    {
        
    }

    /// <summary>
    /// 블럭을 up, down, left, right로 한칸이동하는 함수
    /// </summary>
    /// <param name="dirction"></param>
    public void Move(DIRECTION dirction)
    {
        if(CURRENTSTATE == BLOCKSTATE.MOVE) //블럭이 움직이는 상태라면
        {
            return; //리턴시켜준다
        }
        //결국에는 블럭의 width만큼 움직인다
        //왜냐면 블럭의 중점이 기본값이기 때문에
        // 현재 블럭이 움직이고 있는데 명령이 들어오면 무시한다.
        switch (dirction)
        {
            case DIRECTION.LEFT:
                _movePos = transform.position;  //현재의 위치값을 저장
                _movePos.x -= Width;    //현재 위치의 x 값에서 블럭의 너비를 빼서 이동위치를 구한다
                CURRENTSTATE = BLOCKSTATE.MOVE;
                direction = DIRECTION.LEFT; //이동할 방향을 저장
                break;
            case DIRECTION.RIGHT:
                _movePos = transform.position;  //현재의 위치값을 저장
                _movePos.x += Width;    //현재 위치의 x 값에서 블럭의 너비를 빼서 이동위치를 구한다
                CURRENTSTATE = BLOCKSTATE.MOVE;
                direction = DIRECTION.RIGHT; //이동할 방향을 저장
                break;
            case DIRECTION.UP:
                _movePos = transform.position;  //현재의 위치값을 저장
                _movePos.y += Width;    //현재 위치의 x 값에서 블럭의 너비를 빼서 이동위치를 구한다
                CURRENTSTATE = BLOCKSTATE.MOVE;
                direction = DIRECTION.UP; //이동할 방향을 저장
                break;
            case DIRECTION.DOWN:
                _movePos = transform.position;  //현재의 위치값을 저장
                _movePos.y -= Width;    //현재 위치의 x 값에서 블럭의 너비를 빼서 이동위치를 구한다
                CURRENTSTATE = BLOCKSTATE.MOVE;
                direction = DIRECTION.DOWN; //이동할 방향을 저장
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
    /// 블럭 정보 초기화 함수
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
