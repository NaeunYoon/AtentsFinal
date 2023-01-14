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
        INPUTOK, // ���� ����
        AFTERINPUTMOVECHECK,
        MATCHCHECK, // ���� ���� 3�� �ִ��� üũ
        AFTERMATCHCHECK_MOVECHECK, // MatchCheck�Ŀ� ���� �����̴� �������� üũ
        DROPBLOCK,  // ���ο� �� ��ġ
        AFTERDROPBLOCKBLOCK_MOVECHECK,  // DropBlock �Ŀ� ���� �����̴� �������� üũ
        INPUTCANCEL
    };


    public class BoardManager : MonoBehaviour
    {
        [SerializeField] private Sprite[] _Sprites; // Sprite �̹��� �迭
        [SerializeField] private GameObject _BlockPrefab;
        private GameObject[,] _GameBoard;   // �� ����� ���Ӻ���;

        private Vector3 _screenPos; // ��ũ���� 0,0���� ������ǥ�� ����
        private float _ScreenWidth; // ��ũ�� ����
        private float _BlockWidth;  // �� �ʺ�

        public float _Xmargin = 2.0f;   // x�� ����
        public float _Ymargin = 4.0f;   // y�� ����

        private float _Scale = 0.0f;    // ���� ������ �� ����

        private int _Column = 0;
        private int _Row = 0;

        private Vector3 _StartPos = Vector3.zero;   // ���콺 Ŭ���� ������ǥ
        private Vector3 _EndPos = Vector3.zero; // ���콺 Ŭ���� ������ ��ǥ

        private bool _IsOver = false;   // Ŭ���� �� �ִ��� ����

        private GameObject _ClickObject;    // Ŭ���� �� ���� ����

        private bool _MouseClick = false;   // ���콺 ��ư�� ������ �������� �ƴ��� üũ

        private float _MoveDistance = 0.05f;    // ���������� ������ �Ÿ��� �Ǵܱ��ذ�


        private bool _InputOk = true;   // �Է��� ��� �Դ� ���� ����

        private int TYPECOUNT = 4;  // ������ ���� ������


        private List<GameObject> _RemovingBlocks = new List<GameObject>();  // ������ �� ����
        private List<GameObject> _RemovedBlocks = new List<GameObject>();   // ������ �� ����

        private GamePlayState PlayState { set; get; } = GamePlayState.INPUTOK;  // ������ ���� �÷��� ���� ����

        [SerializeField] private float _YPOS = 3.0f;    // ���� ������ Y�� ������ġ ��.


        // Start is called before the first frame update
        void Start()
        {
            // ��ũ�� 0, 0��ǥ�� ��������� ��ǥ������ ��ȯ
            _screenPos = Camera.main.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, 10.0f));

            _screenPos.y = -_screenPos.y;

            _ScreenWidth = Mathf.Abs(_screenPos.x * 2); // ��ũ���� ���̸� ���Ѵ�.

            // ���̹����� �ȼ����� 100���� ������ �� ���̸� ���Ѵ�.
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
            float width = _ScreenWidth - (_Xmargin * 2);  // ��µǴ� �ʺ�
            float blockWidth = _BlockWidth * row;   // ���� ��ü ��� �ʺ�


            _Scale = width / blockWidth;  // ���� ������

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
                    int type = UnityEngine.Random.Range(0, TYPECOUNT);// _Sprites.Length);    // �̹��� ��ȣ�� �����ϰ� ������ �´�.

                    _GameBoard[co, ro].GetComponent<Block_T>().Type = type;
                    _GameBoard[co, ro].GetComponent<Block_T>().BlockImage.sprite = _Sprites[type];    // �� �̹����� ��ü

                    // ---------------------------

                    _GameBoard[co, ro].GetComponent<Block_T>().Width = (_BlockWidth * _Scale); // ���� �ʺ��� ���� ����                
                    _GameBoard[co, ro].GetComponent<Block_T>().MovePos = _GameBoard[co, ro].transform.position;   // ������ġ�� ����

                    _GameBoard[co, ro].GetComponent<Block_T>().Column = co;
                    _GameBoard[co, ro].GetComponent<Block_T>().Row = ro;

                    _GameBoard[co, ro].name = $"Block[{co}, {ro}]";
                }
            }
        }

        /// <summary>
        /// 3��Ī�� ���� ã�´�.
        /// </summary>
        private void CheckMatchBlock()
        {
            List<GameObject> matchList = new List<GameObject>();    // ��Ī�� �� �����
            List<GameObject> tempMatchList = new List<GameObject>();    // �ӽ÷� ��Ī�� ���� ����

            int checkType = 0;  // ���� �� Ÿ���� ���
            _RemovingBlocks.Clear();    // ������ �� ����� ����Ʈ �ʱ�ȭ

            // ���� �������� match�� �� check
            for (int row = 0; row < _Row; row++)
            {
                if (_GameBoard[0, row] == null)
                {
                    continue;
                }

                checkType = _GameBoard[0, row].GetComponent<Block_T>().Type;  // ù ���� ���� type���� �����´�.
                tempMatchList.Add(_GameBoard[0, row]);  // ó�� ���� �ӽ� match�� ��������� �߰��Ѵ�.

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
                        // ����ġ�� �� ��ġ���� ������ ���� 3�� ��ġ����.
                        if (tempMatchList.Count >= 3)
                        {
                            matchList.AddRange(tempMatchList);
                            tempMatchList.Clear();

                            // ����ġ�� �� ��ġ�� �� Ÿ���� ���� �ٽ� ����
                            checkType = _GameBoard[col, row].GetComponent<Block_T>().Type;
                            tempMatchList.Add(_GameBoard[col, row]);

                        }
                        else // ����ġ�� �� ��ġ���� ������ ���� 3���� ��ġ���� �ʾ���.
                        {
                            tempMatchList.Clear();

                            // ����ġ�� �� ��ġ�� �� Ÿ���� ���� �ٽ� ����
                            checkType = _GameBoard[col, row].GetComponent<Block_T>().Type;
                            tempMatchList.Add(_GameBoard[col, row]);

                        }
                    }


                }


                // ���� ���� ���� �� ����
                // tempmatchList�� count�� üũ�Ѵ�.
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


            // ���� �������� Match���� check
            for (int col = 0; col < _Column; col++)
            {
                if (_GameBoard[col, 0] == null)
                {
                    continue;
                }

                checkType = _GameBoard[col, 0].GetComponent<Block_T>().Type;  // ù ���� ���� type���� ����
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
                    else // �ش��� ��ġ�� ���� Ÿ���� Ʋ��
                    {
                        if (tempMatchList.Count >= 3)
                        {
                            matchList.AddRange(tempMatchList);
                            tempMatchList.Clear();

                            checkType = _GameBoard[col, row].GetComponent<Block_T>().Type;
                            tempMatchList.Add(_GameBoard[col, row]);
                        }
                        else  // ���� ��Ī ������ 3���� ���� ���
                        {
                            tempMatchList.Clear();
                            checkType = _GameBoard[col, row].GetComponent<Block_T>().Type;
                            tempMatchList.Add(_GameBoard[col, row]);

                        }

                    }
                }

                // ���� �� ����
                // 3���̻��� ��Ī�� ���
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

            // matchList�� �ߺ��� ���� �߷���
            matchList = matchList.Distinct().ToList();

            if (matchList.Count > 0)
            {
                foreach (var obj in matchList)
                {
                    // ��ġ�� ���� ����ó��
                    // ������󿡼� �ش���ġ�� ���� null�� ó���Ѵ�.
                    _GameBoard[obj.GetComponent<Block_T>().Column, obj.GetComponent<Block_T>().Row] = null;

                    // �ش�� ��Ȱ��ȭ (����� �Ⱥ��̵��� ó��)
                    obj.SetActive(false);
                }

                _RemovingBlocks.AddRange(matchList);
            }

            _RemovedBlocks.AddRange(_RemovingBlocks);   // ������ ���� ����������Ʈ�� �����ϰ�

            _RemovedBlocks = _RemovedBlocks.Distinct().ToList();    // �ߺ��� ���� ó���Ѵ�.

            DownMoveBlocks();   // ��ĭ�� ä������� ���� �ϰ���Ų��.        
        }



        /// <summary>
        /// ������ ���� ĭ��ŭ ���� ���� �̵��ؼ� ä���.
        /// </summary>
        private void DownMoveBlocks()
        {
            int moveCount = 0;  // �ϰ��ؾ��� ĭ���� ����


            for (int row = 0; row < _Row; row++)
            {
                for (int col = _Column - 1; col >= 0; col--)
                {
                    // ���� ����翡 ���� ���� ���
                    if (_GameBoard[col, row] == null)
                    {
                        moveCount++;
                    }
                    else  // ���� ����� ���� �ִ� ���
                    {
                        if (moveCount > 0)   // �ϰ����� üũ
                        {
                            var block = _GameBoard[col, row].GetComponent<Block_T>();

                            block.MovePos = block.transform.position;   // ������ġ���� ���;

                            // �̵��� ��ġ���� ���
                            block.MovePos = new Vector3(block.MovePos.x, block.MovePos.y - block.Width * moveCount, block.MovePos.z);

                            // _GameBoard ó��
                            // ������ �ִ� ���Ӻ������ ��ġ�� �ʱ�ȭ
                            _GameBoard[col, row] = null;

                            block.Column = block.Column + moveCount;    // ���Ӻ������ �̵��� ��ġ�� ����
                            block.gameObject.name = $"Block[{block.Column}, {block.Row}]";  // ���̸��� �����Ѵ�.

                            _GameBoard[block.Column, block.Row] = block.gameObject; // ���Ӻ������ �̵��� ��ġ�� ���� �������� ����

                            block.Move(DIRECTION.DOWN, moveCount);
                        }
                    }
                }

                moveCount = 0;
            }
        }


        /// <summary>
        /// ������ ������ ���� �����Ѵ�.
        /// </summary>
        /// <param name="column"></param>
        /// <param name="row"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        private GameObject GetNewBlock(int column, int row, int type)
        {
            // ������ ���� ���� ���
            // �ش� ���� �߻��ϸ� �ȵ�.
            if (_RemovedBlocks.Count <= 0)
            {
                return null;
            }

            // ������ ���� ������ ����Ʈ���� ���� �ϳ� ������ �´�.
            GameObject obj = _RemovedBlocks[0];
            // ���� ���� ���� ���� ������ �ʱ�ȭ�Ѵ�.
            obj.GetComponent<Block_T>().Init(column, row, type, _Sprites[type]);

            _RemovedBlocks.Remove(obj); // ������ ���� ������ �� ���� ����Ʈ���� ����ó��

            return obj;

        }

        /// <summary>
        /// ���Ӻ���� ������ ���� ������ ���ο� ������ ä��.
        /// </summary>    
        private void CreateMoveBlocks()
        {
            int moveCount = 0;  // �����ؾ��� ���� ������ ����

            for (int row = 0; row < _Row; row++)
            {
                for (int col = _Column - 1; col >= 0; col--)
                {
                    // ���Ӻ���� ��ĭ���� üũ
                    if (_GameBoard[col, row] == null)
                    {
                        // ������ ���� ������ �����ϰ� ����
                        int type = UnityEngine.Random.Range(0, TYPECOUNT);

                        // ���� ������ ���� ���Ӻ��忡 ����.
                        _GameBoard[col, row] = GetNewBlock(col, row, type);
                        // ���� �̸��� ����
                        _GameBoard[col, row].name = $"Block[{col}, {row}]";

                        _GameBoard[col, row].gameObject.SetActive(true);    // ���� Ȱ��ȭ(���� ȭ��� ���̵���)

                        // �� ������Ʈ�� ������ �´�.
                        var block = _GameBoard[col, row].GetComponent<Block_T>();

                        // ���� ������ ���� �̵� ��ġ���� ���
                        block.transform.position =
                            new Vector3(_screenPos.x + _Xmargin + (_BlockWidth * _Scale) / 2 + row * (_BlockWidth * _Scale),
                            _screenPos.y - _Ymargin - col * (_BlockWidth * _Scale) - (_BlockWidth * _Scale) / 2, 0.0f);

                        // �̵��� ��ġ���� MovePos�� ���
                        block.MovePos = block.transform.position;

                        // �ϰ��� ��ġ�� �ʱⰪ�� ���
                        float moveYpos = block.MovePos.y + (_BlockWidth * _Scale) * moveCount++ + _YPOS;

                        // �ϰ��� �ʱ���ġ�� ���� �̵�
                        block.transform.position =
                            new Vector3(block.MovePos.x, moveYpos, block.MovePos.z);

                        // ���� �ϰ�ó��
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
        /// ���콺 �̵��� �̵��� ������ ���
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
        /// Ŭ���� ���¿��� ���콺Ŀ���� �̵��� ȣ��
        /// </summary>
        private void MouseMove()
        {

            float diff = Vector2.Distance(_StartPos, _EndPos);

            Debug.Log("diff = " + diff);

            if (diff > _MoveDistance && _ClickObject != null && _InputOk)
            {
                //_InputOk = false;   // �Է��� ���´�.
                MouseMoveDirection dir = calculateDirection();


                Debug.Log("direction = " + dir);

                switch (dir)
                {
                    case MouseMoveDirection.MOUSEMOVELEFT:
                        {
                            // ���� Ŭ���� ���� ��� ������ ������ �´�.
                            int column = _ClickObject.GetComponent<Block_T>().Column;
                            int row = _ClickObject.GetComponent<Block_T>().Row;

                            if (row > 0)
                            {
                                // ���� �ٲ� ���� ������ ����
                                _GameBoard[column, row].GetComponent<Block_T>().Row = row - 1;
                                _GameBoard[column, row - 1].GetComponent<Block_T>().Row = row;

                                // GameBoard���� ���� �������� �ٲ۴�.
                                _GameBoard[column, row] = _GameBoard[column, row - 1];
                                _GameBoard[column, row - 1] = _ClickObject;

                                // ���� �¿������� �����δ�.
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
                                // ���� row���� ���� �ٲ۴�.
                                _GameBoard[column, row].GetComponent<Block_T>().Row = row + 1;
                                _GameBoard[column, row + 1].GetComponent<Block_T>().Row = row;

                                // ���Ӻ������ ���� �������� �ٲ۴�.
                                _GameBoard[column, row] = _GameBoard[column, row + 1];
                                _GameBoard[column, row + 1] = _ClickObject;

                                // ���� ����, �������� �����δ�.
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
                                // ���� column���� ���� �ٲ۴�.
                                _GameBoard[column, row].GetComponent<Block_T>().Column = column - 1;
                                _GameBoard[column - 1, row].GetComponent<Block_T>().Column = column;

                                // ���Ӻ������ ���� �������� �ٲ۴�.
                                _GameBoard[column, row] = _GameBoard[column - 1, row];
                                _GameBoard[column - 1, row] = _ClickObject;

                                // ���� ����, �������� �̵�
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
                                // ���� �÷����� �ٲ۴�.
                                _GameBoard[column, row].GetComponent<Block_T>().Column = column + 1;
                                _GameBoard[column + 1, row].GetComponent<Block_T>().Column = column;

                                // ���Ӻ������ ���� �������� �ٲ۴�.
                                _GameBoard[column, row] = _GameBoard[column + 1, row];
                                _GameBoard[column + 1, row] = _ClickObject;

                                // ���� ����, �������� �̵�
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
        /// �����̴� ���� �ִ��� üũ
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
        /// ���Ӻ���� ��� ���� �ִ��� üũ
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
        /// ���콺 �Է�ó���Լ�
        /// </summary>
        private void InputProcess()
        {
            if (Input.GetMouseButtonDown(0))
            {

                _MouseClick = true;

                Vector3 pos = Input.mousePosition;
                _EndPos = _StartPos = Camera.main.ScreenToWorldPoint(new Vector3(pos.x, pos.y, 10.0f)); // Ŭ���� �Ǿ����� ��ġ�� 
                                                                                                        // �������� ������ġ������ �ʱ�ȭ
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

            // ���콺 ��ư�� ������
            if (Input.GetMouseButtonUp(0))
            {
                _ClickObject = null;
                _MouseClick = false;
            }


            // ���콺 Ŭ���� �Ŀ� Ŀ���� �̵���
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

                case GamePlayState.AFTERINPUTMOVECHECK: // �Է��Ŀ� ���� �������� üũ�Ѵ�.
                    {
                        if (!CheckBlockMove())
                        {
                            // ��� ���� �������� ������, ���� ���·� ����
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
                        // ������ ������ ���� �� ����������� üũ
                        if (!CheckBlockMove())
                        {
                            // ���� ����� ��� ���� �ִ��� üũ
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