using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : EntityStats
{
    // Start is called before the first frame update
    void Start()
    {
        //EquipmentManager.instance.onEquipmentChangedCallback += ChangeStats;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ReceiveDamage(10);
        }
    }

    //void ChangeStats(Equipment newItem, Equipment oldItem)
    //{
    //    if (newItem != null)
    //    {
    //        armour.AddStatModifier(newItem.armourModifier);
    //        damage.AddStatModifier(newItem.damageModifier);
    //    }
    //    if (oldItem != null)
    //    {
    //        armour.RemoveStatModifier(oldItem.armourModifier);
    //        damage.RemoveStatModifier(oldItem.damageModifier);
    //    }
    //}
}
