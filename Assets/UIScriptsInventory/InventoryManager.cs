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
    public int countItems;
    public Transform conteinerInventory;
    public GameObject prefabCellInventory;
    public List<ItemManager> itemManagers = new List<ItemManager>();
    public SaveLoadStorage saveLoadStorage;
    public ItemsStorage itemsStorage;
    private void Start()
    {
        saveLoadStorage = new SaveLoadStorage();
        itemsStorage = new ItemsStorage();
    }

    [ContextMenu("Save")]
    private void Save()
    {
        saveLoadStorage.SaveData(itemsStorage, "PlayerInventory");
        Debug.Log("Save");
    }
    [ContextMenu("Load")]
    private void Load()
    {
        itemsStorage.items.AddRange(saveLoadStorage.LoadData("PlayerInventory"));
        countItems = itemsStorage.items.Count;
        if(countItems != 0)
        {
            for (int i = 0; i < countItems; i++)
            {
                GameObject itemM =  Instantiate(prefabCellInventory, conteinerInventory.transform);
                itemM.GetComponent<ItemManager>().UpdateitemPoll(itemsStorage.items[i]);
                itemManagers.Add(itemM.GetComponent<ItemManager>());
            }
        }
        Debug.Log("load");
    }
    public void UpdateInventoryPoll(Item item)
    {
        GameObject itemM =  Instantiate(prefabCellInventory, conteinerInventory.transform);
        itemM.GetComponent<ItemManager>().UpdateitemPoll(item);
    }
}