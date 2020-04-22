using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    Item item;

    public Image icon;
    public Button removeButton;

    public void AddItem(Item newItem)
    {
        item = newItem;

        icon.sprite = item.inventoryIcon;
        icon.enabled = true;
        removeButton.interactable = true;
    }

    public void CleanSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
    }

    public void RemoveItem()
    {
        Inventory.instance.RemoveItem(item);
    }

    public void UseItem()
    {
        if (item != null)
        {
            item.Use();
        }
    }
}
