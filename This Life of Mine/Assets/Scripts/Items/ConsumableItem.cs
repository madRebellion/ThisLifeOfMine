using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Items/Consumable")]
public class ConsumableItem : Item
{
    public int healingAmount;

    public override void UseItem()
    {
        base.UseItem();

    }
}
