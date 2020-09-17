using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : ScriptableObject
{
    public string itemName;
    public string itemDescription;

    public int value;

    public bool isKeyItem;
    public bool isSellable;
    public bool hasAlreadyBeenAdded = false;

    public ItemType ItemType;

    public virtual void UseItem()
    {
        Debug.Log(itemName + " was used!");
    }

    public void RemoveFromInventory()
    {
        InventoryManager.Instance.RemoveItemFromInventory(this);
    }
}

public enum ItemType
{
    Offensive,
    Defensive,
    Healing,
    Important
};
