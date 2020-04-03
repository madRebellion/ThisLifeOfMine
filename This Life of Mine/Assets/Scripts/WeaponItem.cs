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
    int damage, monetaryValue, stackMax;

    [SerializeField]
    Sprite icon, stackAmount;

    [SerializeField]
    float attackSpeed;

    [SerializeField]
    ItemType itemEffect = ItemType.Damage;
}
