using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingAlpha : MonoBehaviour
{   //리스트 두 개 선언
    List<GameObject> Alphalist = new List<GameObject>(); //알파가 적용된 리스트
    List<GameObject> Recoverlist = new List<GameObject>();  //알파가 적용된 리스트에서 원래대로 복원해야하는 리스트
    public GameObject player;
    void Start()
    {

    }
    // obj가 알파리스트에 포함되어 있는지 검사
    public GameObject FindAlphalist(GameObject obj)
    {
        GameObject findObj = Alphalist.Find(o => (o.name == obj.name));
        return findObj;
    }
    public void AddAlplalist(GameObject obj)
    {
        GameObject alphaObj = FindAlphalist(obj);
        if (alphaObj == null)
        {
            Alphalist.Add(obj);
            Color col = obj.GetComponent<MeshRenderer>().material.color;
            col.a = 0.2f;
            obj.GetComponent<MeshRenderer>().material.color = col;
        }
    }
    private void LateUpdate()
    {
        Vector3 origin = Camera.main.transform.position;    //카메라에서 캐릭터를 향해 레이를 발사함
        Vector3 dir = player.transform.position - Camera.main.transform.position;
        RaycastHit[] hits = Physics.RaycastAll(origin, dir.normalized); //배열에 저장된다
        if (hits.Length == 0)       //아무것도 충돌이 없는 상태에서 알파를 원위치로 돌려 놓는다
                                    //(카메라가 아무것도 가리고 있지 않은 상태)
                                    
        {
            for (int i = 0; i < Alphalist.Count; i++)
            {
                Color col = Alphalist[i].GetComponent<MeshRenderer>().material.color;
                col.a = 1f;         //원본컬러 복원
                Alphalist[i].GetComponent<MeshRenderer>().material.color = col;
            }
            Alphalist.Clear();
            return;//원래대로 복원해주고 리턴해준다
        }
        // 광선과 충돌한 게임오브젝트 전체를 리스트에 저장 (알파값을 변경)
        for (int i = 0; i < hits.Length; i++)
        {
            AddAlplalist(hits[i].collider.gameObject);  //알파값을 변경한 게임 오브젝트들을 저장
        }
        // 복원구현
        // 알파리스트에서 빠져나간 경우

        //이중루프를 돌려서 레이캐스트에 의해 충돌한 오브젝트의 배열이 있고, 리스트에 저장
        //알파 리스트에 있는 게임 오브젝트를 비교해서 같지 않은 것만 찾음
        //이전 리스트에 남아있다는 의미는, 충돌이 되지 않은 상태이기 때문에 복원한다
        for (int i = 0; i < Alphalist.Count; i++)
        {
            GameObject tmp = null;
            for (int j = 0; j < hits.Length; j++)
            {
                try
                {
                    if (Alphalist[i].name == hits[j].collider.gameObject.name)
                    {
                        tmp = hits[j].collider.gameObject;
                    }
                }//알파리스트에서 빠져나간 것 발견
                catch (System.IndexOutOfRangeException )
                {
                    Debug.Log("i index = " + i);
                    Debug.Log("j index = " + j);
                }
            }

            if (tmp == null)
            {
                GameObject recoverObj = Recoverlist.Find(o => (o.name == Alphalist[i].name));   //Recoverlist에 저장
                if (recoverObj != null)
                    continue;

                Color col = Alphalist[i].GetComponent<MeshRenderer>().material.color;
                col.a = 1f;
                Alphalist[i].GetComponent<MeshRenderer>().material.color = col;
                //                Alphalist.Remove(Alphalist[i]);
                //                break;
                Recoverlist.Add(Alphalist[i]);
            }
        }
        // Recoverlist에 있는 오브젝트를 Alphalist에서 제거
        int size = Recoverlist.Count;
        for (int i = 0; i < size; i++)
        {
            try
            {
                GameObject findObj = Alphalist.Find(o => (o.name == Recoverlist[i].name));
                if (findObj != null)
                {
                    Alphalist.Remove(findObj);
                }
            }
            catch (System.ArgumentOutOfRangeException )
            {
                Debug.Log("i index = " + i);
            }
        }
        Recoverlist.Clear();
    }
}

