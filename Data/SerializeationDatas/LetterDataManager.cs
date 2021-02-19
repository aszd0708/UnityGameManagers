using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// 편지 데이터 세이브 클래스
/// </summary>
[Serializable]
public class LetterData
{
    private int letterID;
    private bool isCollect;

    /// <summary>
    /// 편지 인덱스값 (Ditionary에 사용할듯)
    /// </summary>
    public int LetterID { get => letterID; set => letterID = value; }

    /// <summary>
    /// 이 편지가 수집 됐나 확인하는 부울값
    /// </summary>
    public bool IsCollect { get => isCollect; set => isCollect = value; }

    /// <summary>
    /// 생성자
    /// </summary>
    /// <param name="_letterID">편지 ID</param>
    /// <param name="_isCollect">수집 상태인지</param>
    public LetterData(int _letterID, bool _isCollect)
    {
        LetterID = _letterID;
        IsCollect = _isCollect;
    }
}

public class LetterDataManager : SaveData<List<LetterData>>
{
    [SerializeField]
    [Header("편지 Json")]
    private LetterJsonData letterJsonData;

    private Dictionary<int, LetterData> dataDiction = new Dictionary<int, LetterData>();

    public Dictionary<int, LetterData> DataDiction { get => dataDiction; set => dataDiction = value; }

    private void Start()
    {
        SetDiction();
    }


    /// <summary>
    /// 제이슨 데이터 읽는 함수
    /// </summary>
    /// <returns></returns>
    private List<LetterData> ReadJsonData()
    {
        List<LetterData> readData = new List<LetterData>();
        for(int i = 0; i < letterJsonData.JsonData.Count; i++)
            readData.Add(new LetterData(letterJsonData.JsonData[i].Id, false));
        return readData;
    }

    /// <summary>
    /// 사용할일 없지만 만약 사용한다면 int형 으로 바꿔서 다시 넣어줌
    /// 제발 사용하지 말아주세요
    /// </summary>
    /// <param name="value">편지 id(string 형)</param>
    /// <returns></returns>
    public override List<LetterData> EditData(string value)
    {
        return EditData(System.Convert.ToInt32(value));
    }

    /// <summary>
    /// 이건 인덱스가 아닌 id로 검색
    /// </summary>
    /// <param name="index">원하는 편지 ID</param>
    /// <returns></returns>
    public override List<LetterData> EditData(int index)
    {
        for (int i = 0; i < Data.Count; i++)
        {
            if (Data[i].LetterID == index)
            {
                Data[i].IsCollect = true;
                break;
            }
        }

        return Data;
    }

    public override void SetDefaultData()
    {
        Data = ReadJsonData();
    }

    /// <summary>
    /// Diction 설정
    /// </summary>
    public void SetDiction()
    {
        for(int i = 0; i < Data.Count; i++)
        {
            DataDiction.Add(Data[i].LetterID, Data[i]);
        }
    }
}
