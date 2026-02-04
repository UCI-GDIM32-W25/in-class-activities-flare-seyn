using TMPro;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private GameObject _inventoryUI;
    [SerializeField] private TMP_Text _itemText;

    public void ToggleShowInventory(List<ItemW5Demo2> inventory)
    {
        _inventoryUI.gameObject.SetActive(!_inventoryUI.gameObject.activeSelf);
            
        string itemList = "";
        int i = 0;
        foreach(ItemW5Demo2 item in inventory)
        {
            itemList += item.itemName;
            if(i < inventory.Count - 1) itemList += ", ";
            i++;
        }
        _itemText.text = itemList;
    }
}