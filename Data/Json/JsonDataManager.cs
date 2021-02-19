using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

/// <summary>
/// 제이슨 데이터 갖고오는 클래스
/// </summary>
/// <typeparam name="T"></typeparam>
public class JsonDataManager<T> : MonoBehaviour
{
    [Header("제이슨 데이터")]
    public TextAsset jsonFile;

    private string jsonString;

    /// <summary>
    /// 제이슨 string으로 변경해주는 프로퍼티
    /// </summary>
    public string JsonString { get => jsonString; set => jsonString = value; }

    private List<T> jsonData;

    /// <summary>
    /// 제이슨 리스트로 갖고오는 프로퍼티
    /// </summary>
    public List<T> JsonData { get => jsonData; set => jsonData = value; }

    protected virtual void Awake()
    {
        SetJsonData();
    }


    /// <summary>
    ///  string으로 변환 후 리스트로 변환
    /// </summary>
    protected void SetJsonData()
    {
        ConvertJsonToString();
        SetJsonDataFromJsonString();
    }

    private void ConvertJsonToString()
    {
        JsonString = jsonFile.ToString();
    }

    private void SetJsonDataFromJsonString()
    {
        JsonData = JsonToOject<List<T>>(JsonString);
    }

    private T JsonToOject<T>(string value)
    {
        return JsonConvert.DeserializeObject<T>(value);
    }
}
