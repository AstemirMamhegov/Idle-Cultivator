using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemPocketPlankAsset", menuName = "Item/ItemPocketPlankAsset", order = 0)]
public class ItemPocketPlankAsset : ItemBaseAsset
{
    [SerializeField] int passiveDao;

    public override ItemBaseModel Create()
    {
        ItemPocketMeditationPlankModel modelPlank = new ItemPocketMeditationPlankModel(_id, _name, _ico, passiveDao);
        return modelPlank;
    }
}
