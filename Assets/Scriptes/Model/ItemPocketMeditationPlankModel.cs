using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPocketMeditationPlankModel : ItemBaseModel, IPassiveDao, IPassiveELement
{
    //Скрипт-Модель для увеличения характеристики пассивного накопления Дао
    public int _passiveDao { get; }

    public int Dao => _passiveDao;

    public ItemPocketMeditationPlankModel(int id, string name, Sprite ico, int passiveDao) : base(id, name, ico)
    {
        _passiveDao = passiveDao;
    }

    public int GetDao()
    {
        return Dao;
    }
}
