using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _12_17_Tank : MonoBehaviour
{
    [SerializeField] private GameObject _canonBallPrefab;
    [SerializeField] private Transform _firePos;
    //����Ƽ�� ȭ�� ���� ������ +z �����̴�. ���� z�� x ����� �����̰� �Ѵ�
    private float _zPos = 0f;
    private float _xPos = 0f;
    private float _mSpeed = 10f;
    private float _rSpeed = 50f;
    void Start()
    {
        
    }

    void Update()
    {
        #region ĳ�� �����ڵ�
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Ű�� ���� => �Է¹��ۿ� Ű�� ������ ����� => ���ۿ� ���� Ű�� �ִ��� Ȯ����
            //�����̽��� ������ ĳ�� �������� �������
            GameObject cannonBall = Instantiate(_canonBallPrefab,_firePos.transform.position,_firePos.transform.rotation);
            cannonBall.transform.SetParent(_firePos.transform);
            /*
             ���ӿ�����Ʈ�� ���� ������ �������� ������ٵ� (��ü) �� �־�� �Ѵ�
             ������ٵ� �߰��� ���� ������ ������ �ް� �ȴ�.
             
            ����
            ������ �� ������ ������ �޴� ����
            ȸ���� �� ������ ������ �޴� ����
            �߷�

            �������
            ���� ������ �޾��� �� ��� ��ġ�� ������ų����

            ������ ������ �޾Ƽ� ó���Ϸ���? ĳ�� ���� �ִ� ������ٵ� �����´�

             */

            cannonBall.GetComponent<Rigidbody>().AddForce(_firePos.transform.forward * 1200f, ForceMode.Force);
            //������ �ٵ� ���� �������� ( ��ü�� ���� �ִ� �Լ� ) ��� ( ����� ��������, ��ŭ �� ����, ���� �ɼ��� �ش�) 
            // ForceMode.Force : �������� ��
            // ForceMode.Acceleration : ������� ������ ���ϰ� ������ ����
            // ForceMode.Impulse : ������ �̿��ؼ� ��ݷ��� ���Ѵ�
            // ForceMode.VelocityChange : �ӵ��� ���ϸ� ������ �����Ѵ�

            //ĳ���� �پ��ִ� �ֵ������� �̿��ؼ� ��ź�� ���ư��� �� ( �������� + �߷��ǿ��� = �������)
        }
        #endregion
        //Ű���� �Է� + �̵��ڵ� �Լ� ȣ�� (Ű�� ��� ������ ���� ��)
        GetKey();
        //Ű �Է� �Ŀ� Ű �Է°��� ��������
        //transform.Translate(new Vector3(_xPos, 0f, _zPos).normalized * 0.04f);
        //�̵� �Ŀ� �ʱ�ȭ �����ش�
        _xPos = 0f;
        _zPos = 0f;

        //============
        GetKeyDown(); //Ű�� �� �� ���������� ó��
        GetKeyUp(); //Ű�� ������ �� �� ó��
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
        //GetKey : Key�� ������ ��
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
        float moveSpeed = _mSpeed * Time.deltaTime;   //��� �ý��ۿ����� ������ �������� ���̰� �ϱ� ���ؼ�
        float rotSpeed = _rSpeed * Time.deltaTime;
        float vertical = Input.GetAxis("Vertical"); //-1~1 ������ ��ȭ���� ���´�
        float horizontal = Input.GetAxis("Horizontal"); //-1~1 ������ ��ȭ���� ���´�
        //Ű�� ������ �ּ� -1 ���� �ִ� 1 ������ ��ȭ���� �����Ѵ� (�ƹ��͵� ���ϸ� 0��)

        // Ű���带 ������ ��ȭ�� ��ȭ���� ������ ���������� ����Ѵ�
        transform.Translate(Vector3.forward * vertical * moveSpeed);

        //y���� �������� ȸ���ϱ� ������ up vector�� �������� ȸ����Ų��
        transform.Rotate(Vector3.up * horizontal * rotSpeed);
    }
    #endregion
}
