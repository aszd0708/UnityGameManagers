using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// 편지 제이슨 클래스
/// </summary>
[Serializable]
public class LetterJson
{
    public int Id;
    public string Title;
    public string SubTitle;
    public int StageNo;
    public string Text;

    /// <summary>
    /// 생성자
    /// </summary>
    /// <param name="_Id">편지의 Id</param>
    /// <param name="_Title">편지의 제목</param>
    /// <param name="_SubTitle">편지의 소제목(없으면 빈공간)</param>
    /// <param name="_StageNo">어떤 스테이지에 등장하는지</param>
    /// <param name="_Text">편지의 내용</param>
    public LetterJson(int _Id, string _Title, string _SubTitle, int _StageNo, string _Text)
    {
        Id = _Id;
        Title = _Title;
        SubTitle = _SubTitle;
        StageNo = _StageNo;
        Text = _Text;
    }
}

/// <summary>
/// 예외적으로 LetterJson만 싱글톤으로 작성
/// </summary>
public class LetterJsonData : JsonDataManager<LetterJson>
{
    private Dictionary<int, LetterJson> dataDiction = new Dictionary<int, LetterJson>();

    /// <summary>
    /// 제이슨 데이터 id로 찾을수 있게 만든 dictionary
    /// </summary>
    public Dictionary<int, LetterJson> DataDiction { get => dataDiction; set => dataDiction = value; }

    /// <summary>
    /// 싱글톤 인스턴스
    /// </summary>
    public static LetterJsonData Instance;
    protected override void Awake()
    {
        Singleton();
        base.Awake();

    }

    protected void OnEnable()
    {
        SetDictionary();
    }

    #region Singleton
    private void Singleton()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    protected virtual void OnDestroy()
    {
        //유일한 Instance가 자신이면, Instance값을 비워줌 (다른 인스턴스가 들어갈 수 있도록)
        if (Instance == this)
            Instance = null;
    }
    #endregion

    /// <summary>
    /// Dictionary 세팅
    /// </summary>
    private void SetDictionary()
    {
        for (int i = 0; i < JsonData.Count; i++)
            DataDiction.Add(JsonData[i].Id, JsonData[i]);
    }
}
