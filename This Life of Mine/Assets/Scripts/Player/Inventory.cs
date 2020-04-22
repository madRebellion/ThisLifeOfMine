using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;
    private void Awake()
    {
        if (instance != null)
            return;
        instance = this;
    }
    #endregion

    public delegate void WhenInventoryChanges();
    public WhenInventoryChanges inventoryChangedCallback;

    public int inventorySpace = 10;
    public List<Item> inventoryItems = new List<Item>();

    public bool AddItem(Item i)
    {
        if (inventoryItems.Count >= inventorySpace)
        {
            Debug.Log("Inventory full");
            return false;
        }

        inventoryItems.Add(i);

        if (inventoryChangedCallback != null)
            inventoryChangedCallback.Invoke();

        return true;
    }

    public void RemoveItem(Item i)
    {
        inventoryItems.Remove(i);

        if (inventoryChangedCallback != null)
            inventoryChangedCallback.Invoke();
    }
}
