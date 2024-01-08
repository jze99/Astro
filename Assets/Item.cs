using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Item : MonoBehaviour
{
  public string _name; //название
  public string description; //опесание
  public Sprite image; //картинка
  public int cout; //текушие количество в стаке
  public int maxCout; //максимальное количество в стаке
  public bool ecvipment; //екепировать
  public int cost; //стоимость 
}
