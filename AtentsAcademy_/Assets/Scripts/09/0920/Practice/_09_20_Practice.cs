using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _09_20_Practice : MonoBehaviour
{
    /*
     사용할만한 정보의 코드를 가지고 있어야죠~~~!
    1. 마우스 왼쪽 버튼 누를 시 gpu Instancing 기능을 사용한 게임 오브젝트 생성
    2. 화명상에서 게임 오브젝트 선택 시 선택한 게임 오브젝트의 컬러를 검정으로 변경하는 프로그램 코드 작성

    문제의 핵심은 gpu instancing 기능을 사용하는 게임 오브젝트의 색상을 실행 중 변경
     */

    GameObject tmp;
    private void Awake()
    {
        
        tmp = Resources.Load<GameObject>("Sphere");
    }
    void Start()
    {
        
    }

    void Spawn()
    {
       GameObject createObj = GameObject.Instantiate<GameObject>(tmp);

        MaterialPropertyBlock props = new MaterialPropertyBlock();       //한번은 뉴 해야함(알고보니 안해도 댐;;)
        Renderer renderer = createObj.GetComponent<MeshRenderer>();     //그러나 컬러 변경할때 뉴 하지 말고 겟 한다음에 셋 하라고 함


        props.SetColor("_Color", new Color(1f, 1f, 1f));
        renderer.SetPropertyBlock(props);
        
        createObj.transform.position = new Vector3(Random.Range(0, 10),0, Random.Range(0, 10));
    }
    void ColorChange()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        if(Physics.Raycast(ray, out hitInfo, Mathf.Infinity))
        {
            MeshRenderer renderer = hitInfo.collider.gameObject.GetComponent<MeshRenderer>();
            if(renderer != null)
            {
                MaterialPropertyBlock tmpProps = new MaterialPropertyBlock();
                renderer.GetPropertyBlock(tmpProps);
                tmpProps.SetColor("_Color", new Color(0, 0, 0, 0.3f));
                renderer.SetPropertyBlock(tmpProps);
            }
        }
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Spawn();
        }
        if (Input.GetMouseButtonDown(0))
        {
            ColorChange();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject tmp = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        }
    }
}
