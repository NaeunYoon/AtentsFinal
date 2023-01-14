using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.Linq;

public enum MouseMoveDirection1
{
    MOUSEMOVEUP,
    MOUSEMOVEDOWN,
    MOUSEMOVELEFT,
    MOUSEMOVERIGHT,
}


public class BoardManager : MonoBehaviour
{

    /*
     1. 빈 게임 오브젝트에 장착시킨다
     2. 블럭 프리팹을 넣는다
     3. MakeBoard 함수를 만든다 ( 컬럼과 로우 값을 받아서 프리팹을 생성하는 코드)
        (중점을 기준으로 배치한다 => 0,0점을 기준으로 블럭이 배치됨)
     4. 보고있는 화면은 스크린좌표 2d 이지만 블럭이 위치하고 있는 공간은 3d 공간이다

    1. 먼저 스크린좌표계를 월드 좌표를 구한다

    전체 사이즈를 구하는 법 0.0 이 -2.8, 5,0 이기 때문에
    전체 width 값은 5.6 height 은 10이다.
     */
    [SerializeField] private GameObject _blockPrefab;
    private Vector3 _screenPos; //스크린 0,0 점의 월드 좌표값 저장
    private float _screenWidth;   //스크린의 넓이
    private float _blockWidth; //블럭의 넓이
    //private Vector3 _screenheight; //스크린의 높이

    public float _xMargin=2f;
    public float _yMargin=4f;
    private float _blockScale = 0.0f;    // 블럭의 스케일 값 저장
    public Transform _parents;

    private GameObject[,] _gameBoard; //게임 저장용 보드

    int Column = 0;
    int Row = 0;

    //마우스로 클릭했을대의 시작 위치를 정하는 시작위치
    private Vector3 _startPos = Vector3.zero;
    //마우스 클릭 후 움직인 좌표
    private Vector3 _endPos = Vector3.zero;
    private bool _isOver = false;   //클릭된 블럭 있는지 저장
    //클릭된 오브젝트의 참조값 저장 
    private GameObject _clickObject;
    //마우스 버튼이 눌려진 상태인지 아닌지 체크
    private bool _mouseClick =false;
    //감도 조절 (시작점에서 끝점의 거리의 판단 기준값
    private float _moveDistance = 0.05f;
    //입력이 계속 먹는 것을 방지
    private bool _inputOK = true;

    [SerializeField] private Sprite[] _sprites; //sprite 이미지 배열
    //삭제될 블럭 저장
    private List<GameObject> _removingBlocks = new List<GameObject>();
    //삭제된 블럭 저장
    private List<GameObject> _removedBlocks = new List<GameObject>();

    private int TYPECOUNT = 4; //생성될 블럭의 종류 수
    void Start()
    {
        //============================================================================================02
        //스크린 (좌하단)0,0 좌표를 월드 공간상의 좌표값으로 변환 
        _screenPos = Camera.main.ScreenToWorldPoint(new Vector3(0f,0f,10f));
        Debug.Log("ScreenPos "+_screenPos);
        //3D 공간상의 중앙이 0.0 이라고 하면 (좌하단) 
        //월드공간상의 좌하단은 -2.8, -5.0, 0.0
        //월드공간상의 좌상단은 -2.8, 5.0, 0.0
        //월드공간상의 우상단은 2.8,5,0,0.0
        //월드공간상의 우하단은 2.8 -5,0,0.0
        //스크린 공간상의 좌표를 가지고 3d월드 공간의 좌표를 구할 수 있다
        _screenPos.y = -_screenPos.y;   
        //스크린의 y값이 - 였음. 따라서 똑같은 걸 부호만 다르게 해서 곱해주면 +가 된다(+y 가 된다)
        _screenWidth = Mathf.Abs(_screenPos.x * 2); //스크린의 너비를 구한다
        //블럭 이미지의 픽셀값을 100으로 나눠서 블럭 넓이를 구한다
        //이미지 크기가 100 이라고 할 떄 픽셀의 갯수가 너비로 100 높이로 100개 있다는 것이다
        //그것을 3d 공간상의 너비값으로 바꾸는 방법을 픽셀값을 100으로 나누면 된다
        //픽셀값이 1000이면 이미지의 너비가 10이 되는 것이디
        //픽셀값이 50이면 이미지의 너비가 0.5가 되는 것이다
        //유니티 기본값이 100이기 때문에 100으로 나눈 것이다
        //100픽셀이 1유닛이고 1미터이다 => 유니티단위
        _blockWidth = _blockPrefab.GetComponent<Block>().blockImage.sprite.rect.size.x / 100;   //블럭의 width값 가져오기

        //여백값을 입력하고 가운데에 출력하고자 함


        MakeBoard(5,5);
    }

