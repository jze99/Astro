using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class ItemManager : MonoBehaviour
{
    public TextMeshProUGUI Name;
    public Image image;
    public GameObject description;
    public GameObject options;
    public Item item;
    public void loading(Item _item)
    {
        this.item = _item;
        Name.text = item._name;
        image.sprite = item.image;
    }
    public void ViewOptions()
    {
        if(options.activeInHierarchy == true)
        {
            options.SetActive(false);
        }
        else
        {
            options.SetActive(true);
        }
    }
}
