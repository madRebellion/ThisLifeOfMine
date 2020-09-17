using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    InventoryManager inventory;

    [SerializeField] ItemHUDHelper hudHelper;
    [SerializeField] ItemSlot[] itemSlots;

    private void Start()
    {        
        inventory = InventoryManager.Instance;

        foreach (ItemSlot i in itemSlots)
        {
            i.CleanSlot();
        }
    }

    void UpdateInventoryUI(Item item)
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i].itemInSlot == null)
            {
                itemSlots[i].AddNewItem(item);
                hudHelper.DisplayHUD(item);
                break;
            }
            else if (itemSlots[i].itemInSlot.itemName == item.itemName)
            {
                itemSlots[i].AddToExisting();
                hudHelper.DisplayHUD(item);
                break;
            }
        }


    }

    void UseItem(int index)
    {
        itemSlots[index].OnItemUsed();
    }

    //Subscription handling for the event in the InventoryManager script
    private void OnEnable()
    {
        InventoryManager.OnInventoryChanged += UpdateInventoryUI;
        InventoryManager.UsingItem += UseItem;
    }
    private void OnDisable()
    {
        InventoryManager.OnInventoryChanged -= UpdateInventoryUI;
        InventoryManager.UsingItem += UseItem;
    }
}
