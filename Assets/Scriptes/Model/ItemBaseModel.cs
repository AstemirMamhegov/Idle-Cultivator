using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemBaseModel : IItemVisual
{
    //Базовые характеристики каждого предмета
    public int _id { get; }
    public string _name { get; }
    public Sprite _ico { get; }

    //переназначение
    public string Name => _name;
    public Sprite Visual => _ico;

    //Конструктор
    public ItemBaseModel(int id, string name, Sprite ico)
    {
        _id = id;
        _name = name;
        _ico = ico;
    }
}
