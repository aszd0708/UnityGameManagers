using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/*
 * 2021-01-13
 * 한번 만들어보고 되면 하는거고 안되면 그냥 망하는거고
 * ㅅㅂ
 */

/// <summary>
/// 게임 데이터
/// PlayerData
/// AnimalData 리스트
/// ItemData 리스트
/// 사용
/// </summary>
[Serializable]
public class GameData
{
    private PlayerData player;
    private List<AnimalData> animals;
    private List<ItemData> items;
    private List<LetterData> letters;

    /// <summary>
    /// 플레이어 데이터 프로퍼티
    /// </summary>
    public PlayerData Player { get => player; set => player = value; }

    /// <summary>
    /// 동물 데이터 리스트
    /// </summary>
    public List<AnimalData> Animals { get => animals; set => animals = value; }

    /// <summary>
    /// 아이템 데이터 리스트
    /// </summary>
    public List<ItemData> Items { get => items; set => items = value; }

    /// <summary>
    /// 편지 데이터 리스트
    /// </summary>
    public List<LetterData> Letters { get => letters; set => letters = value; }


    /// <summary>
    /// 생성자 
    /// </summary>
    /// <param name="_palyer"></param>
    /// <param name="_animals"></param>
    /// <param name="_items"></param>
    public GameData(PlayerData _palyer, List<AnimalData> _animals, List<ItemData> _items, List<LetterData> _letters)
    {
        Player = _palyer;
        Animals = _animals;
        Items = _items;
        Letters = _letters;
    }

    /// <summary>
    /// 확인용 함수
    /// </summary>
    public void PrintDatas()
    {
        Player.Print();
        for (int i = 0; i < Animals.Count; i++)
            Animals[i].PrintData();
        for (int i = 0; i < Items.Count; i++)
            Items[i].PrintData();
        //for (int i = 0; i < Letters.Count; i++)
        //    Letters[i].LetterID;
    }
}

/// <summary>
/// 데이터를 관리 해주는 커맨더
/// 싱글톤 사용
/// </summary>
public class SaveDataManager : DataManager<GameData>
{
    [Header("각 데이터 매니저들")]
    public PlayerDataManager playerDataManager;
    public AnimalDataManager animalDataManager;
    public ItemDataManager itemDataManager;
    public LetterDataManager letterDataManager;

    /// <summary>
    /// 아이템 사전 아이템 수집했는지 검사할때 사용함
    /// 저장할때 수정 X 처음 불러올때만 수정함
    /// </summary>
    private Dictionary<string, bool> itemDiction = new Dictionary<string, bool>();
    public Dictionary<string, bool> ItemDiction { get => itemDiction; set => itemDiction = value; }

    /// <summary>
    /// 싱글톤 인스턴스
    /// </summary>
    public static SaveDataManager Instance;
    protected override void Awake()
    {
        Singleton();
        itemDiction = new Dictionary<string, bool>();

        base.Awake();
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

    public override GameData LoadData()
    {
        return LoadObjectDataFile();
    }

    /// <summary>
    /// 디폴트 데이터 설정
    /// </summary>
    /// <returns></returns>
    protected override GameData SetDefaultData()
    {
        playerDataManager.SetDefaultData();
        animalDataManager.SetDefaultData();
        itemDataManager.SetDefaultData();
        letterDataManager.SetDefaultData();

        PlayerData playerData = playerDataManager.Data;
        List<AnimalData> animalData = animalDataManager.Data;
        List<ItemData> itemData = itemDataManager.Data;
        List<LetterData> letterData = letterDataManager.Data;

        for (int i = 0; i < itemData.Count; i++)
            ItemDiction.Add(itemData[i].ItemName, itemData[i].IsCollect);

        return new GameData(playerData, animalData, itemData, letterData);
    }

    protected override void SetNowData()
    {
        playerDataManager.Data = Data.Player;
        animalDataManager.Data = Data.Animals;
        itemDataManager.Data = Data.Items;
        letterDataManager.Data = Data.Letters;

        for (int i = 0; i < Data.Items.Count; i++)
            ItemDiction.Add(Data.Items[i].ItemName, Data.Items[i].IsCollect);
    }

    protected override void SetDataName()
    {
        SaveDataName = "wjwkdepdlxj";
    }

    #region EditPlayerData
    /// <summary>
    /// 터치 카운트 바꾸고 저장
    /// </summary>
    /// <param name="value"></param>
    public void EditTouchCount(int value)
    {
        playerDataManager.EditTouchData(value);
        SavePlayerData(playerDataManager.Data);
    }

    /// <summary>
    /// 찬스 시간 저장
    /// </summary>
    /// <param name="value"></param>
    public void EditChanceTime(DateTime value)
    {
        playerDataManager.EdiTimetData(value);
        SavePlayerData(playerDataManager.Data);
    }

    /// <summary>
    /// 코인 갯수 저장
    /// </summary>
    /// <param name="value"></param>
    public void EditCoinCount(int value)
    {
        playerDataManager.EditCoinData(value);
        SavePlayerData(playerDataManager.Data);
    }

    /// <summary>
    /// 오픈 스테이지 저장
    /// </summary>
    /// <param name="value"></param>
    public void EditOpenStage(int value)
    {
        playerDataManager.EditOpenStageData(value);
        SavePlayerData(playerDataManager.Data);
    }

    /// <summary>
    /// 플레이어 데이터 저장
    /// </summary>
    /// <param name="_data"></param>
    private void SavePlayerData(PlayerData _data)
    {
        Data.Player = _data;
        SaveDataFile(Data);
    }
    #endregion

    #region EidtItemData
    public void EditItemCollect(int index)
    {
        itemDataManager.EditData(index);
        SaveItemData(itemDataManager.Data);
    }

    public void EditItemCollect(string itemName)
    {
        itemDataManager.EditData(itemName);
        SaveItemData(itemDataManager.Data);
    }
    private void SaveItemData(List<ItemData> _data)
    {
        Data.Items = _data;
        SaveDataFile(Data);
    }
    #endregion

    #region EidtAnimalData
    public void EditAnimalCollect(int index)
    {
        animalDataManager.EditData(index);
        SaveAnimalData(animalDataManager.Data);
    }

    public void EditAnimalCollect(string itemName)
    {
        animalDataManager.EditData(itemName);
        SaveAnimalData(animalDataManager.Data);
    }

    private void SaveAnimalData(List<AnimalData> _data)
    {
        Data.Animals = _data;
        SaveDataFile(Data);
    }

    #endregion

    #region EditLetterData
    public void EditLetterCollect(int letterID)
    {
        letterDataManager.EditData(letterID);
        SaveLetterData(letterDataManager.Data);
    }

    private void SaveLetterData(List<LetterData> _data)
    {
        Data.Letters = _data;
        SaveDataFile(Data);
    }
    #endregion
}
