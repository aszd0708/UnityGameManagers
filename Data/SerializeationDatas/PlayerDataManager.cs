using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

/// <summary>
/// 터치카운트 기회 충전 타임
/// 코인 카운트 오픈스테이지 사용
/// </summary>
[Serializable]
public class PlayerData
{
    private int touchCount;
    private long chanceTime;
    private int coinCount;
    private int openStage;

    /// <summary>
    /// 터치 남은 횟수 프로퍼티
    /// </summary>
    public int TouchCount { get => touchCount; set => touchCount = value; }

    /// <summary>
    /// 찬스 타임 (마지막으로 받은 시간) 프로퍼티
    /// </summary>
    public long ChanceTime { get => chanceTime; set => chanceTime = value; }

    /// <summary>
    /// 남은 코인 카운트 프로퍼티
    /// </summary>
    public int CoinCount { get => coinCount; set => coinCount = value; }

    /// <summary>
    /// 오픈 스테이지 프로퍼티
    /// 뽑기방도 스테이지로 취급
    /// 튜토리얼이 1로 취급
    /// </summary>
    public int OpenStage { get => openStage; set => openStage = value; }

    public PlayerData(int _touchCount, DateTime _chanceTime, int _coinCount, int _openStage)
    {
        TouchCount = _touchCount;

        ChanceTime = _chanceTime.Ticks;
        CoinCount = _coinCount;
        OpenStage = _openStage;
    }

    public void Print()
    {
        Debug.Log("플레이어");
        Debug.Log("남은 터치 카운트 : "+ TouchCount);
        Debug.Log("남은 시간 : " + ChanceTime);
        Debug.Log("남은 코인 : " + CoinCount);
        Debug.Log("오픈 스테이지 " + OpenStage);
    }
}

public class PlayerDataManager : SaveData<PlayerData>
{
    /// <summary>
    /// 터치 카운트 수정 후 저장
    /// </summary>
    /// <param name="value"></param>
    public PlayerData EditTouchData(int value)
    {
        Data.TouchCount = value;
        return Data;
    }

    /// <summary>
    /// 찬스 시간 수정 후 저장
    /// </summary>
    /// <param name="value"></param>
    public PlayerData EdiTimetData(DateTime value)
    {
        Data.ChanceTime = value.Ticks;
        return Data;
    }

    /// <summary>
    /// 동전 카운트 수정 후 저장
    /// </summary>
    /// <param name="value"></param>
    public PlayerData EditCoinData(int value)
    {
        Data.CoinCount = value;
        return Data;
    }

    public PlayerData EditOpenStageData(int value)
    {
        Data.OpenStage = value;
        return Data;
    }

    public override void SetDefaultData()
    {
        Data = new PlayerData(40, new DateTime(1995, 11, 10, 18, 00, 00), 2, 2);
    }

    /// <summary>
    /// 여기있는 EditData는 안쓸 예정 다른 세부적으로 나눈 코드가 있기 때문
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public override PlayerData EditData(string value)
    {
        return Data;
    }

    /// <summary>
    /// 여기있는 EditData는 안쓸 예정 다른 세부적으로 나눈 코드가 있기 때문
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public override PlayerData EditData(int index)
    {
        return Data;
    }
}
