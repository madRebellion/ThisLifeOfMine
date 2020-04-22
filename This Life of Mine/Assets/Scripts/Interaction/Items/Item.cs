using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;

[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
public class Item : ScriptableObject
{
    public string itemName = "Name";
    public string itemDesc = " ";
    public int tradeValue;
    public Sprite inventoryIcon;
    public ItemType itemType;

    public virtual void Use()
    {
        Debug.Log("Using");
    }
}
