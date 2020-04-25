using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Items/Weapon")]
public class WeaponItem : ScriptableObject
{
    [SerializeField]
    string weaponName, weaponDesc;

    [SerializeField]
    int damage, monetaryValue;

    [SerializeField]
    Sprite icon;

    [SerializeField]
    float attackSpeed;

    [SerializeField]
    ItemType itemEffect = ItemType.Equipment;
}
