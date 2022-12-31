using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

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

    void Start()
    {
        //스크린 0,0 좌표를 월드 공간상의 좌표값으로 변환 
        _screenPos = Camera.main.ScreenToWorldPoint(new Vector3(0f,0f,10f));
        Debug.Log("ScreenPos "+_screenPos);
        //3D 공간상의 중앙이 0.0 이라고 하면 
        //월드공간상의 좌하단은 -2.8, -5.0, 0.0
        //월드공간상의 좌상단은 -2.8, 5.0, 0.0
        //월드공간상의 우상단은 2.8,5,0
        //월드공간상의 우하단은 2.8 -5,0
        _screenPos.y = -_screenPos.y;
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


        MakeBoard(10,10);
    }

    void MakeBoard(int column, int row)
    {
        float width = _screenWidth - (_xMargin*2);  //출력되는 너비 ( 마진갑 없음)
        //블럭의 출력 너비값 = 블럭의 너비값 * 전체 개수
        float blockWidth = _blockWidth * row;
        //블럭의 넓이에서 스크린의 넓이를 나눠서 블럭의 사이즈를 조절할 수 있다
        _blockScale = width / blockWidth; //블럭의 스케일 값
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
                //blockObj.GetComponent<Block>().Width = _blockWidth; //블럭의 너비값을 블럭에 전달
                //blockObj.GetComponent<Block>().MovePos = blockObj.transform.position;   //생성위치값 저장
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
