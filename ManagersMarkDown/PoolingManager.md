### PoolingManager
SetPool 을 사용해서 오브젝트를 SetActive(false)를 시킨 다음 SetPool에 있던 PoolingName 으로 새로운 카테고리를 만들어 넣어줌 만약 카테고리가 있을경우 그 카테고리로 넣어줌
그리고 GetPool을 사용해서 원하는 카테고리에 있는 오브젝트를 가져올 수 있음 만약 없을경우 null을 반환
사용시 받아올때 null을 받을 경우 null을 체크 한 뒤 원하는 오브젝트 생성해서 사용

#### SetPool
```
public void SetPool(GameObject setPoolObj, string typeName)
    {
        setPoolObj.transform.SetParent(CheckPoolType(typeName));
        setPoolObj.SetActive(false);
    }
```
SetPooling 을 사용하여 풀링 타입 검사 후 없으면 타입을 만들고 있으면 그 타입에 자식으로 만들어 넣음

```
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
```
뒤에 시간을 넣으면 그 시간 뒤에 풀링을 시켜줌

#### GetPool
```
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
```
풀링 타입을 입력하면 맨 위에 있는 오브젝트를 꺼내줌