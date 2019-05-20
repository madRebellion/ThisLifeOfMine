using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Armour", menuName = "Items/Armour")]
public class ArmourItem : ScriptableObject
{
    [SerializeField]
    string armourName, armourDesc;

    [SerializeField]
    int damageResistance, monetaryValue, stackMax;

    [SerializeField]
    Sprite icon, stackAmount;
    
    [SerializeField]
    ItemType itemEffect = ItemType.Defence;
}
