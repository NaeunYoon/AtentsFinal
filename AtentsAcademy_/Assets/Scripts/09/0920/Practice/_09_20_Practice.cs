using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _09_20_Practice : MonoBehaviour
{
    /*
     ����Ҹ��� ������ �ڵ带 ������ �־����~~~!
    1. ���콺 ���� ��ư ���� �� gpu Instancing ����� ����� ���� ������Ʈ ����
    2. ȭ��󿡼� ���� ������Ʈ ���� �� ������ ���� ������Ʈ�� �÷��� �������� �����ϴ� ���α׷� �ڵ� �ۼ�

    ������ �ٽ��� gpu instancing ����� ����ϴ� ���� ������Ʈ�� ������ ���� �� ����
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

        MaterialPropertyBlock props = new MaterialPropertyBlock();       //�ѹ��� �� �ؾ���(�˰��� ���ص� ��;;)
        Renderer renderer = createObj.GetComponent<MeshRenderer>();     //�׷��� �÷� �����Ҷ� �� ���� ���� �� �Ѵ����� �� �϶�� ��


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
