using UnityEngine;
using Enums;

public class Interactable : MonoBehaviour
{
    public InteractableType InteractType;

    public float range = 3f;

    //Called a change is made in the inspector
    //Sets the tag
    private void OnValidate()
    {
        switch (InteractType)
        {
            case InteractableType.GenericNPC:
                gameObject.tag = "NPC / No Dialogue";
                break;
            case InteractableType.DialogueNPC:
                gameObject.tag = "NPC / Dialogue";
                gameObject.AddComponent<DialogueNPC>();
                break;
            case InteractableType.WorldItem:
                gameObject.tag = "Item";
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
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}