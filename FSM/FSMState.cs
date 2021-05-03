using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FSMState : MonoBehaviour
{
    /// <summary>
    /// 이 스테이트에 진입했을 때 실행 되는 함수
    /// </summary>
    /// <param name="obj"></param>
    public abstract void OnEnter(GameObject obj = null);

    /// <summary>
    /// 이 스테이트가 되고 돌아야 할 반복문
    /// </summary>
    /// <param name="obj"></param>
    public abstract void OnExecute(GameObject obj = null);

    /// <summary>
    /// 이 스테이트가 빠져나올때 실행 되는 함수
    /// </summary>
    /// <param name="obj"></param>
    public abstract void OnExit(GameObject obj = null);
}
