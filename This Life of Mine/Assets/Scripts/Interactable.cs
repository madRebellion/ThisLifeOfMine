using UnityEngine;
using Enums;

public class Interactable : MonoBehaviour
{
    public InteractableType ObjectType;
    public Transform interactionTransform;

    public float range = 1.5f;

    public bool isFocused = false;
    bool interacting = false;
    Transform player;

    public virtual void Interact ()
    {
        Debug.Log("Interacting with " + transform.name);
    }

    public void OnFocused(Transform playerTransform)
    {
        isFocused = true;
        player = playerTransform;
        interacting = false;
        DialogueManager.Instance.talkPrompt.SetActive(true);
    }

    public void Defocus()
    {
        isFocused = false;
        player = null;
        interacting = false;
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
    
    private void OnDrawGizmosSelected()
    {
        if (interactionTransform == null)
            interactionTransform = transform;

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, range);
    }
}