using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public string itemDescription;

    public int value;
    public int offensiveModifier;
    public int defensiveModifier;
    public int healthModifier;

    public bool isKeyItem;
    public bool isSellable;

    public ItemType ItemType;
}

public enum ItemType
{
    Offensive,
    Defensive,
    Healing,
    Important
};
