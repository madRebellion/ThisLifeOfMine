using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;

[CreateAssetMenu(fileName = "New Armour", menuName = "Items/Armour")]
public class ArmourItem : ScriptableObject
{
    [SerializeField]
    string armourName, armourDesc;

    [SerializeField]
    int damageResistance, monetaryValue;

    [SerializeField]
    Sprite icon;
    
    [SerializeField]
    ItemType itemEffect = ItemType.Defence;
}
