using UnityEngine;

public class ItemPickUp : Interactable
{
    public Item item;

    public override void Interact()
    {
        base.Interact();

        CollectItem();
    }

    private void Update()
    {
        CalculateDistanceAway(transform);
    }

    void CollectItem()
    {
        Debug.Log("Picked up " + gameObject.name);
        interacting = false;
        bool pickedUp = Inventory.instance.AddItem(item);
        if (pickedUp)
            Destroy(gameObject);
    }
}
