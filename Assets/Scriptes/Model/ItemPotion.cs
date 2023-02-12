using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPotion : ItemBaseModel
{
    // Скрипт-Модель. Базовая для всех последующих зелий или временных припасов.

    public ItemPotion(int id, string name, Sprite ico) : base(id, name, ico)
    {
    }
}
