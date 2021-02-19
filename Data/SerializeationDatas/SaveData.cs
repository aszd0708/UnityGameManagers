using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 데이터 클래스
/// 데이터 디폴트값 저장 및 데이터 수정을 하는 클래스
/// 상속하여 사용하는걸로
/// PlayerData는 별개로 제작
/// </summary>
/// <typeparam name="T"></typeparam>
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
