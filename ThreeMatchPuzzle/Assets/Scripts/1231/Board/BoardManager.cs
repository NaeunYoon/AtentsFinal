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

    int Column = 0;
    int Row = 0;

    //���콺�� Ŭ���������� ���� ��ġ�� ���ϴ� ������ġ
    private Vector3 _startPos = Vector3.zero;
    //���콺 Ŭ�� �� ������ ��ǥ
    private Vector3 _endPos = Vector3.zero;
    private bool _isOver = false;   //Ŭ���� �� �ִ��� ����
    //Ŭ���� ������Ʈ�� ������ ���� 
    private GameObject _clickObject;
    //���콺 ��ư�� ������ �������� �ƴ��� üũ
    private bool _mouseClick =false;
    //���� ���� (���������� ������ �Ÿ��� �Ǵ� ���ذ�
    private float _moveDistance = 0.05f;
    //�Է��� ��� �Դ� ���� ����
    private bool _inputOK = true;

    [SerializeField] private Sprite[] _sprites; //sprite �̹��� �迭
    //������ �� ����
    private List<GameObject> _removingBlocks = new List<GameObject>();
    //������ �� ����
    private List<GameObject> _removedBlocks = new List<GameObject>();

    private int TYPECOUNT = 4; //������ ���� ���� ��
    void Start()
    {
        //============================================================================================02
        //��ũ�� (���ϴ�)0,0 ��ǥ�� ���� �������� ��ǥ������ ��ȯ 
        _screenPos = Camera.main.ScreenToWorldPoint(new Vector3(0f,0f,10f));
        Debug.Log("ScreenPos "+_screenPos);
        //3D �������� �߾��� 0.0 �̶�� �ϸ� (���ϴ�) 
        //����������� ���ϴ��� -2.8, -5.0, 0.0
        //����������� �»���� -2.8, 5.0, 0.0
        //����������� ������ 2.8,5,0,0.0
        //����������� ���ϴ��� 2.8 -5,0,0.0
        //��ũ�� �������� ��ǥ�� ������ 3d���� ������ ��ǥ�� ���� �� �ִ�
        _screenPos.y = -_screenPos.y;   
        //��ũ���� y���� - ����. ���� �Ȱ��� �� ��ȣ�� �ٸ��� �ؼ� �����ָ� +�� �ȴ�(+y �� �ȴ�)
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


        MakeBoard(5,5);
    }

    void MakeBoard(int column, int row) //����ġ�ϴ� �Լ�
    {
        float width = _screenWidth - (_xMargin*2);  //��µǴ� �ʺ� ( ������ ����)
        //���� ��� �ʺ� = ���� �ʺ� * ��ü ����
        float blockWidth = _blockWidth * row;
        //���� ���̿��� ��ũ���� ���̸� ������ ���� ����� ������ �� �ִ�
        _blockScale = width / blockWidth; //���� ������ ��
        _gameBoard = new GameObject[column, row];

        Column= column;
        Row= row;

        for (int co = 0; co < column; co++)
        {
            for (int ro = 0; ro < row; ro++)
            {

                //�ʱ��ڵ� ======================================================================================01
                //0.0���� ��ġ�� �Ǳ� ������ ��ü���� ������ ���� ��ܿ� ��ġ�� �ȴ�. (��ũ����ǥ�谡 ������)
                //���� 3d������ �ִ�. ���� �츮�� 3d �������� ��ǥ�� ã�ƾ� �Ѵ� (��ũ�� ��ǥ���� ���ϱ�)
                //var blockObj = Instantiate(_blockPrefab);
                //blockObj.transform.position = new Vector3(ro, -co, 0f);
                //================================================================================================03
                //��ũ����ǥ���� �ݿ��ؼ� y����  �ٲ��ش� (y�� ����)
                //blockObj.transform.position = new Vector3(ro, _scrennPos.y-co, 0f);
                //���� �� ������ y�� 5�� ���缭 �Ʒ��� ���ĵȴ�
                //================================================================================================04
                //�̹����� x ���� �����ؼ� ������ ����� ���߷��� ��
                //blockObj.transform.position = new Vector3(_scrennPos.x+ro, _scrennPos.y-co, 0f);
                //���� ����� �������� ��µȴ�
                //================================================================================================05
                //���� �߽ɺκ��� �������� �ϱ� ������ ���� ©���� �뷫 0.5 ������ ���ؼ� �����ش�(�� ����� 1�̶�� ��)
                //blockObj.transform.position = new Vector3(_scrennPos.x+ro+0.5f, _scrennPos.y-co-0.5f, 0f);
                //���� ����� �������� ��µȴ�
                //================================================================================================06
                //��ü ���ΰ� 2.8*2
                //private Vector3 _screenPos; //��ũ�� 0,0 ���� ���� ��ǥ�� ����
                //private float _screenWidth;   //��ũ���� ����
                //private float _blockWidth; //���� ����
                //�̷��� �޾��ְ�,
                /*
                _screenPos.y = -_screenPos.y;   
                //��ũ���� y���� - ����. ���� �Ȱ��� �� ��ȣ�� �ٸ��� �ؼ� �����ָ� +�� �ȴ�(+y �� �ȴ�)
                _screenWidth = Mathf.Abs(_screenPos.x * 2); //��ũ���� �ʺ� ���Ѵ�*/
                //================================================================================================07
                //��Ȯ�� ���� �̹��� ����� �˰� �ʹ� ( ���� �� ��ũ��Ʈ�� �ϳ� �����)
                //================================================================================================08
                /*
                 //�� �̹����� �ȼ����� 100���� ������ �� ���̸� ���Ѵ�
                //�̹��� ũ�Ⱑ 100 �̶�� �� �� �ȼ��� ������ �ʺ�� 100 ���̷� 100�� �ִٴ� ���̴�
                //�װ��� 3d �������� �ʺ����� �ٲٴ� ����� �ȼ����� 100���� ������ �ȴ�
                //�ȼ����� 1000�̸� �̹����� �ʺ� 10�� �Ǵ� ���̵�
                //�ȼ����� 50�̸� �̹����� �ʺ� 0.5�� �Ǵ� ���̴�
                //����Ƽ �⺻���� 100�̱� ������ 100���� ���� ���̴�
                //100�ȼ��� 1�����̰� 1�����̴� => ����Ƽ����
                _blockWidth = _blockPrefab.GetComponent<Block>().blockImage.sprite.rect.size.x / 100;   //���� width�� ��������
                //�ȼ������ 100���� ������ 3d �������� 1�� ����
                //�̹��� ũ�Ⱑ 100�̶�� �ϸ� �ʺ�� 100 ���̷� 100 ���� �ȼ��� �ִ°ǵ�, �̰� 3d �������� �ʺ����� �ٲٷ���
                //�ȼ����� 100���� ������ ����Ƽ ������ ������ �ٲ��ִ°Ŵ�. (�ȼ����� -> 3d �������� ���� : default ������ 100�� = 1����)
                //���鰪�� �Է��ϰ� ����� ����ϰ��� ��
                 */
                //================================================================================================09
                //blockObj.transform.localScale = new Vector3(_blockScale, _blockScale, 0f);
                //���� ȭ�� �ȿ� �� ������ �Ѵ�
                //   _blockScale = width / blockWidth; //���� ������ ��


                _gameBoard[co,ro] = Instantiate<GameObject>(_blockPrefab);  //������ instantiate
                _gameBoard[co, ro].transform.SetParent(_parents);   //�θ� ���ؼ� ������Ʈ�� �־����� (�������ؼ�)


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
                //blockObj.GetComponent<Block>().Width = _blockWidth; //���� �ʺ��� ���� ����
                //blockObj.GetComponent<Block>().MovePos = blockObj.transform.position;   //������ġ�� ����
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
    /// Ŭ���� ���¿��� ���콺 Ŀ�� �̵��� ȣ��
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
                            //���� �ٲ� ���� ������ ����
                            _gameBoard[column,row].GetComponent<Block>()._row= row-1;
                            _gameBoard[column, row-1].GetComponent<Block>()._row = row;

                            //GameBoard ���� ���� �������� �ٲ۴�
                            _gameBoard[column,row] = _gameBoard[column,row-1];
                            _gameBoard[column, row - 1] = _clickObject;

                            //���� �¿������� �����ΰ�
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
                            //���� �ٲ� ���� ������ ����
                            _gameBoard[column, row].GetComponent<Block>()._row = row + 1;
                            _gameBoard[column, row + 1].GetComponent<Block>()._row = row;

                            //GameBoard ���� ���� �������� �ٲ۴�
                            _gameBoard[column, row] = _gameBoard[column, row + 1];
                            _gameBoard[column, row + 1] = _clickObject;

                            //���� �¿������� �����ΰ�
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
                            //���� �ٲ� ���� ������ ����
                            _gameBoard[column, row].GetComponent<Block>()._column = column - 1;
                            _gameBoard[column-1, row].GetComponent<Block>()._column = column;

                            //GameBoard ���� ���� �������� �ٲ۴�
                            _gameBoard[column, row] = _gameBoard[column-1, row];
                            _gameBoard[column-1, row] = _clickObject;

                            //���� �¿������� �����ΰ�
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
                            //���� �ٲ� ���� ������ ����
                            _gameBoard[column, row].GetComponent<Block>()._column = column + 1;
                            _gameBoard[column + 1, row].GetComponent<Block>()._column = column;

                            //GameBoard ���� ���� �������� �ٲ۴�
                            _gameBoard[column, row] = _gameBoard[column + 1, row];
                            _gameBoard[column + 1, row] = _clickObject;

                            //���� �¿������� �����ΰ�
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
    /// ���콺 �̵� �� �̵��� ������ ���
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
    /// ������ ���ϴ� �Լ� ( ���� �߿����� �츮�� z �ุ ������ �ȴ�
    /// </summary>
    /// <param name="from"></param>
    /// <param name="to"></param>
    /// <returns></returns>
    private float CalculateAngle(Vector3 from, Vector3 to)
    {
        return Quaternion.FromToRotation(Vector3.up, to - from).eulerAngles.z;
    }
    /// <summary>
    /// 3��Ī�� ���� ã�´�
    /// </summary>
    private void CheckMatchBlock()
    {
        List<GameObject> matchList = new List<GameObject>();
        List<GameObject> tmpMatchList = new List<GameObject>();
        //���� �� Ÿ���� ���
        int checkType = 0;
        //������ �� ����� ����Ʈ �ʱ�ȭ
        _removedBlocks.Clear();

        //���ι������� ��ġ�� ��
        for (int i = 0; i < Row; i++)
        {
            if (_gameBoard[0, i]==null)
            {
                continue;
            }
            //ù ���� ���� Ÿ�԰��� �����´�

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
                    //����ġ�� �� ��ġ���� ������ ���� 3�� ��ġ�ߴ�
                    if (tmpMatchList.Count >= 3)
                    {
                        matchList.AddRange(tmpMatchList);
                        tmpMatchList.Clear();   //�������� ����

                        //����ġ�� �� ��ġ�� �� Ÿ���� ���� �ٽ� ����
                        checkType = _gameBoard[j,i].GetComponent<Block>().Type;
                        tmpMatchList.Add(_gameBoard[j, i]);

                    }
                    //����ġ�� �� ��ġ���� ������ ���� 3�� ��ġ���� �ʾ���
                    else
                    {
                        tmpMatchList.Clear();
                        //����ġ�� �� ��ġ�� �� Ÿ���� ���� �ٽ� ����
                        checkType = _gameBoard[j, i].GetComponent<Block>().Type;
                        tmpMatchList.Add(_gameBoard[j, i]);
                    }
                }
            }
            //���� ���� ���� �� �� ��
            //tmpmatchList�� count�� üũ�Ѵ�
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

        //���ι������� ��ġ ���� üũ
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
            //���� �� �� ��

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
        

        //matchList�� �ߺ��� ���� �߷���
        //�ߺ��Ȱ� ���� ����
        matchList = matchList.Distinct().ToList();
        if (matchList.Count > 0)
        {
            foreach (var item in matchList)
            {
                //����󿡼� ���� ���ֹ����� (��ġ�� ���� ����ó��)
                //���� �󿡼� �ش� ��ġ�� ���� ��ó�� �Ѵ�
                _gameBoard[item.GetComponent<Block>()._column, item.GetComponent<Block>()._row] = null;
                //�ش� ���� ��Ȱ��ȭ��Ų��.
                item.SetActive(false);
            }
            //���� ������ ������ ���� ������Ʈ�� �����ϱ�
            _removedBlocks.AddRange(matchList);
        }
        //������ ���� ���� ������Ʈ�� �����ϰ�
        _removedBlocks.AddRange(_removingBlocks);
        //�ߺ��� ���� ó���Ѵ�
        _removedBlocks = _removedBlocks.Distinct().ToList();

        DownMoveBlocks();
    }

    private void DownMoveBlocks()
    {
        int moveCount = 0; //�ϰ��ؾ��� ĭ ���� ����
        
        for(int row = 0; row <Row; row++)
        {
            for (int col = Column-1; col >=0; col--)
            {
                //���� ����� ���� ���� ���
                if (_gameBoard[col, row] == null)
                {
                    moveCount++;
                }
                else //���Ӻ������ ���� �ִ� ���
                {
                    if (moveCount > 0)  //�ϰ����� üũ
                    {
                        Block block = _gameBoard[col, row].GetComponent<Block>();
                        block.MovePos = block.transform.position;
                        //�̵��� ��ġ���� ���
                        block.MovePos = new Vector3(block.MovePos.x, block.MovePos.y - block.Width * moveCount, block.MovePos.z);
                        //������ �ִ� ���Ӻ������ ��ġ�� �ʱ�ȭ
                        _gameBoard[col, row] = null;
                        //���Ӻ������ �̵��� ��ġ�� ����
                        block._column = block._column + moveCount;
                        //��� �̸��� �����Ѵ�
                        block.gameObject.name = $"Block[{block._column},{block._row}]";
                        //���Ӻ������ �̵��� ��ġ�� ���� ������ ����
                        _gameBoard[block._column, block._row] = block.gameObject;

                        block.Move(DIRECTION.DOWN, moveCount);


                    }
                }
            }
            moveCount = 0;
        }
    }
    /// <summary>
    /// ���Ӻ���� ������ ���� ������ ���ο� ������ ä��
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
        if (_removedBlocks.Count <= 0)
        {
            return null;
        }

        // ������ ���� ������ ����Ʈ���� ���� �ϳ� ������ �´�.
        GameObject obj = _removedBlocks[0];
        // ���� ���� ���� ���� ������ �ʱ�ȭ�Ѵ�.
        obj.GetComponent<Block>().Init(column, row, type, _sprites[type]);

        _removedBlocks.Remove(obj); // ������ ���� ������ �� ���� ����Ʈ���� ����ó��

        return obj;

    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0)&&_inputOK==true)
        {
            _mouseClick = true;

            Vector3 pos = Input.mousePosition;
            //Ŭ���� �Ǿ��� �� ��ġ�� �������� ���� ��ġ������ �ʱ�ȭ
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

        //���콺 Ŭ���� �Ŀ� Ŀ���� �̵���Ŵ
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
