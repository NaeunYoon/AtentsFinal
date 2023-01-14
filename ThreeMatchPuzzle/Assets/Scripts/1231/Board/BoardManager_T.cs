using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;



public class BoardManager_T : MonoBehaviour
{
    public enum MouseMoveDirection
    {
        MOUSEMOVEUP,
        MOUSEMOVEDOWN,
        MOUSEMOVERIGHT,
        MOUSEMOVELEFT
    };

    public enum GamePlayState
    {
        INPUTOK, // 게임 진행
        AFTERINPUTMOVECHECK,
        MATCHCHECK, // 같은 블럭이 3개 있는지 체크
        AFTERMATCHCHECK_MOVECHECK, // MatchCheck후에 블럭이 움직이는 상태인지 체크
        DROPBLOCK,  // 새로운 블럭 배치
        AFTERDROPBLOCKBLOCK_MOVECHECK,  // DropBlock 후에 블럭이 움직이는 상태인지 체크
        INPUTCANCEL
    };


    public class BoardManager : MonoBehaviour
    {
        [SerializeField] private Sprite[] _Sprites; // Sprite 이미지 배열
        [SerializeField] private GameObject _BlockPrefab;
        private GameObject[,] _GameBoard;   // 블럭 저장용 게임보드;

        private Vector3 _screenPos; // 스크린의 0,0점의 월드좌표값 저장
        private float _ScreenWidth; // 스크린 넓이
        private float _BlockWidth;  // 블럭 너비

        public float _Xmargin = 2.0f;   // x축 여백
        public float _Ymargin = 4.0f;   // y축 여백

        private float _Scale = 0.0f;    // 블럭의 스케일 값 저장

        private int _Column = 0;
        private int _Row = 0;

        private Vector3 _StartPos = Vector3.zero;   // 마우스 클릭시 시작좌표
        private Vector3 _EndPos = Vector3.zero; // 마우스 클릭후 움직인 좌표

        private bool _IsOver = false;   // 클릭된 블럭 있는지 저장

        private GameObject _ClickObject;    // 클릭된 블럭 참조 저장

        private bool _MouseClick = false;   // 마우스 버튼이 눌려진 상태인지 아닌지 체크

        private float _MoveDistance = 0.05f;    // 시작점에서 끝점의 거리의 판단기준값


        private bool _InputOk = true;   // 입력이 계속 먹는 것을 방지

        private int TYPECOUNT = 4;  // 생성될 블럭의 종류수


        private List<GameObject> _RemovingBlocks = new List<GameObject>();  // 삭제될 블럭 저장
        private List<GameObject> _RemovedBlocks = new List<GameObject>();   // 삭제된 블럭 저장

        private GamePlayState PlayState { set; get; } = GamePlayState.INPUTOK;  // 현재의 게임 플레이 상태 저장

        [SerializeField] private float _YPOS = 3.0f;    // 블럭이 출현할 Y축 시작위치 값.


        // Start is called before the first frame update
        void Start()
        {
            // 스크린 0, 0좌표를 월드공간상에 좌표값으로 변환
            _screenPos = Camera.main.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, 10.0f));

            _screenPos.y = -_screenPos.y;

            _ScreenWidth = Mathf.Abs(_screenPos.x * 2); // 스크린의 넓이를 구한다.

            // 블럭이미지의 픽셀값을 100으로 나눠서 블럭 넓이를 구한다.
            _BlockWidth = _BlockPrefab.GetComponent<Block_T>().BlockImage.sprite.rect.size.x / 100;

            Debug.Log("_screenPos = " + _screenPos);

