using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FSMState : MonoBehaviour
{
    /// <summary>
    /// �� ������Ʈ�� �������� �� ���� �Ǵ� �Լ�
    /// </summary>
    /// <param name="obj"></param>
    public abstract void OnEnter(GameObject obj = null);

    /// <summary>
    /// �� ������Ʈ�� �ǰ� ���ƾ� �� �ݺ���
    /// </summary>
    /// <param name="obj"></param>
    public abstract void OnExecute(GameObject obj = null);

    /// <summary>
    /// �� ������Ʈ�� �������ö� ���� �Ǵ� �Լ�
    /// </summary>
    /// <param name="obj"></param>
    public abstract void OnExit(GameObject obj = null);
}
