using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerW5Demo1 : MonoBehaviour
{
    // when this stores a list of InventoryItems, it won't show up in the Inspector
    // if it stores a list of ItemW5Demo1, you have to create GameObjects for each item
    //
    // but what if these items never appear on-screen, or appear and disappear in UI?
    // does it make sense for Item to be a MonoBehaviour if it's only representing data and not behavior?
    [SerializeField] private List<InventoryItem> _inventory;

    // this is UI code that doesn't really need to be in the player class,
    // I just put it here because I was coding quickly and lazily
    [SerializeField] private GameObject _inventoryUI;
    [SerializeField] private TMP_Text _itemText;

    private void Update ()
    {
        // toggles the item list text
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _inventoryUI.gameObject.SetActive(!_inventoryUI.gameObject.activeSelf);
            
            string itemList = "";
            int i = 0;
            foreach(InventoryItem item in _inventory)
            {
                itemList += item.itemName;
                if(i < _inventory.Count - 1) itemList += ", ";
                i++;
            }
            _itemText.text = itemList;
        }
    }
}

// I could alternatively add the [Serializable] field to this class,
// and that would make it show up in the Inspector for the Player.
// But do you think there are any downsides to these items *ONLY* being edit-able
//      from the Player GAMEOBJECT?

public class InventoryItem {
    public string itemName;
}