using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class ItemData
{
    private string itemName;
    private bool isCollect;

    /// <summary>
    /// 아이템 이름 string
    /// </summary>
    public string ItemName { get => itemName; set => itemName = value; }

    /// <summary>
    /// 이 아이템을 얻었냐
    /// </summary>
    public bool IsCollect { get => isCollect; set => isCollect = value; }

    public ItemData(string _itemName, bool _isCollect)
    {
        ItemName = _itemName;
        IsCollect = _isCollect;
    }

    public void PrintData()
    {
        Debug.Log("아이템");
        Debug.Log("이름 : " + ItemName);
        Debug.Log("수집 : " + IsCollect);
    }
}

public class ItemDataManager : SaveData<List<ItemData>>
{
    [Header("JsonCat.json 을 갖고있는 컴포넌트")]
    public AnimalJsonData animalJson;

    /// <summary>
    /// 디폴트 데이터 반환
    /// </summary>
    /// <returns></returns>

    public override void SetDefaultData()
    {
        Data = ReadItemData();
    }

    /// <summary>
    /// 제이슨 파일중에 none 이라는 아이템 빼고 읽는 함수
    /// </summary>
    /// <returns></returns>
    private List<ItemData> ReadItemData()
    {
        List<ItemData> loadData = new List<ItemData>();
        List<AnimalJson> jsonAnimalDatas = animalJson.JsonData;

        string noneString = "none";

        for (int i = 0; i < jsonAnimalDatas.Count; i++)
        {
            string itemName = jsonAnimalDatas[i].ItemName;
            if (!string.Equals(itemName, noneString))
            {
                ItemData data = new ItemData(itemName, false);
                loadData.Add(data);
            }
        }

        return loadData;
    }

    public override List<ItemData> EditData(string value)
    {
        for (int i = 0; i < Data.Count; i++)
        {
            if (string.Equals(value, Data[i].ItemName))
            {
                Data[i].IsCollect = true;
                break;
            }
        }
        return Data;
    }

    public override List<ItemData> EditData(int index)
    {
        Data[index].IsCollect = true;
        return Data;
    }
}