    void MakeBoard(int column, int row) //블럭배치하는 함수
    {
        float width = _screenWidth - (_xMargin*2);  //출력되는 너비 ( 마진갑 없음)
        //블럭의 출력 너비값 = 블럭의 너비값 * 전체 개수
        float blockWidth = _blockWidth * row;
        //블럭의 넓이에서 스크린의 넓이를 나눠서 블럭의 사이즈를 조절할 수 있다
        _blockScale = width / blockWidth; //블럭의 스케일 값
        _gameBoard = new GameObject[column, row];

        Column= column;
        Row= row;

        for (int co = 0; co < column; co++)
        {
            for (int ro = 0; ro < row; ro++)
            {

                //초기코드 ======================================================================================01
                //0.0점에 배치가 되기 때문에 전체적인 블럭들이 우측 상단에 배치가 된다. (스크린좌표계가 기준임)
                //블럭은 3d공간에 있다. 따라서 우리는 3d 공간상의 좌표를 찾아야 한다 (스크린 좌표값을 구하기)
                //var blockObj = Instantiate(_blockPrefab);
                //blockObj.transform.position = new Vector3(ro, -co, 0f);
                //================================================================================================03
                //스크린좌표값을 반영해서 y값을  바꿔준다 (y값 고정)
                //blockObj.transform.position = new Vector3(ro, _scrennPos.y-co, 0f);
                //좌측 줄 블럭들이 y축 5에 맞춰서 아래로 정렬된다
                //================================================================================================04
                //이번에는 x 값을 보정해서 블럭들을 가운데로 맞추려고 함
                //blockObj.transform.position = new Vector3(_scrennPos.x+ro, _scrennPos.y-co, 0f);
                //좌측 상단을 기준으로 출력된다
                //================================================================================================05
                //블럭의 중심부분을 기준으로 하기 때문에 블럭이 짤린다 대략 0.5 정도를 더해서 맞춰준다(블럭 사이즈를 1이라고 함)
                //blockObj.transform.position = new Vector3(_scrennPos.x+ro+0.5f, _scrennPos.y-co-0.5f, 0f);
                //좌측 상단을 기준으로 출력된다
                //================================================================================================06
                //전체 가로가 2.8*2
                //private Vector3 _screenPos; //스크린 0,0 점의 월드 좌표값 저장
                //private float _screenWidth;   //스크린의 넓이
                //private float _blockWidth; //블럭의 넓이
                //이렇레 받아주고,
                /*
                _screenPos.y = -_screenPos.y;   
                //스크린의 y값이 - 였음. 따라서 똑같은 걸 부호만 다르게 해서 곱해주면 +가 된다(+y 가 된다)
                _screenWidth = Mathf.Abs(_screenPos.x * 2); //스크린의 너비를 구한다*/
                //================================================================================================07
                //정확한 블럭의 이미지 사이즈를 알고 싶다 ( 따라서 블럭 스크립트를 하나 만든다)
                //================================================================================================08
                /*
                 //블럭 이미지의 픽셀값을 100으로 나눠서 블럭 넓이를 구한다
                //이미지 크기가 100 이라고 할 떄 픽셀의 갯수가 너비로 100 높이로 100개 있다는 것이다
                //그것을 3d 공간상의 너비값으로 바꾸는 방법을 픽셀값을 100으로 나누면 된다
                //픽셀값이 1000이면 이미지의 너비가 10이 되는 것이디
                //픽셀값이 50이면 이미지의 너비가 0.5가 되는 것이다
                //유니티 기본값이 100이기 때문에 100으로 나눈 것이다
                //100픽셀이 1유닛이고 1미터이다 => 유니티단위
                _blockWidth = _blockPrefab.GetComponent<Block>().blockImage.sprite.rect.size.x / 100;   //블럭의 width값 가져오기
                //픽셀사이즈를 100으로 나눠서 3d 공간상의 1로 나눔
                //이미지 크기가 100이라고 하면 너비로 100 높이로 100 개의 픽셀이 있는건데, 이걸 3d 공간상의 너비값으로 바꾸려면
                //픽셀값을 100으로 나눠서 유니티 공간의 단위로 바꿔주는거다. (픽셀단위 -> 3d 공간상의 단위 : default 단위가 100임 = 1유닛)
                //여백값을 입력하고 가운데에 출력하고자 함
                 */
                //================================================================================================09
                //blockObj.transform.localScale = new Vector3(_blockScale, _blockScale, 0f);
                //블럭이 화면 안에 꽉 차도록 한다
                //   _blockScale = width / blockWidth; //블럭의 스케일 값


                _gameBoard[co,ro] = Instantiate<GameObject>(_blockPrefab);  //프리팹 instantiate
                _gameBoard[co, ro].transform.SetParent(_parents);   //부모 정해서 오브젝트에 넣어줬음 (지저분해서)


                _gameBoard[co, ro].transform.localScale = new Vector3(_blockScale, _blockScale, 0f);
                _gameBoard[co, ro].transform.position = new Vector3(_screenPos.x + _xMargin + ro * (_blockWidth * _blockScale) + (_blockWidth * _blockScale / 2f),
                                                         _screenPos.y - _yMargin - co * (_blockWidth * _blockScale) - (_blockWidth * _blockScale / 2f),
                                                          0f);


                //============================================================================
                //int _type = UnityEngine.Random.Range(0, _sprites.Length);
                int _type = UnityEngine.Random.Range(0, TYPECOUNT);
                _gameBoard[co, ro].GetComponent<Block>().Type = _type;
                _gameBoard[co, ro].GetComponent<Block>().blockImage.sprite= _sprites[_type];

                //===========================================================================
                _gameBoard[co, ro].GetComponent<Block>().Width = _blockWidth*_blockScale;
                _gameBoard[co, ro].GetComponent<Block>().MovePos = _gameBoard[co, ro].transform.position;

                _gameBoard[co, ro].GetComponent<Block>()._column = co;
                _gameBoard[co,ro].GetComponent<Block>()._row = ro;
                


                //_gameBoard[co, ro].GetComponent<Block>().Move(DIRECTION.LEFT);

                //GameObject blockObj = Instantiate<GameObject>(_blockPrefab);
                //blockObj.transform.SetParent(_parents);
                //blockObj.transform.localScale = new Vector3(_blockScale,_blockScale, 0f);
                //blockObj.transform.position = new Vector3(_screenPos.x + _xMargin + ro*(_blockWidth*_blockScale) + (_blockWidth * _blockScale/2f) ,
                //                                          _screenPos.y - _yMargin - co * (_blockWidth * _blockScale) - (_blockWidth * _blockScale / 2f),
                //                                          0f);
                //blockObj.GetComponent<Block>().Width = _blockWidth; //블럭의 너비값을 블럭에 전달
                //blockObj.GetComponent<Block>().MovePos = blockObj.transform.position;   //생성위치값 저장
                //blockObj.GetComponent<Block>().Move(DIRECTION.LEFT);
                //


                _gameBoard[co,ro].name = $"Block[{ co},{ro}]";

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

    //private bool CheckBool()
    //{
    //    foreach (var item in _gameBoard)
    //    {
    //        if(item != null)
    //        {
    //            if (item.GetComponent<Block>().CURRENTSTATE == BLOCKSTATE.MOVE)
    //            {

    //            }
    //        }
    //    }
    //}

    /// <summary>
    /// 클릭된 상태에서 마우스 커서 이동시 호출
    /// </summary>
    
    private void MouseMove()
    {
        //Debug.Log("MouseMove");
        float difference = Vector2.Distance(_startPos, _endPos);
        //Debug.Log("diffrence" + difference);
        if (difference > _moveDistance && _clickObject != null&&_inputOK)
        {
            _inputOK= false;
            MouseMoveDirection1 dir = calculateDirection();
            Debug.Log("direction " + dir);

            switch (dir)
            {
                case MouseMoveDirection1.MOUSEMOVELEFT:
                    {
                        int column = _clickObject.GetComponent<Block>()._column;
                        int row = _clickObject.GetComponent<Block>()._row;

                        if (row > 0)
                        {
                            //서로 바꿀 블럭의 열갑을 변경
                            _gameBoard[column,row].GetComponent<Block>()._row= row-1;
                            _gameBoard[column, row-1].GetComponent<Block>()._row = row;

                            //GameBoard 상의 블럭의 참조값을 바꾼다
                            _gameBoard[column,row] = _gameBoard[column,row-1];
                            _gameBoard[column, row - 1] = _clickObject;

                            //블럭을 좌우측으로 움직인가
                            _gameBoard[column, row].GetComponent<Block>().Move(DIRECTION.RIGHT);
                            _gameBoard[column,row-1].GetComponent<Block>().Move(DIRECTION.LEFT);
                        }
                        break;
                    }

                case MouseMoveDirection1.MOUSEMOVERIGHT:
                    {
                        int column = _clickObject.GetComponent<Block>()._column;
                        int row = _clickObject.GetComponent<Block>()._row;

                        if (row < (row+1))
                        {
                            //서로 바꿀 블럭의 열갑을 변경
                            _gameBoard[column, row].GetComponent<Block>()._row = row + 1;
                            _gameBoard[column, row + 1].GetComponent<Block>()._row = row;

                            //GameBoard 상의 블럭의 참조값을 바꾼다
                            _gameBoard[column, row] = _gameBoard[column, row + 1];
                            _gameBoard[column, row + 1] = _clickObject;

                            //블럭을 좌우측으로 움직인가
                            _gameBoard[column, row].GetComponent<Block>().Move(DIRECTION.LEFT);
                            _gameBoard[column, row + 1].GetComponent<Block>().Move(DIRECTION.RIGHT);
                        }
                        break;
                    }

                case MouseMoveDirection1.MOUSEMOVEUP:
                    {
                        int column = _clickObject.GetComponent<Block>()._column;
                        int row = _clickObject.GetComponent<Block>()._row;

                        if (column > 0)
                        {
                            //서로 바꿀 블럭의 열갑을 변경
                            _gameBoard[column, row].GetComponent<Block>()._column = column - 1;
                            _gameBoard[column-1, row].GetComponent<Block>()._column = column;

                            //GameBoard 상의 블럭의 참조값을 바꾼다
                            _gameBoard[column, row] = _gameBoard[column-1, row];
                            _gameBoard[column-1, row] = _clickObject;

                            //블럭을 좌우측으로 움직인가
                            _gameBoard[column, row].GetComponent<Block>().Move(DIRECTION.DOWN);
                            _gameBoard[column-1, row].GetComponent<Block>().Move(DIRECTION.UP);
                        }
                        break;
                    }

                case MouseMoveDirection1.MOUSEMOVEDOWN:
                    {
                        int column = _clickObject.GetComponent<Block>()._column;
                        int row = _clickObject.GetComponent<Block>()._row;

                        if (column > (column - 1))
                        {
                            //서로 바꿀 블럭의 열갑을 변경
                            _gameBoard[column, row].GetComponent<Block>()._column = column + 1;
                            _gameBoard[column + 1, row].GetComponent<Block>()._column = column;

                            //GameBoard 상의 블럭의 참조값을 바꾼다
                            _gameBoard[column, row] = _gameBoard[column + 1, row];
                            _gameBoard[column + 1, row] = _clickObject;

                            //블럭을 좌우측으로 움직인가
                            _gameBoard[column, row].GetComponent<Block>().Move(DIRECTION.UP);
                            _gameBoard[column + 1, row].GetComponent<Block>().Move(DIRECTION.DOWN);
                        }
                        break;
                    }
            }

        }
        CheckMatchBlock();
    }
    /// <summary>
    /// 마우스 이동 시 이동한 방향을 계산
    /// </summary>
    /// <returns></returns>
    private MouseMoveDirection1 calculateDirection() 
    { 
        float angle = CalculateAngle(_startPos,_endPos);
        if(angle >= 315.0f && angle <=360.0f || angle >=0f && angle < 45.0f)
        {
            return MouseMoveDirection1.MOUSEMOVEUP;
        }else if( angle>=45.0f && angle < 135.0f)
        {
            return MouseMoveDirection1.MOUSEMOVELEFT;
        }else if(angle >=135.0f && angle < 225.0f)
        {
            return MouseMoveDirection1.MOUSEMOVEDOWN;
        }else if (angle>=225.0f && angle < 315.0f)
        {
            return MouseMoveDirection1.MOUSEMOVERIGHT;
        }
        else
        {
            return MouseMoveDirection1.MOUSEMOVEDOWN;
        }
    }
    /// <summary>
    /// 각도를 구하는 함수 ( 각도 중에서도 우리는 z 축만 가지면 된다
    /// </summary>
    /// <param name="from"></param>
    /// <param name="to"></param>
    /// <returns></returns>
    private float CalculateAngle(Vector3 from, Vector3 to)
    {
        return Quaternion.FromToRotation(Vector3.up, to - from).eulerAngles.z;
    }
    /// <summary>
    /// 3매칭된 블럭을 찾는다
    /// </summary>
    private void CheckMatchBlock()
    {
        List<GameObject> matchList = new List<GameObject>();
        List<GameObject> tmpMatchList = new List<GameObject>();
        //비교항 블럭 타입을 기록
        int checkType = 0;
        //삭제될 블럭 저장용 리스트 초기화
        _removedBlocks.Clear();

        //세로방향으로 매치된 블럭
        for (int i = 0; i < Row; i++)
        {
            if (_gameBoard[0, i]==null)
            {
                continue;
            }
            //첫 행의 블럭의 타입값을 가져온다

            checkType = _gameBoard[0, i].GetComponent<Block>().Type;
            tmpMatchList.Add(_gameBoard[0, i]);
            for (int j = 0; j < Column; j++)
            {
                if (_gameBoard[j, i] == null)
                {
                    continue;
                }

                if(checkType == _gameBoard[j, i].GetComponent<Block>().Type)
                {
                    tmpMatchList.Add(_gameBoard[j, i]);
                }
                else
                {
                    //불일치가 난 위치에서 이전의 블럭이 3개 일치했다
                    if (tmpMatchList.Count >= 3)
                    {
                        matchList.AddRange(tmpMatchList);
                        tmpMatchList.Clear();   //참조값을 없앰

                        //불일치가 난 위치의 블럭 타입의 값을 다시 셋팅
                        checkType = _gameBoard[j,i].GetComponent<Block>().Type;
                        tmpMatchList.Add(_gameBoard[j, i]);

                    }
                    //불일치가 난 위치에서 이전의 블럭이 3개 일치하지 않았음
                    else
                    {
                        tmpMatchList.Clear();
                        //불일치가 난 위치의 블럭 타입의 값을 다시 셋팅
                        checkType = _gameBoard[j, i].GetComponent<Block>().Type;
                        tmpMatchList.Add(_gameBoard[j, i]);
                    }
                }
            }
            //열에 따른 행을 다 돈 후
            //tmpmatchList의 count을 체크한다
            if (tmpMatchList.Count >= 3)
            {
                matchList.AddRange(tmpMatchList);
                tmpMatchList.Clear();
            }
            else
            {
                tmpMatchList.Clear();
            }
        }
        tmpMatchList.Clear();

        //가로방향으로 매치 블럭을 체크
        for (int i = 0; i < Column; i++)
        {
            if (_gameBoard[i, 0] == null)
            {
                continue;
            }
            
            checkType = _gameBoard[i,0].GetComponent<Block>().Type;
            tmpMatchList.Add(_gameBoard[i, 0]);

            for (int j = 0; j < Row; j++)
            {
                if (_gameBoard[i, j] == null)
                {
                    continue;
                }

                if(checkType == _gameBoard[i,j].GetComponent<Block>().Type) 
                {
                    tmpMatchList.Add(_gameBoard[i, j]);
                }
                else
                {
                    if(tmpMatchList.Count >= 3) 
                    { 
                        matchList.AddRange(tmpMatchList);
                        tmpMatchList.Clear();

                        checkType = _gameBoard[i, j].GetComponent<Block>().Type;
                        tmpMatchList.Add(_gameBoard[i,j]);

                    }
                    else
                    {
                        tmpMatchList.Clear();
                        checkType = _gameBoard[i, j].GetComponent<Block>().Type;
                        tmpMatchList.Add(_gameBoard[i,j] );
                    }
                }
            }
            //열을 다 돈 후

            if (tmpMatchList.Count >= 3)
            {
                matchList.AddRange(tmpMatchList);
                tmpMatchList.Clear();
            }
            else
            {
                tmpMatchList.Clear();
            }

        }
        

        //matchList의 중복된 블럭을 추려냄
        //중복된거 빼고 리턴
        matchList = matchList.Distinct().ToList();
        if (matchList.Count > 0)
        {
            foreach (var item in matchList)
            {
                //보드상에서 블럭을 없애버린다 (매치된 블럭을 삭제처리)
                //보드 상에서 해당 위치의 블럭을 널처리 한다
                _gameBoard[item.GetComponent<Block>()._column, item.GetComponent<Block>()._row] = null;
                //해당 블럭을 비활성화시킨다.
                item.SetActive(false);
            }
            //삭제 예정인 블럭들을 삭제 블럭리스트에 저장하기
            _removedBlocks.AddRange(matchList);
        }
        //삭제될 블럭을 삭제 블럭리스트에 저장하고
        _removedBlocks.AddRange(_removingBlocks);
        //중복된 블럭을 처리한다
        _removedBlocks = _removedBlocks.Distinct().ToList();

        DownMoveBlocks();
    }

    private void DownMoveBlocks()
    {
        int moveCount = 0; //하강해야할 칸 수를 저장
        
        for(int row = 0; row <Row; row++)
        {
            for (int col = Column-1; col >=0; col--)
            {
                //게임 보드상에 블럭이 없는 경우
                if (_gameBoard[col, row] == null)
                {
                    moveCount++;
                }
                else //게임보드상의 블럭이 있는 경우
                {
                    if (moveCount > 0)  //하강유무 체크
                    {
                        Block block = _gameBoard[col, row].GetComponent<Block>();
                        block.MovePos = block.transform.position;
                        //이동할 위치값을 기록
                        block.MovePos = new Vector3(block.MovePos.x, block.MovePos.y - block.Width * moveCount, block.MovePos.z);
                        //이전에 있던 게임보드상의 위치를 초기화
                        _gameBoard[col, row] = null;
                        //게임보드상의 이동할 위치로 변경
                        block._column = block._column + moveCount;
                        //블록 이름을 변경한다
                        block.gameObject.name = $"Block[{block._column},{block._row}]";
                        //게임보드상의 이동할 위치에 블럭의 참조값 저장
                        _gameBoard[block._column, block._row] = block.gameObject;

                        block.Move(DIRECTION.DOWN, moveCount);


                    }
                }
            }
            moveCount = 0;
        }
    }
    /// <summary>
    /// 게임보드상에 삭제된 블럭의 공간을 새로운 블럭으로 채움
    /// </summary>
    private void CreateMoveBlocks()
    {
        int moveCount = 0;
        for (int row = 0; row < Row; row++)
        {
            for (int col = Column-1; col >=0 ; col--)
            {
                if (_gameBoard[col, row] == null)
                {

                }
            }
        }
    }

    /// <summary>
    /// 새로이 생성될 블럭을 전달한다.
    /// </summary>
    /// <param name="column"></param>
    /// <param name="row"></param>
    /// <param name="type"></param>
    /// <returns></returns>
    private GameObject GetNewBlock(int column, int row, int type)
    {
        // 삭제된 블럭이 없는 경우
        // 해당 경우는 발생하면 안됨.
        if (_removedBlocks.Count <= 0)
        {
            return null;
        }

        // 삭제된 블럭을 저장한 리스트에서 블럭을 하나 가지고 온다.
        GameObject obj = _removedBlocks[0];
        // 블럭을 전달 받은 인자 값으로 초기화한다.
        obj.GetComponent<Block>().Init(column, row, type, _sprites[type]);

        _removedBlocks.Remove(obj); // 전달한 블럭을 삭제된 블럭 저장 리스트에서 삭제처리

        return obj;

    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0)&&_inputOK==true)
        {
            _mouseClick = true;

            Vector3 pos = Input.mousePosition;
            //클릭이 되었을 때 위치를 시작점과 끝점 위치값으로 초기화
            _endPos = _startPos = Camera.main.ScreenToWorldPoint(new Vector3(pos.x, pos.y, 10f));
            _endPos.z = _startPos.z = 0.0f;

            //Debug.Log(pos);
            bool isOver = false;
            //Debug.Log("mouse click pos = " + pos);

            for (int i = 0; i < Column; i++)
            {
                for (int j = 0; j < Row; j++)
                {
                    if (_gameBoard[i, j] != null)
                    {
                        //_isOver = false;
                        isOver = _gameBoard[i, j].GetComponent<Block>().blockImage.GetComponent<SpriteRenderer>().bounds.Contains(_startPos);
                    }

                    if (isOver)
                    {
                        //Debug.Log(_gameBoard[i, j].name);
                        Debug.Log("ClickObject = " + _gameBoard[i, j].name);
                        _clickObject = _gameBoard[i, j];

                        goto LoopExit;
                    }
                }
            }
        LoopExit:;
        }
        if (Input.GetMouseButtonUp(0))
        {
            _clickObject = null;
            _mouseClick = false;
            _inputOK= true;
        }

        //마우스 클릭한 후에 커서를 이동시킴
        if ((_mouseClick == true) && ((Input.GetAxis("Mouse X") < 0 || 
            Input.GetAxis("Mouse X") > 0) || 
            (Input.GetAxis("Mouse Y") < 0) ||
            Input.GetAxis("Mouse Y") > 0))
        {
            Vector3 pos = Input.mousePosition;
            _endPos = Camera.main.ScreenToWorldPoint(new Vector3(pos.x, pos.y, 10f));
            _endPos.z = 0f;

            MouseMove();
        }
        
    }
}
