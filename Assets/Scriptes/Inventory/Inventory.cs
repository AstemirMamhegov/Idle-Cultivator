using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour, IPassiveELement
{
    [SerializeField] private List<ItemBaseAsset> ItemAssets;
    private List<ItemBaseModel> Items = new List<ItemBaseModel>();
    [SerializeField] private InventoryCell _inventoryCellTemplate;
    [SerializeField] private Transform _container;
    [SerializeField] private GameObject _inventory;

    private void Awake()
    { 
        foreach (var asset in ItemAssets) 
        {
            Items.Add(asset.Create());
        }
    }

    private void Start()
    {
        Render(Items);
    }

    public void ShowInventory()
    {
        _inventory.SetActive(!_inventory.activeSelf);
    }

    public void Render(List<ItemBaseModel> items)
    {
        foreach (Transform child in _container)
        {
            Destroy(child.gameObject);
        }

        items.ForEach(item =>
        {
            var cell = Instantiate(_inventoryCellTemplate,_container);
            cell.Render(item);
        });
    }

    public int GetDao()
    {
        int dao = 0;
        foreach (var item in Items)
        {
            dao += (item as IPassiveDao).Dao;
        }
        return dao;
    }
}
