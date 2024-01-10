using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

[System.Serializable]
public class Item
{
  public string _name; //название
  public string description; //опесание
  public Sprite image; //картинка
  public int cout; //текушие количество в стаке
  public int maxCout; //максимальное количество в стаке
  public enum type
  {
    Value1,
    Value2,
    Value3
  }

  public type typeItem; //тип 
  public int cost; //стоимость 

  public Item(string _name, string description, Sprite image, int cout, int maxCout, type typeItem, int cost)
  {
    this._name = _name;
    this.description = description;
    this.image = image;
    this.cout = cout;
    this.maxCout = maxCout;
    this.typeItem = typeItem;
    this.cost = cost;
  }
  public Item(Item newItem)
  {
    this._name = newItem._name;
    this.description = newItem.description;
    this.image = newItem.image;
    this.cout = newItem.cout;
    this.maxCout = newItem.maxCout;
    this.typeItem = newItem.typeItem;
    this.cost = newItem.cost;
  }
}
