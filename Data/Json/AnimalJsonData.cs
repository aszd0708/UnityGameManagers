using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class AnimalJson
{
    public int No;
    public string Name;
    public string ItemName;
    public string CatPath;

    public AnimalJson(int _no, string _name, string _itemName, string _catPath)
    {
        No = _no;
        Name = _name;
        ItemName = _itemName;
        CatPath = _catPath;
    }

    /// <summary>
    /// 확인용 나중에 지울거임
    /// </summary>
    public void Print()
    {
        Debug.Log("번호 : " + No + " 이름: " + Name  + " 아이템 이름 : " + ItemName);
    }
}

/// <summary>
/// 딱히 쓸게 없음 ㄹㅇ ㅋㅋ
/// 쓸게 생기면 추가함
/// </summary>
public class AnimalJsonData : JsonDataManager<AnimalJson>
{
   
}
