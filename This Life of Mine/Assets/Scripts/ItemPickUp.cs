using UnityEngine;

public class ItemPickUp : Interactable
{
    public override void Interact()
    {
        base.Interact();

        CollectItem();
    }

    void CollectItem()
    {
        Debug.Log("Picked up " + gameObject.name);
        Destroy(gameObject);
    }
}