            MakeBoard(10, 10);
        }

        public void MoveBlocksLeft()
        {
            foreach (var obj in _GameBoard)
            {
                obj.GetComponent<Block_T>().Move(DIRECTION.LEFT);
            }
        }

        public void MoveBlocksRight()
        {
            foreach (var obj in _GameBoard)
            {
                obj.GetComponent<Block_T>().Move(DIRECTION.RIGHT);
            }
        }

        public void MoveBlocksUp()
        {
            foreach (var obj in _GameBoard)
            {
                obj.GetComponent<Block_T>().Move(DIRECTION.UP);
            }
        }

        public void MoveBlocksDown()
        {
            foreach (var obj in _GameBoard)
            {
                obj.GetComponent<Block_T>().Move(DIRECTION.DOWN);
            }
        }

        void MakeBoard(int column, int row)
        {
            float width = _ScreenWidth - (_Xmargin * 2);  // 출력되는 너비
            float blockWidth = _BlockWidth * row;   // 블럭의 전체 출력 너비


            _Scale = width / blockWidth;  // 블럭의 스케일

            _GameBoard = new GameObject[column, row];

            _Column = column;
            _Row = row;

            for (int co = 0; co < column; co++)
            {
                for (int ro = 0; ro < row; ro++)
                {
                    _GameBoard[co, ro] = Instantiate(_BlockPrefab);
                    _GameBoard[co, ro].transform.localScale = new Vector3(_Scale, _Scale, 0.0f);
                    _GameBoard[co, ro].transform.position =
                        new Vector3(
                            _screenPos.x + _Xmargin + ro * (_BlockWidth * _Scale) + (_BlockWidth * _Scale) / 2.0f,
                            _screenPos.y - _Ymargin - co * (_BlockWidth * _Scale) - (_BlockWidth * _Scale) / 2.0f,
                            0.0f
                        );


                    // -------------------------
                    int type = UnityEngine.Random.Range(0, TYPECOUNT);// _Sprites.Length);    // 이미지 번호를 랜덤하게 가지고 온다.

                    _GameBoard[co, ro].GetComponent<Block_T>().Type = type;
                    _GameBoard[co, ro].GetComponent<Block_T>().BlockImage.sprite = _Sprites[type];    // 블럭 이미지를 교체

                    // ---------------------------

                    _GameBoard[co, ro].GetComponent<Block_T>().Width = (_BlockWidth * _Scale); // 블럭의 너비값을 블럭에 전달                
                    _GameBoard[co, ro].GetComponent<Block_T>().MovePos = _GameBoard[co, ro].transform.position;   // 생성위치값 저장

                    _GameBoard[co, ro].GetComponent<Block_T>().Column = co;
                    _GameBoard[co, ro].GetComponent<Block_T>().Row = ro;

                    _GameBoard[co, ro].name = $"Block[{co}, {ro}]";
                }
            }
        }

        /// <summary>
        /// 3매칭된 블럭을 찾는다.
        /// </summary>
        private void CheckMatchBlock()
        {
            List<GameObject> matchList = new List<GameObject>();    // 매칭된 블럭 저장용
            List<GameObject> tempMatchList = new List<GameObject>();    // 임시로 매칭된 블럭을 저장

            int checkType = 0;  // 비교할 블럭 타입을 기록
            _RemovingBlocks.Clear();    // 삭제될 블럭 저장용 리스트 초기화

            // 세로 방향으로 match된 블럭 check
            for (int row = 0; row < _Row; row++)
            {
                if (_GameBoard[0, row] == null)
                {
                    continue;
                }

                checkType = _GameBoard[0, row].GetComponent<Block_T>().Type;  // 첫 행의 블럭의 type값을 가져온다.
                tempMatchList.Add(_GameBoard[0, row]);  // 처음 블럭을 임시 match블럭 저장공간에 추가한다.

                for (int col = 1; col < _Column; col++)
                {
                    if (_GameBoard[col, row] == null)
                    {
                        continue;
                    }

                    if (checkType == _GameBoard[col, row].GetComponent<Block_T>().Type)
                    {
                        tempMatchList.Add(_GameBoard[col, row]);
                    }
                    else
                    {
                        // 불일치가 난 위치에서 이전의 블럭이 3개 일치했음.
                        if (tempMatchList.Count >= 3)
                        {
                            matchList.AddRange(tempMatchList);
                            tempMatchList.Clear();

                            // 불일치가 난 위치의 블럭 타입을 값을 다시 셋팅
                            checkType = _GameBoard[col, row].GetComponent<Block_T>().Type;
                            tempMatchList.Add(_GameBoard[col, row]);

                        }
                        else // 불일치가 난 위치에서 이전의 블럭이 3개가 일치하지 않았음.
                        {
                            tempMatchList.Clear();

                            // 불일치가 난 위치의 블럭 타입을 값을 다시 셋팅
                            checkType = _GameBoard[col, row].GetComponent<Block_T>().Type;
                            tempMatchList.Add(_GameBoard[col, row]);

                        }
                    }


                }


                // 열에 따른 행을 다 돈후
                // tempmatchList의 count을 체크한다.
                if (tempMatchList.Count >= 3)
                {
                    matchList.AddRange(tempMatchList);
                    tempMatchList.Clear();
                }
                else
                {
                    tempMatchList.Clear();
                }
            }

            tempMatchList.Clear();


            // 가로 방향으로 Match블럭을 check
            for (int col = 0; col < _Column; col++)
            {
                if (_GameBoard[col, 0] == null)
                {
                    continue;
                }

                checkType = _GameBoard[col, 0].GetComponent<Block_T>().Type;  // 첫 행의 블럭의 type값을 저장
                tempMatchList.Add(_GameBoard[col, 0]);

                for (int row = 1; row < _Row; row++)
                {
                    if (_GameBoard[col, row] == null)
                    {
                        continue;
                    }

                    if (checkType == _GameBoard[col, row].GetComponent<Block_T>().Type)
                    {
                        tempMatchList.Add(_GameBoard[col, row]);
                    }
                    else // 해당의 위치의 블럭의 타입이 틀림
                    {
                        if (tempMatchList.Count >= 3)
                        {
                            matchList.AddRange(tempMatchList);
                            tempMatchList.Clear();

                            checkType = _GameBoard[col, row].GetComponent<Block_T>().Type;
                            tempMatchList.Add(_GameBoard[col, row]);
                        }
                        else  // 블럭의 매칭 갯수가 3보다 작은 경우
                        {
                            tempMatchList.Clear();
                            checkType = _GameBoard[col, row].GetComponent<Block_T>().Type;
                            tempMatchList.Add(_GameBoard[col, row]);

                        }

                    }
                }

                // 열을 다 돈후
                // 3개이상의 매칭된 경우
                if (tempMatchList.Count >= 3)
                {
                    matchList.AddRange(tempMatchList);
                    tempMatchList.Clear();
                }
                else
                {
                    tempMatchList.Clear();
                }
            }

            // matchList의 중복된 블럭을 추려냄
            matchList = matchList.Distinct().ToList();

            if (matchList.Count > 0)
            {
                foreach (var obj in matchList)
                {
                    // 매치된 블럭을 삭제처리
                    // 블럭보드상에서 해당위치의 블럭을 null로 처리한다.
                    _GameBoard[obj.GetComponent<Block_T>().Column, obj.GetComponent<Block_T>().Row] = null;

                    // 해당블럭 비활성화 (보드상에 안보이도록 처리)
                    obj.SetActive(false);
                }

                _RemovingBlocks.AddRange(matchList);
            }

            _RemovedBlocks.AddRange(_RemovingBlocks);   // 삭제될 블럭을 삭제블럭리스트에 저장하고

            _RemovedBlocks = _RemovedBlocks.Distinct().ToList();    // 중복된 블럭을 처리한다.

            DownMoveBlocks();   // 빈칸을 채우기위해 블럭을 하강시킨다.        
        }



        /// <summary>
        /// 삭제된 블럭의 칸만큼 기존 블럭을 이동해서 채운다.
        /// </summary>
        private void DownMoveBlocks()
        {
            int moveCount = 0;  // 하강해야할 칸수를 저장


            for (int row = 0; row < _Row; row++)
            {
                for (int col = _Column - 1; col >= 0; col--)
                {
                    // 게임 보드사에 블럭이 없는 경우
                    if (_GameBoard[col, row] == null)
                    {
                        moveCount++;
                    }
                    else  // 게임 보드상에 블럭이 있는 경우
                    {
                        if (moveCount > 0)   // 하강유무 체크
                        {
                            var block = _GameBoard[col, row].GetComponent<Block_T>();

                            block.MovePos = block.transform.position;   // 현재위치값을 기록;

                            // 이동할 위치값을 기록
                            block.MovePos = new Vector3(block.MovePos.x, block.MovePos.y - block.Width * moveCount, block.MovePos.z);

                            // _GameBoard 처리
                            // 이전에 있던 게임보드상의 위치를 초기화
                            _GameBoard[col, row] = null;

                            block.Column = block.Column + moveCount;    // 게임보드상의 이동할 위치로 변경
                            block.gameObject.name = $"Block[{block.Column}, {block.Row}]";  // 블럭이름을 변경한다.

                            _GameBoard[block.Column, block.Row] = block.gameObject; // 게임보드상의 이동할 위치에 블럭을 참조값을 저장

                            block.Move(DIRECTION.DOWN, moveCount);
                        }
                    }
                }

                moveCount = 0;
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
            if (_RemovedBlocks.Count <= 0)
            {
                return null;
            }

            // 삭제된 블럭을 저장한 리스트에서 블럭을 하나 가지고 온다.
            GameObject obj = _RemovedBlocks[0];
            // 블럭을 전달 받은 인자 값으로 초기화한다.
            obj.GetComponent<Block_T>().Init(column, row, type, _Sprites[type]);

            _RemovedBlocks.Remove(obj); // 전달한 블럭을 삭제된 블럭 저장 리스트에서 삭제처리

            return obj;

        }

        /// <summary>
        /// 게임보드상에 삭제된 블럭의 공간을 새로운 블럭으로 채움.
        /// </summary>    
        private void CreateMoveBlocks()
        {
            int moveCount = 0;  // 생성해야할 블럭의 갯수를 저장

            for (int row = 0; row < _Row; row++)
            {
                for (int col = _Column - 1; col >= 0; col--)
                {
                    // 게임보드상에 빈칸인지 체크
                    if (_GameBoard[col, row] == null)
                    {
                        // 생성할 블럭의 종류를 랜덤하게 생성
                        int type = UnityEngine.Random.Range(0, TYPECOUNT);

                        // 새로 생성된 블럭을 게임보드에 연결.
                        _GameBoard[col, row] = GetNewBlock(col, row, type);
                        // 블럭의 이름을 변경
                        _GameBoard[col, row].name = $"Block[{col}, {row}]";

                        _GameBoard[col, row].gameObject.SetActive(true);    // 블럭을 활성화(블럭을 화면상에 보이도록)

                        // 블럭 컴포넌트를 가지고 온다.
                        var block = _GameBoard[col, row].GetComponent<Block_T>();

                        // 새로 생성된 블럭의 이동 위치값을 계산
                        block.transform.position =
                            new Vector3(_screenPos.x + _Xmargin + (_BlockWidth * _Scale) / 2 + row * (_BlockWidth * _Scale),
                            _screenPos.y - _Ymargin - col * (_BlockWidth * _Scale) - (_BlockWidth * _Scale) / 2, 0.0f);

                        // 이동할 위치값을 MovePos에 기록
                        block.MovePos = block.transform.position;

                        // 하강할 위치의 초기값을 계산
                        float moveYpos = block.MovePos.y + (_BlockWidth * _Scale) * moveCount++ + _YPOS;

                        // 하강할 초기위치로 블럭을 이동
                        block.transform.position =
                            new Vector3(block.MovePos.x, moveYpos, block.MovePos.z);

                        // 블럭을 하강처리
                        block.Move(DIRECTION.DOWN, moveCount);
                    }
                }

                moveCount = 0;
            }

        }




        private float calculateAngle(Vector3 from, Vector3 to)
        {
            return Quaternion.FromToRotation(Vector3.up, to - from).eulerAngles.z;
        }

        /// <summary>
        /// 마우스 이동시 이동한 방향을 계산
        /// </summary>
        /// <returns></returns>
        private MouseMoveDirection calculateDirection()
        {
            float angle = calculateAngle(_StartPos, _EndPos);

            if (angle >= 315.0f && angle <= 360 || angle >= 0 && angle < 45.0f)
            {
                return MouseMoveDirection.MOUSEMOVEUP;
            }
            else if (angle >= 45.0f && angle < 135.0f)
            {
                return MouseMoveDirection.MOUSEMOVELEFT;
            }
            else if (angle >= 135.0f && angle < 225.0f)
            {
                return MouseMoveDirection.MOUSEMOVEDOWN;
            }
            else if (angle >= 225.0f && angle < 315.0f)
            {
                return MouseMoveDirection.MOUSEMOVERIGHT;
            }
            else
            {
                return MouseMoveDirection.MOUSEMOVEDOWN;
            }

        }


        /// <summary>
        /// 클릭된 상태에서 마우스커서을 이동시 호출
        /// </summary>
        private void MouseMove()
        {

            float diff = Vector2.Distance(_StartPos, _EndPos);

            Debug.Log("diff = " + diff);

            if (diff > _MoveDistance && _ClickObject != null && _InputOk)
            {
                //_InputOk = false;   // 입력을 막는다.
                MouseMoveDirection dir = calculateDirection();


                Debug.Log("direction = " + dir);

                switch (dir)
                {
                    case MouseMoveDirection.MOUSEMOVELEFT:
                        {
                            // 현재 클릭된 블럭의 행과 열값을 가지고 온다.
                            int column = _ClickObject.GetComponent<Block_T>().Column;
                            int row = _ClickObject.GetComponent<Block_T>().Row;

                            if (row > 0)
                            {
                                // 서로 바꿀 블럭의 열값을 변경
                                _GameBoard[column, row].GetComponent<Block_T>().Row = row - 1;
                                _GameBoard[column, row - 1].GetComponent<Block_T>().Row = row;

                                // GameBoard상의 블럭의 참조값을 바꾼다.
                                _GameBoard[column, row] = _GameBoard[column, row - 1];
                                _GameBoard[column, row - 1] = _ClickObject;

                                // 블럭을 좌우측으로 움직인다.
                                _GameBoard[column, row].GetComponent<Block_T>().Move(DIRECTION.RIGHT);
                                _GameBoard[column, row - 1].GetComponent<Block_T>().Move(DIRECTION.LEFT);

                                PlayState = GamePlayState.AFTERINPUTMOVECHECK;
                            }

                        }


                        break;


                    case MouseMoveDirection.MOUSEMOVERIGHT:
                        {
                            int column = _ClickObject.GetComponent<Block_T>().Column;
                            int row = _ClickObject.GetComponent<Block_T>().Row;

                            if (row < (_Row - 1))
                            {
                                // 블럭의 row값을 서로 바꾼다.
                                _GameBoard[column, row].GetComponent<Block_T>().Row = row + 1;
                                _GameBoard[column, row + 1].GetComponent<Block_T>().Row = row;

                                // 게임보드상의 블럭의 참조값을 바꾼다.
                                _GameBoard[column, row] = _GameBoard[column, row + 1];
                                _GameBoard[column, row + 1] = _ClickObject;

                                // 블럭을 좌측, 우측으로 움직인다.
                                _GameBoard[column, row].GetComponent<Block_T>().Move(DIRECTION.LEFT);
                                _GameBoard[column, row + 1].GetComponent<Block_T>().Move(DIRECTION.RIGHT);

                                PlayState = GamePlayState.AFTERINPUTMOVECHECK;
                            }
                        }
                        break;


                    case MouseMoveDirection.MOUSEMOVEUP:
                        {
                            int column = _ClickObject.GetComponent<Block_T>().Column;
                            int row = _ClickObject.GetComponent<Block_T>().Row;

                            if (column > 0)
                            {
                                // 블럭의 column값을 서로 바꾼다.
                                _GameBoard[column, row].GetComponent<Block_T>().Column = column - 1;
                                _GameBoard[column - 1, row].GetComponent<Block_T>().Column = column;

                                // 게임보드상의 블럭의 참조값을 바꾼다.
                                _GameBoard[column, row] = _GameBoard[column - 1, row];
                                _GameBoard[column - 1, row] = _ClickObject;

                                // 블럭을 하측, 상측으로 이동
                                _GameBoard[column, row].GetComponent<Block_T>().Move(DIRECTION.DOWN);
                                _GameBoard[column - 1, row].GetComponent<Block_T>().Move(DIRECTION.UP);

                                PlayState = GamePlayState.AFTERINPUTMOVECHECK;

                            }
                        }

                        break;

                    case MouseMoveDirection.MOUSEMOVEDOWN:
                        {
                            int column = _ClickObject.GetComponent<Block_T>().Column;
                            int row = _ClickObject.GetComponent<Block_T>().Row;

                            if (column < (_Column - 1))
                            {
                                // 블럭의 컬럼값을 바꾼다.
                                _GameBoard[column, row].GetComponent<Block_T>().Column = column + 1;
                                _GameBoard[column + 1, row].GetComponent<Block_T>().Column = column;

                                // 게임보드상의 블럭의 참조값을 바꾼다.
                                _GameBoard[column, row] = _GameBoard[column + 1, row];
                                _GameBoard[column + 1, row] = _ClickObject;

                                // 블럭을 상측, 하측으로 이동
                                _GameBoard[column, row].GetComponent<Block_T>().Move(DIRECTION.UP);
                                _GameBoard[column + 1, row].GetComponent<Block_T>().Move(DIRECTION.DOWN);

                                PlayState = GamePlayState.AFTERINPUTMOVECHECK;
                            }

                        }
                        break;
                }
            }
        }


        /// <summary>
        /// 움직이는 블럭이 있는지 체크
        /// </summary>
        /// <returns></returns>
        private bool CheckBlockMove()
        {
            foreach (var obj in _GameBoard)
            {
                if (obj != null)
                {
                    if (obj.GetComponent<Block_T>().State == BLOCKSTATE.MOVE)
                    {
                        return true;
                    }
                }
            }

            return false;
        }


        /// <summary>
        /// 게임보드상에 모든 블럭이 있는지 체크
        /// </summary>
        /// <returns></returns>
        private bool CheckAllBlockInGameBoard()
        {
            foreach (var obj in _GameBoard)
            {
                if (obj == null)
                {
                    return false;
                }
            }

            return true;

        }

        /// <summary>
        /// 마우스 입력처리함수
        /// </summary>
        private void InputProcess()
        {
            if (Input.GetMouseButtonDown(0))
            {

                _MouseClick = true;

                Vector3 pos = Input.mousePosition;
                _EndPos = _StartPos = Camera.main.ScreenToWorldPoint(new Vector3(pos.x, pos.y, 10.0f)); // 클릭이 되었을때 위치를 
                                                                                                        // 시작점과 끝점위치값으로 초기화
                _EndPos.z = _StartPos.z = 0.0f;


                Debug.Log("mouse click pos = " + pos);
                _IsOver = false;

                for (int i = 0; i < _Column; i++)
                {
                    for (int j = 0; j < _Row; j++)
                    {
                        if (_GameBoard[i, j] != null)
                        {
                            _IsOver = _GameBoard[i, j].GetComponent<Block_T>().BlockImage.GetComponent<SpriteRenderer>().bounds.Contains(_StartPos);
                        }

                        if (_IsOver)
                        {
                            _ClickObject = _GameBoard[i, j];

                            goto LoopExit;

                        }
                    }
                }

            LoopExit:;
            }

            // 마우스 버튼을 놨을때
            if (Input.GetMouseButtonUp(0))
            {
                _ClickObject = null;
                _MouseClick = false;
            }


            // 마우스 클릭한 후에 커서를 이동시
            if ((_MouseClick == true) && ((Input.GetAxis("Mouse X") < 0) || (Input.GetAxis("Mouse X") > 0)
                || (Input.GetAxis("Mouse Y") < 0) || (Input.GetAxis("Mouse Y") > 0)))
            {

                Vector3 pos = Input.mousePosition;
                _EndPos = Camera.main.ScreenToWorldPoint(new Vector3(pos.x, pos.y, 10.0f));
                _EndPos.z = 0.0f;

                MouseMove();

            }

        }

        // Update is called once per frame
        void Update()
        {
            switch (PlayState)
            {
                case GamePlayState.INPUTOK:
                    {
                        InputProcess();
                    }
                    break;

                case GamePlayState.AFTERINPUTMOVECHECK: // 입력후에 블럭의 움직임을 체크한다.
                    {
                        if (!CheckBlockMove())
                        {
                            // 모든 블럭의 움직임이 끝났음, 다음 상태로 변경
                            PlayState = GamePlayState.MATCHCHECK;
                        }
                    }

                    break;

                case GamePlayState.MATCHCHECK:
                    {
                        CheckMatchBlock();
                        PlayState = GamePlayState.AFTERMATCHCHECK_MOVECHECK;
                    }
                    break;

                case GamePlayState.DROPBLOCK:
                    {
                        CreateMoveBlocks();
                        PlayState = GamePlayState.AFTERDROPBLOCKBLOCK_MOVECHECK;
                    }
                    break;


                case GamePlayState.AFTERMATCHCHECK_MOVECHECK:
                    {
                        // 블럭들의 움직이 전부 다 멈춤상태인지 체크
                        if (!CheckBlockMove())
                        {
                            // 게임 보드상에 모든 블럭이 있는지 체크
                            if (CheckAllBlockInGameBoard())
                            {
                                PlayState = GamePlayState.INPUTOK;
                            }
                            else
                            {
                                PlayState = GamePlayState.DROPBLOCK;
                            }

                        }

                    }

                    break;


                case GamePlayState.AFTERDROPBLOCKBLOCK_MOVECHECK:
                    {
                        if (!CheckBlockMove())
                        {
                            PlayState = GamePlayState.MATCHCHECK;
                        }
                    }
                    break;
            }
        }
    }
}