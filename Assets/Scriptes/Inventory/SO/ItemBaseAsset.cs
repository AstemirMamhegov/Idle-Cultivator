using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemAsset", menuName = "Item/ItemAsset", order = 0)]
public class ItemBaseAsset : ScriptableObject
{
    [SerializeField] protected int _id;
    [SerializeField] protected string _name;
    [SerializeField] protected Sprite _ico;

    public virtual ItemBaseModel Create()
    {
        ItemBaseModel model = new ItemBaseModel(_id, _name, _ico);
        return model;
    }
}
    
