using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemSlot : MonoBehaviour
{
    public Item itemInSlot;

    [SerializeField] TMP_Text itemNameText;
    [SerializeField] TMP_Text amountText;

    int amountInInvetory;

    //public void AddItemToSlot(Item i)
    //{
    //    if (itemInSlot == null)
    //    {
    //        itemInSlot = i;            
    //        itemNameText.text = itemInSlot.itemName;
    //        amountInInvetory = 1;
    //        amountText.text = amountInInvetory.ToString();
    //    }
    //    else 
    //    {
    //        AddToExisting();
    //    }
    //}

    public void AddNewItem(Item i)
    {
        itemInSlot = i;
        itemNameText.text = itemInSlot.itemName;
        amountInInvetory = 1;
        amountText.text = amountInInvetory.ToString();
    }

    public void AddToExisting()
    {
        amountInInvetory++;
        amountText.text = amountInInvetory.ToString();
    }

    public void OnItemUsed()
    {
        if (itemInSlot != null)
        {
            itemInSlot.UseItem();
            amountInInvetory--;

            if (amountInInvetory < 1)
            {
                itemInSlot.RemoveFromInventory();
                CleanSlot();
            }
        }
        else
            Debug.Log("Item null.");
    }

    public void CleanSlot()
    {
        itemInSlot = null;
        itemNameText.text = null;
        amountText.text = null;
        amountInInvetory = 0;
    }

    public bool AddedItem()
    {
        return true;
    }
   
}
