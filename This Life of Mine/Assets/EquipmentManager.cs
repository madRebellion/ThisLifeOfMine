using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;

public class EquipmentManager : MonoBehaviour
{
    #region Singleton
    public static EquipmentManager instance;
    private void Awake()
    {
        if (instance != null)
            return;
        instance = this;
    }
    #endregion

    public Equipment[] defaultItems;

    public SkinnedMeshRenderer targetMesh;
    Equipment[] currentEquipment;
    SkinnedMeshRenderer[] currentMeshes;

    public delegate void OnEquipmentChanged(Equipment newItem, Equipment oldItem);
    public OnEquipmentChanged onEquipmentChangedCallback;

    Inventory inventory;

    private void Start()
    {
        inventory = Inventory.instance;
        int size = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Equipment[size];
        currentMeshes = new SkinnedMeshRenderer[size];

        EquipDefault();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            UnequipAll();
        }
    }

    public void Equip(Equipment newItem)
    {
        int slotIndex = (int)newItem.equipmentSlot;
        Unequip(slotIndex);
        Equipment oldItem = Unequip(slotIndex);
        
        if (onEquipmentChangedCallback != null)
        {
            onEquipmentChangedCallback.Invoke(newItem, oldItem);
        }

        SetEquipmentBlendShapes(newItem, 100);

        currentEquipment[slotIndex] = newItem;
        SkinnedMeshRenderer newMesh = Instantiate<SkinnedMeshRenderer>(newItem.mesh);
        newMesh.transform.parent = targetMesh.transform;

        newMesh.bones = targetMesh.bones;
        newMesh.rootBone = targetMesh.rootBone;
        currentMeshes[slotIndex] = newMesh;
    }

    public Equipment Unequip(int slotIndex)
    {
        if (currentEquipment[slotIndex] != null)
        {
            if (currentMeshes[slotIndex] != null)
            {
                Destroy(currentMeshes[slotIndex].gameObject);
            }
            Equipment oldItem = currentEquipment[slotIndex];
            SetEquipmentBlendShapes(oldItem, 0);
            inventory.AddItem(oldItem);

            currentEquipment[slotIndex] = null;

            if (onEquipmentChangedCallback != null)
            {
                onEquipmentChangedCallback.Invoke(null, oldItem);
            }
            return oldItem;
        }
        return null;
    }

    void SetEquipmentBlendShapes(Equipment item, int weight)
    {
        foreach (EquipmentMeshRegion blends in item.coveredMeshRegions)
        {
            targetMesh.SetBlendShapeWeight((int)blends, weight);
        }
    }

    void EquipDefault()
    {
        foreach (Equipment item in defaultItems)
        {
            Equip(item);
            SetEquipmentBlendShapes(item, 0);
        }
    }

    public void UnequipAll()
    {
        for (int i = 0; i < currentEquipment.Length; i++)
        {
            Unequip(i);
        }
        EquipDefault();
    }
}
