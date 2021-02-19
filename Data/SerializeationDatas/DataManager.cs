using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public abstract class DataManager<T> : SerializableManager<T>
{
    private string path;
    /// <summary>
    /// 경로값 바꾸고 싶으면 바꿔도 괜찮은데 그래도 고정값 사용할듯
    /// </summary>
    protected string Path { get => path; set => path = value; }


    private string key;
    /// <summary>
    /// 키값 바꾸고 싶으면 바꿔도 괜찮 다만 고정값 추천
    /// </summary>
    protected string Key { get => key; set => key = value; }

    private T data;
    /// <summary>
    /// 데이터 리스트 원하는 데이터 넣으면 댐
    /// </summary>
    public T Data { get => data; set => data = value; }
    protected virtual void Awake()
    {
        SetAdressAndKey();

        SetDataName();

        if (!CheckHaveData())
        {
            Data = SetDefaultData();
            CreateDataFile(Data);
        }

        else
        {
            Data = LoadData();
            SetNowData();
        }
    }

    /// <summary>
    /// Data에 있는 값들 저장하는 함수
    /// </summary>
    public void SaveData()
    {
        SaveDataFile(Data);
    }

    public abstract T LoadData();

    protected void CreateDataFile(T defaultData)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Path + "/" + SaveDataName + ".dat");

        T saveData = defaultData;

        bf.Serialize(file, saveData);
        file.Close();
    }

    protected abstract T SetDefaultData();

    protected abstract void SetNowData();

    private void SetAdressAndKey()
    {
        Path = Application.persistentDataPath;
        Key = "rmeodhkcnacnsmsqka";
    }

    /// <summary>
    /// 데이터 파일 이름 설정
    /// </summary>
    protected abstract void SetDataName();
}
