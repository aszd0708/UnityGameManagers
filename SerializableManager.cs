using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

/*
 * 직렬화 해서 파일로 만들어 저장하는 함수
 * 제네릭 함수를 사용하여 원하는 자료형으로 만들 수 있음
 * 와! 개 편할듯!
 */

public class SerializableManager<T> : MonoBehaviour
{
    private  string saveDataName;

    public virtual string SaveDataName { get => saveDataName; set => saveDataName = value; }

    // 데이터를 저장해서 파일로 만들어 생성    
    public void SaveDataFile(List<T> saveData)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/" + SaveDataName + ".dat");

        List<T> saveInfo = new List<T>();

        saveInfo = saveData;

        bf.Serialize(file, saveInfo);
        file.Close();
    }

    public void SaveDataFile(T saveData)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/" + SaveDataName + ".dat");

        T saveInfo = saveData;

        bf.Serialize(file, saveInfo);
        file.Close();
    }

    // 만든 이름을 찾아서 갖고옴
    public List<T> LoadDataFile()
    {
        List<T> saveInfo = new List<T>();

        if (!System.IO.File.Exists(Application.persistentDataPath + "/" + SaveDataName + ".dat"))
        {
            return null;
        }

        else
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.OpenRead(Application.persistentDataPath + "/" + SaveDataName + ".dat");

            if (file != null && file.Length > 0)
            {
                // 파일 역직렬화하여 B에 담기
                saveInfo = (List<T>)bf.Deserialize(file);
                // B --> A에 할당
                file.Close();
            }
        }

        return saveInfo;
    }
    public T LoadObjectDataFile()
    {
        T saveInfo = default(T);

        if (!System.IO.File.Exists(Application.persistentDataPath + "/" + SaveDataName + ".dat"))
        {
            return saveInfo;
        }

        else
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.OpenRead(Application.persistentDataPath + "/" + SaveDataName + ".dat");

            if (file != null && file.Length > 0)
            {
                // 파일 역직렬화하여 B에 담기
                saveInfo = (T)bf.Deserialize(file);
                // B --> A에 할당
                file.Close();
            }
        }

        return saveInfo;
    }

    public void DeleteDataFile()
    {
        System.IO.File.Delete(Application.persistentDataPath + "/" + SaveDataName + ".dat");
        Debug.Log(SaveDataName + "삭제됨");
    }

    protected bool CheckHaveData()
    {
        bool haveData = File.Exists(Application.persistentDataPath + "/" + SaveDataName + ".dat");

        return haveData;
    }
}
