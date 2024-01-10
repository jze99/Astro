using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveLoadStorage 
{
    public void SaveData(ItemsStorage _items, string fileName)
    {
        string path = Path.Combine(Application.persistentDataPath, fileName);
        string json = JsonUtility.ToJson(_items);
        File.WriteAllText(path, json);
    }

    public Item[] LoadData(string fileName)
    {
        string path = Path.Combine(Application.persistentDataPath, fileName);
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            ItemsStorage wrapper = JsonUtility.FromJson<ItemsStorage>(json);
            return wrapper.items.ToArray();
        }
        else
        {
            Debug.LogError("Файл не найден");
            return null;
        }
    }
}
