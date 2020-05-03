using System.IO;
using UnityEngine;
using Enums;

[RequireComponent(typeof(Interactable))]
public class ItemPickUp : Interactable
{
    public Item item;
    
    public override void Interact()
    {
        base.Interact();
        PlayerManager.instance.player.mover.anim.SetTrigger("PickUp");
        HUDManager.instance.DisplayItemPopUp(this);
        CollectItem();
    }

    public void DetermineItem()
    {
        item.itemBasics = ReadFile();
    }

    void CollectItem()
    {
        Debug.Log("Picked up " + gameObject.name);
        bool pickedUp = Inventory.instance.AddItem(item);
        if (pickedUp)
        {
            Destroy(gameObject);
        }
    }

    ItemGenerics ReadFile()
    {
        string streamingPath = Application.streamingAssetsPath + "/Items/" + item.itemType.ToString() + "/" + item.name + ".json";
        string jsonFile = File.ReadAllText(streamingPath);
        ItemGenerics i = JsonUtility.FromJson<ItemGenerics>(jsonFile);
        return i;
    }
}
