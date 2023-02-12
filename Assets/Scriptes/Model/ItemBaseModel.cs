using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemBaseModel : IItemVisual
{
    //������� �������������� ������� ��������
    public int _id { get; }
    public string _name { get; }
    public Sprite _ico { get; }

    //��������������
    public string Name => _name;
    public Sprite Visual => _ico;

    //�����������
    public ItemBaseModel(int id, string name, Sprite ico)
    {
        _id = id;
        _name = name;
        _ico = ico;
    }
}
