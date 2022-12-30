using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _12_17_Tank : MonoBehaviour
{
    [SerializeField] private GameObject _canonBallPrefab;
    [SerializeField] private Transform _firePos;
    //유니티는 화면 안쪽 방향이 +z 방향이다. 따라서 z와 x 평면을 움직이게 한다
    private float _zPos = 0f;
    private float _xPos = 0f;
    private float _mSpeed = 10f;
    private float _rSpeed = 50f;
    void Start()
    {
        
    }

    void Update()
    {
        #region 캐논볼 생성코드
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //키를 누름 => 입력버퍼에 키의 정보가 저장됨 => 버퍼에 눌린 키가 있는지 확인함
            //스페이스가 눌리면 캐논볼 프리팹이 만들어짐
            GameObject cannonBall = Instantiate(_canonBallPrefab,_firePos.transform.position,_firePos.transform.rotation);
            cannonBall.transform.SetParent(_firePos.transform);
            /*
             게임오브젝트가 물리 영향을 받으려면 리지드바디 (강체) 가 있어야 한다
             리지드바디가 추가된 순간 물리의 영향을 받게 된다.
             
            질량
            움직일 때 공기의 영향을 받는 정도
            회전할 때 공기의 영향을 받는 정도
            중력

            제약사항
            물리 영향을 받았을 때 어느 위치를 고정시킬건지

            물리의 영향을 받아서 처리하려면? 캐논 볼에 있는 리지드바디를 가져온다

             */

            cannonBall.GetComponent<Rigidbody>().AddForce(_firePos.transform.forward * 1200f, ForceMode.Force);
            //리지드 바디 안의 에드포스 ( 물체에 힘을 주는 함수 ) 사용 ( 어느쪽 방향으로, 얼만큼 줄 건지, 힘의 옵션을 준다) 
            // ForceMode.Force : 지속적인 힘
            // ForceMode.Acceleration : 계속적인 가속을 더하고 질량은 무시
            // ForceMode.Impulse : 질량을 이용해서 충격력을 더한다
            // ForceMode.VelocityChange : 속도를 더하며 질량은 무시한다

            //캐논볼에 붙어있는 애드포스를 이용해서 포탄이 날아가게 함 ( 물리영향 + 중력의영향 = 포물선운동)
        }
        #endregion
        //키보드 입력 + 이동코드 함수 호출 (키를 계속 누르고 있을 때)
        GetKey();
        //키 입력 후에 키 입력값을 기준으로
        //transform.Translate(new Vector3(_xPos, 0f, _zPos).normalized * 0.04f);
        //이동 후에 초기화 시켜준다
        _xPos = 0f;
        _zPos = 0f;

        //============
        GetKeyDown(); //키가 한 번 눌렸을때만 처리
        GetKeyUp(); //키가 눌리고 뗄 때 처리
        //=============================================
        GetAxis();
    }

    #region GetKeyDown()
    void GetKeyDown()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            _zPos += 0.5f;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            _zPos -= 0.5f;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _xPos -= 0.5f;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            _xPos += 0.5f;
        }
    }
    #endregion

    #region GetKeyUp()
    void GetKeyUp()
    {
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            _zPos += 0.5f;
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            _zPos -= 0.5f;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            _xPos -= 0.5f;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            _xPos += 0.5f;
        }
    }
    #endregion

    #region GetKey()
    void GetKey()
    {
        //GetKey : Key가 눌렸을 떄
        if (Input.GetKey(KeyCode.UpArrow))
        {
            _zPos += 0.5f;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            _zPos -= 0.5f;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _xPos -= 0.5f;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            _xPos += 0.5f;
        }
    }
    #endregion

    #region GetKey()
    void GetAxis()
    {
        float moveSpeed = _mSpeed * Time.deltaTime;   //어느 시스템에서나 동일한 움직임을 보이게 하기 위해서
        float rotSpeed = _rSpeed * Time.deltaTime;
        float vertical = Input.GetAxis("Vertical"); //-1~1 사이의 변화량이 들어온다
        float horizontal = Input.GetAxis("Horizontal"); //-1~1 사이의 변화량이 들어온다
        //키를 누르면 최소 -1 부터 최대 1 사이의 변화량을 전달한다 (아무것도 안하면 0임)

        // 키보드를 눌러서 변화한 변화량을 전진과 후진값으로 사용한다
        transform.Translate(Vector3.forward * vertical * moveSpeed);

        //y축을 기준으로 회전하기 때문에 up vector를 기준으로 회전시킨다
        transform.Rotate(Vector3.up * horizontal * rotSpeed);
    }
    #endregion
}
