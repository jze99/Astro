using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemUse : MonoBehaviour
{
    public Camera _camera;
    public InventoryManager inventoryManager;
    public void Start()
    {
        _camera = Camera.main;
    }
    public void Update()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit; 
        if(Physics.Raycast(ray, out hit))
        {
            if(hit.transform.GetComponent<DropeItems>() && Input.GetKeyDown(KeyCode.E))
            {
                Item upItem = hit.transform.GetComponent<DropeItems>().item;
                foreach(ItemManager dup in inventoryManager.itemManagers)
                {
                    if(dup.Name.text.Equals(upItem._name, System.StringComparison.OrdinalIgnoreCase))
                    {
                        dup.UpdateCout(upItem.cout);
                        Destroy(hit.transform.gameObject);
                        return;
                    }
                }
                inventoryManager.itemsStorage.items.Add(new Item(hit.transform.GetComponent<DropeItems>().item));
                Destroy(hit.transform.gameObject);
                inventoryManager.UpdateInventoryPoll(hit.transform.GetComponent<DropeItems>().item);
                
            }
        }
    }
}
