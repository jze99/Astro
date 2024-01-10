using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using Newtonsoft.Json;
using System.IO;
using System;

[System.Serializable]
public class InventoryManager : MonoBehaviour
{
    public List<Item> items = new List<Item>();
    public int countItems;
    public Transform conteinerInventory;
    public GameObject prefabCellInventory;
    

    private void Start()
    {
        //PlayerPrefs.GetInt("countItems", countItems);
        //conteinerInventory = transform.Find("Content");
        
    }
    [ContextMenu("AddItems")]
    private void AddItems()
    {
        //items.Add(new Item());
    }

    [ContextMenu("Save")]
    private void Save()
    {
        SaveInventoryData();
        Debug.Log("Save");
    }
    [ContextMenu("Load")]
    private void Load()
    {
        LoadInventoryData();
        countItems = items.Count;
        if(countItems != 0)
        {
            for (int i = 0; i < countItems; i++)
            {
                GameObject itemM =  Instantiate(prefabCellInventory, conteinerInventory.transform);
                itemM.GetComponent<ItemManager>().loading(_item: items[i]);
            }
        }
        Debug.Log("load");
    }

    public void SaveInventoryData()
    {
        string json = JsonUtility.ToJson(new SerializableInventoryList<Item> { itemsList = items });
        File.WriteAllText(Application.persistentDataPath + "InventoryData.json", json);
    }

    public void LoadInventoryData()
    {
        string path = Application.persistentDataPath + "InventoryData.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SerializableInventoryList<Item> savedData = JsonUtility.FromJson<SerializableInventoryList<Item>>(json);
            items = savedData.itemsList;
        }
    }

        

}

[Serializable]
public class SerializableInventoryList<T>
{
    public List<T> itemsList;
}