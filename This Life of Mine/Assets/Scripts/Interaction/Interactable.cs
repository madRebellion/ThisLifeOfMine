using UnityEngine;
using Enums;

public class Interactable : MonoBehaviour
{
    public InteractableType ObjectType;
    //public Transform interactionTransform;
    public Player player;

    public float range = 3f;
    //public bool interactReady = false;

    public bool interacting = false;

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    public virtual void Interact ()
    {
        Debug.Log("Interacting with " + transform.name);
        interacting = true;
    }

    protected void CalculateDistanceAway(Transform thisTransform)
    {
        float distanceFromPlayer = Vector3.Distance(player.transform.position, thisTransform.position);
        if (distanceFromPlayer <= range)
        {
            if (!interacting)
            {
                HUDManager.instance.collectUI.SetActive(true);
            }
        }
        else
        {
            HUDManager.instance.collectUI.SetActive(false);
        }
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
    
    //private void OnDrawGizmosSelected()
    //{
    //    if (interactionTransform == null)
    //        interactionTransform = transform;

    //    Gizmos.color = Color.yellow;
    //    Gizmos.DrawWireSphere(interactionTransform.position, range);
    //}
}