using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPGSSubject : AchievementSubject
{
    public override void AddObserver(AchievementObserver observer)
    {
        observers.Add(observer);
    }
    public override void RemoveObserver(AchievementObserver observer)
    {
        observers.Remove(observer);
    }

    // 일단 어캐할지 몰라서
    // 어플 시작, 겜 오버, 광고 이 3개에만 호출 했음.
    // 만약 어캐될지 모르니까 나중에 코루틴으로 계속해서 돌리는것도 생각해봄
    public override void Notify()
    {
        //Debug.Log("옵저버 실행");
        for (int i = 0; i < observers.Count; i++)
        {
            observers[i].GetAcheivement();
        }
    }
}
