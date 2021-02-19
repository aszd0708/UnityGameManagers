using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 동물 설명에 대한 클래스
/// </summary>
[Serializable]
public class AnimalEx
{
    public int No;
    public string Name;
    public string Charactor;
    public string Favorite;
    public string Hint;
    public string Story;
    public string Tip;
    public string Instargram;
    public string HashTag;

    public AnimalEx(int no, string name, string charactor, string favorite, string hint, string story, string tip, string instargram, string hashTag)
    {
        No = no;
        Name = name;
        Charactor = charactor;
        Favorite = favorite;
        Hint = hint;
        Story = story;
        Tip = tip;
        Instargram = instargram;
        HashTag = hashTag;
    }

    public void Print()
    {
        Debug.Log("No : " + No + "\nName : " + Name + "\n특징 : " + Charactor + "\n취미 : " + Favorite + "\n힌트 : " + Hint + "\n스토리 : " + Story + "\n팁 : " + Tip + "\n인스타 : " + Instargram);
    }

    public string Explan()
    {
        return "특징 :\t" + Charactor + "\n취미 :\t" + Favorite + "\n스토리 :\t" + Story;
    }

    public string SendCharactor()
    {
        return Charactor;
    }

    public string SendFavorite()
    {
        return Favorite;
    }

    public string SendStory()
    {
        return Story;
    }

    public string SendTip()
    {
        return Tip;
    }

    public string NameExplan()
    {
        return Name;
    }

    public string InstarURL()
    {
        return Instargram;
    }

    public string HashTagText()
    {
        return HashTag;
    }
}

public class AnimalExJsonData : JsonDataManager<AnimalEx>
{
    public static AnimalExJsonData Instance;

    protected override void Awake()
    {
        base.Awake();

        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    //싱글톤 인스턴스가 사라졌을 때
    protected virtual void OnDestroy()
    {
        //유일한 Instance가 자신이면, Instance값을 비워줌 (다른 인스턴스가 들어갈 수 있도록)
        if (Instance == this)
            Instance = null;
    }
}
