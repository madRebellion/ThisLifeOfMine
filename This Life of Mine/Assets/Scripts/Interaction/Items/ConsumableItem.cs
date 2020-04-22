﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;

[CreateAssetMenu(fileName = "New Item", menuName = "Items/Consumable")]
public class ConsumableItem : ScriptableObject
{
    [SerializeField]
    string itemName, itemDesc;

    [SerializeField]
    int monetaryValue;

    [SerializeField]
    float cooldownUseRate;

    [SerializeField]
    Sprite icon; 
    
    [SerializeField]
    ItemType itemType;
}
