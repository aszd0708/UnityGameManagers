using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 풀링할때 부모 이름 정해주는 클래스
 * Virtual 클래스로 사용하여 각 스크립트마다 오타나 다른것이 검출되지 않도록 하는 클래스
 * 생각보다 필요 없을듯 하다
 * 생산과 삭제가 다른곳에서 일어나는 경우가 많아서 필요 없음
 */

interface IPoolingObject
{
    string PoolingName { get; set; }
}

/*
 * 2020-02-07
 * pooledManager
 * 내가 생각하는 그 pool
 * 삭제 될때 이 쪽으로 보내고
 * 다시 생성할 때는 이쪽에서 갖고와서 사용하는것
 * 가비지 콜렉터를 피하기 위한 최적화
 */

public class PoolingManager : Singleton<PoolingManager>
{
    [SerializeField]
    [Header("풀링 한 오브젝트가 모일 부모 없으면 이 오브젝트가 부모가 됨")]
    private Transform pooledParent;

    private GameObject emptyObj = null;
    private List<Transform> typeParent = new List<Transform>();

    private void Start()
    {
        if (!pooledParent)
            pooledParent = transform;
    }

    // 오브젝트를 풀링하는 함수
    public void SetPool(GameObject setPoolObj, string typeName)
    {
        setPoolObj.transform.SetParent(CheckPoolType(typeName));
        setPoolObj.SetActive(false);
    }

    // 밑에 코루틴과 같이 사용 일정 시간 후에 풀링 하는 함수
    public void SetPool(GameObject setPoolObj, string typeName, float time)
    {
        StartCoroutine(SetPoolingDelay(setPoolObj, typeName, time));
    }

    private IEnumerator SetPoolingDelay(GameObject setPoolObj, string typeName, float time)
    {
        yield return new WaitForSeconds(time);
        SetPool(setPoolObj, typeName);
        yield break;
    }

    // 풀링되었던 오브젝트를 갖고오는 함수
    public GameObject GetPoolRandom(string typeName, Transform parent = null)
    {
        GameObject getPoolObj;

        Transform pooledTypeParent = CheckGetPoolType(typeName);

        if (pooledTypeParent == null)
        {
            return null;
        }

        //Debug.Log("받은 타입 이름 : " + pooledTypeParent);

        int random = Random.Range(0, pooledTypeParent.childCount);

        getPoolObj = pooledTypeParent.GetChild(random).gameObject;
        getPoolObj.SetActive(true);
        getPoolObj.transform.SetParent(parent);
        getPoolObj.transform.localPosition = Vector3.zero;

        return getPoolObj;
    }

    // 랜덤이 아닌 첫번째 오브젝트를 갖고오는 함수
    public GameObject GetPool(string typeName, Transform parent = null)
    {
        GameObject getPoolObj;

        Transform pooledTypeParent = CheckGetPoolType(typeName);

        if (pooledTypeParent == null)
            return null;

        else if (pooledTypeParent.childCount <= 2)
            return null;

        getPoolObj = pooledTypeParent.GetChild(0).gameObject;
        getPoolObj.SetActive(true);
        getPoolObj.transform.SetParent(parent);
        getPoolObj.transform.localPosition = Vector3.zero;

        return getPoolObj;
    }

    // 받은 타입값을 비교해서 있으면 그 타입을 반환하고 없으면 만들어서 반환
    private Transform CheckPoolType(string typeName)
    {
        for (int i = 0; i < typeParent.Count; i++)
            if (typeParent[i].name == typeName)
                return typeParent[i];

        return SetPoolParent(typeName);
    }


    // 받은 타입값을 비교해서 있으면 갖고오고 없으면 널값 반환
    private Transform CheckGetPoolType(string typeName)
    {
        for (int i = 0; i < typeParent.Count; i++)
            if (typeParent[i].name == typeName)
                return typeParent[i];

        return null;
    }

    // 풀드 할때 타입을 만들어서 상속시킨 뒤 반환해주는 함수
    private Transform SetPoolParent(string typeName)
    {
        if (emptyObj == null)
            emptyObj = new GameObject("EmptyObj Delete Soon");

        GameObject type = Instantiate(emptyObj, pooledParent);
        type.name = typeName;
        //Debug.Log("타입 : " + type.name);
        type.transform.position = Vector3.zero;
        typeParent.Add(type.transform);

        return type.transform;
    }
}
