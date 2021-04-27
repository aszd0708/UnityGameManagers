### ObserverPatternClass 
```
public abstract class AchievementSubject : Singleton<AchievementSubject>
{
    [SerializeField]
    protected List<AchievementObserver> observers = new List<AchievementObserver>();

    /// <summary>
    /// 옵저버 더하는 함수
    /// </summary>
    public abstract void AddObserver(AchievementObserver observer);

    /// <summary>
    /// 옵저버 제거하는 함수
    /// </summary>
    public abstract void RemoveObserver(AchievementObserver observer);

    /// <summary>
    /// 옵저버 검사 후 실행
    /// </summary>
    public abstract void Notify();
}
```
옵저버는 AchievementObserver를 조건 달성은 AchievementSubject을 상속해서 사용

```
public abstract class AchievementObserver : MonoBehaviour
{
    //public GooglePlayGameManager GPGM;

    public abstract void GetAcheivement();
}
```
특정한 조건에 옵저버들을 감시해야 할 사항이 생기면 AchievementSubject의 Notify()를 실행시키면 옵저버들의 조건을 검사 한 뒤 그 옵저버의 조건 달성 이벤트를 실행시켜줌