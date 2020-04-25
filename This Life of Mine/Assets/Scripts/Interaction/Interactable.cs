using UnityEngine;
using Enums;

public class Interactable : MonoBehaviour
{
    public InteractableType ObjectType;
    public Player player;

    public delegate void OnInteracted(Transform t);
    public OnInteracted onInteracted;
    
    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    public virtual void Interact ()
    {
        Debug.Log("Interacting with " + transform.name);
    }
    
    //Called when a change is made in the inspector
    //Sets the tag and adds any components if required
    private void OnValidate()
    {
        switch (ObjectType)
        {
            case InteractableType.GenericNPC:
                gameObject.tag = "NPC / No Dialogue";
                break;
            case InteractableType.DialogueNPC:
                gameObject.tag = "NPC / Dialogue";
                if (!gameObject.GetComponent<DialogueNPC>())
                    gameObject.AddComponent<DialogueNPC>();
                break;
            case InteractableType.WorldItem:
                gameObject.tag = "Item";
                if (!gameObject.GetComponent<ItemPickUp>())
                    gameObject.AddComponent<ItemPickUp>();
                break;
            case InteractableType.Container:
                gameObject.tag = "Container";
                break;
            default:
                gameObject.tag = "Untagged";
                break;
        }
    }
    
}