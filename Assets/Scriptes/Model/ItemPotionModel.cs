using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPotionModel : ItemBaseModel
{
    // Скрипт-Модель. Базовая для всех последующих зелий или временных припасов.

    public ItemPotionModel(int id, string name, Sprite ico) : base(id, name, ico)
    {
    }
}
