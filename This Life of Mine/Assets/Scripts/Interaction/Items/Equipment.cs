using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Equipment")]
public class Equipment : Item
{
    public EquipmentSlot equipmentSlot;
    public EquipmentMeshRegion[] coveredMeshRegions;
    public SkinnedMeshRenderer mesh;

    public int armourModifier;
    public int damageModifier;

    public override void Use()
    {
        base.Use();
        EquipmentManager.instance.Equip(this);
        RemoveFromInventory();
    }
}

public enum EquipmentMeshRegion
{
    Legs,
    Arms,
    Torso
}
