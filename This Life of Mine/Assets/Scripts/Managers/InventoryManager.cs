using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    private void Awake()
    {
        if (Instance != null)
            return;
        Instance = this;                
    }

    int buttonPressed = -1;

    PlayerManager playerManager;
    private void Start()
    {
        playerManager = PlayerManager.instance;
        //Debug.Log(playerManager.controls.SimpleControls.UseItem.ReadValue<float>());
        playerManager.controls.SimpleControls.UseItem.performed += useItem => buttonPressed = (int)useItem.ReadValue<float>();

    }

    private void Update()
    {
        ItemBeingUsed();
    }

    int availableInventorySpace = 10;

    public delegate void ChangeInventory(Item item);
    public static event ChangeInventory OnInventoryChanged;

    public delegate void OnItemUsed(int index);
    public static event OnItemUsed UsingItem;

    public List<Item> itemList = new List<Item>();

    public void AddItemToInventory(Item addItem)
    {
        if (availableInventorySpace > 0 || itemList.Contains(addItem))
        {
            itemList.Add(addItem);
            OnInventoryChanged?.Invoke(addItem);       //If the event isn't empty then invoke event
        }
        else
        {
            Debug.Log("Inventory space low!");
        }
               
    }

    public void RemoveItemFromInventory(Item removeItem)
    {
        itemList.Remove(removeItem);

        OnInventoryChanged?.Invoke(removeItem);
    }

    void ItemBeingUsed()
    {        
        if (buttonPressed > 0 && itemList[buttonPressed - 1] != null)
        {            
            UsingItem?.Invoke(buttonPressed - 1);
            buttonPressed = -1;            
        }        
    }
}
