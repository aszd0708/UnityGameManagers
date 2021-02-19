using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

public abstract class AchievementObserver : MonoBehaviour
{
    //public GooglePlayGameManager GPGM;

    public abstract void GetAcheivement();
}