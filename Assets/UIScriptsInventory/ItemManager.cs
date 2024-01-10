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
    public TextMeshProUGUI coutText;
    public GameObject description;
    public GameObject options;
    public Item item;
    public void UpdateitemPoll(Item _item)
    {
        this.item = _item;
        Name.text = item._name;
        image.sprite = item.image;
        coutText.text = _item.cout+"";
    }
    public void UpdateCout(int newCout)
    {
        item.cout += newCout;
        coutText.text = item.cout+"";
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
