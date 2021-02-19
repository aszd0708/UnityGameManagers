using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class AnimalData
{
    string animalName;
    bool isCollect;


    /// <summary>
    /// 동물 이름 프로퍼티
    /// </summary>
    public string AnimalName { get => animalName; set => animalName = value; }

    /// <summary>
    /// 수집 했는지에 따른 프로퍼티
    /// </summary>
    public bool IsCollect { get => isCollect; set => isCollect = value; }

    /// <summary>
    /// 클래스 생성자
    /// </summary>
    /// <param name="_animalName"></param>
    /// <param name="_isCollect"></param>
    public AnimalData(string _animalName, bool _isCollect)
    {
        AnimalName = _animalName;
        IsCollect = _isCollect;
    }

    public void PrintData()
    {
        Debug.Log("동물");
        Debug.Log("이름 : " + AnimalName);
        Debug.Log("수집 : " + IsCollect);
    }
}

public class AnimalDataManager : SaveData<List<AnimalData>>
{
    [Header("JsonCat.json 을 갖고있는 컴포넌트")]
    public AnimalJsonData animalJson;

    /// <summary>
    /// 제이슨에서 데이터 불러온뒤 디폴트로 놔둠
    /// </summary>
    /// <returns></returns>
    public override void SetDefaultData()
    {
        Data = ReadAnimalData();
    }
    
    /// <summary>
    /// 제이슨에서 읽어오는 함수
    /// </summary>
    /// <returns></returns>
    private List<AnimalData> ReadAnimalData()
    {
        List<AnimalData> loadData = new List<AnimalData>();
        List<AnimalJson> jsonAnimalDatas = animalJson.JsonData;

        for (int i = 0; i < jsonAnimalDatas.Count; i++)
        {
            AnimalData data = new AnimalData(jsonAnimalDatas[i].CatPath, false);
            loadData.Add(data);
        }

        return loadData;
    }

    public override List<AnimalData> EditData(string value)
    {
        for (int i = 0; i < Data.Count; i++)
        {
            if (string.Equals(value, Data[i].AnimalName))
            {
                Data[i].IsCollect = true;
                break;
            }
        }

        return Data;
    }

    public override List<AnimalData> EditData(int index)
    {
        Data[index].IsCollect = true;
        return Data;
    }
}
