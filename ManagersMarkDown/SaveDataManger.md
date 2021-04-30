### SaveManager

```
public abstract class SaveData<T> : MonoBehaviour
{
    
    private T data;

    /// <summary>
    /// 제네릭 자료형 데이터 프로퍼티
    /// </summary>
    public T Data { get => data; set => data = value; }

    /// <summary>
    /// 데이터 디폴트값으로 설정하는 함수
    /// </summary>
    public abstract void SetDefaultData();

    /// <summary>
    /// 이름으로 검색 후 수정
    /// 그런뒤 그 데이터 반환
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public abstract T EditData(string value);

    /// <summary>
    /// 인덱스로 검색 후 수정
    /// 그런뒤 그 데이터 반환
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public abstract T EditData(int index);
}
```
각각 DefaultData를 만들어 세이브 데이터가 없을때 호출 합니다.

```
public class SaveDataManager : DataManager<GameData>
{
    [Header("각 데이터 매니저들")]
    public PlayerDataManager playerDataManager;
    public AnimalDataManager animalDataManager;
    public ItemDataManager itemDataManager;
    public LetterDataManager letterDataManager;
    '
    '
    '
}
```
원하는 데이터들을 만들어 새로운 데이터 클래스를 제네릭으로 받고 상속하여 사용 합니다.

Letter,Player,Item,Animal은 직접 사용했습니다.

이렇게 사용하게 되면 여러가지 데이터들을 한번에 묶어서 파일을 저장할 수 있게 되어 관리하기 편해집니다.
