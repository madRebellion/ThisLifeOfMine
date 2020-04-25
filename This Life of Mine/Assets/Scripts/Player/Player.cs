using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;

[RequireComponent(typeof(PlayerMove))]
public class Player : MonoBehaviour
{
    //[SerializeField]
    //Interactable target;
    public ItemPickUp nearbyItem;
    public DialogueNPC nearbyNpc;
    //Container container;

    Transform lookTarget;
    bool inRange;

    public float timeInWhileLoop = 0f;

    //public float distanceAway;

    // List of objects close to us that we can interact with
    //-- INTERACTABLE INFO SCRIPT POPULATES THESE LISTS --
    public static List<GameObject> interactables = new List<GameObject>();

    public static PlayerMove mover;
    public static CameraController cameraController;

    //public float interactionRange = 3f;
    //public float distanceAway;

    private void Start()
    {
        mover = GetComponent<PlayerMove>();
        cameraController = Camera.main.GetComponent<CameraController>();
    }

    private void Update()
    {
        //if (nearbyItem != null)
        //{
        //    if (nearbyItem.interacting)
        //        LookAtTarget(nearbyItem.transform);

        //        //nearbyItem.Interact();
        //}
        //else
        //{
        //    mover.MoveCharacter();
        //}
        
        HandleInputs();

        //DrawLinesToInteractables();

        //SortInteractables();
    }

    public void LookAtTarget(Transform target)
    {
        Transform newTarget = target;
        Vector3 lookDirection = (newTarget.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(lookDirection.x, 0f, lookDirection.z));
        //Instead of snapping to a rotation we want to spherically interpolate with a certain speed.        
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, 5f * Time.deltaTime);        
    }

    void HandleInputs()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameStateManager.instance.isPaused = !GameStateManager.instance.isPaused;
            GameStateManager.instance.PauseGame();
        }
        if (inRange && Input.GetKeyDown(KeyCode.E))
          {
            LookAtTarget(lookTarget);
            lookTarget.GetComponent<ItemPickUp>().Interact();
        }
        else
        {
            mover.MoveCharacter();
        }
    }

    void InteractWithItem()
    {
        LookAtTarget(nearbyItem.transform);
        nearbyItem.Interact();
    }

    //void DrawLinesToInteractables()
    //{
    //    foreach (GameObject gObject in interactables)
    //    {
    //        if (gObject != null)
    //        {
    //            Debug.DrawLine(transform.position, gObject.transform.position, Color.red);
    //        }
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        //if (other.GetComponent<Interactable>())
        //    target = other.GetComponent<Interactable>();

        //if (other.tag == "NPC / Dialogue")
        //{
        //    Debug.Log(other.gameObject.name);
        //    DialogueManager.Instance.talkPrompt.SetActive(true);
        //    player.lookTarget = other.gameObject.transform;
        //    other.gameObject.GetComponent<DialogueNPC>().CollectDialogue();
        //}
        switch (other.tag)
        {
            case "Item":
                nearbyItem = other.gameObject.GetComponent<ItemPickUp>();
                nearbyItem.DetermineItem();
                lookTarget = nearbyItem.transform;
                inRange = true;
                HUDManager.instance.ShowPrompt(nearbyItem);
                break;
            case "NPC / Dialogue":
                nearbyNpc = other.gameObject.GetComponent<DialogueNPC>();
                lookTarget = nearbyNpc.transform;
                inRange = true;
                HUDManager.instance.ShowPrompt(nearbyNpc);
                break;
            default:
                break;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        switch (other.tag)
        {
            case "Item":
                HUDManager.instance.HidePrompt(nearbyItem);
                nearbyItem = null;
                break;
            case "NPC / Dialogue":
                HUDManager.instance.HidePrompt(nearbyNpc);
                nearbyNpc = null;
                break;
            default:
                break;
        }
    }

    public void ConvertPosition(float[] pos)
    {
        Vector3 position;
        position.x = pos[0];
        position.y = pos[1];
        position.z = pos[2];
        transform.position = position;
    }

    public void ConvertRotation(float[] rot)
    {
        Vector3 playerRot;
        playerRot.x = rot[0];
        playerRot.y = rot[1];
        playerRot.z = rot[2];
        transform.eulerAngles = playerRot;
    }

    //private void SortInteractables()
    //{
    //    if (interactables != null)
    //    {
    //        foreach (GameObject gObject in interactables)
    //        {
    //            if (gObject != null)
    //            {
    //                float distanceAway = Vector3.Distance(gObject.transform.position, transform.position);
    //                Debug.DrawLine(transform.position, gObject.transform.position, Color.red);

    //                //if (distanceAway <= interactionRange)
    //                //{
    //                //Debug.Log("In range. Adding component...");
    //                switch (gObject.tag)
    //                {
    //                    case "Item":
    //                        if (!nearbyItems.Contains(gObject.GetComponent<ItemPickUp>()))
    //                            nearbyItems.Add(gObject.GetComponent<ItemPickUp>());
    //                        //Debug.Log("Item added.");
    //                        break;
    //                    case "NPC / Dialogue":
    //                        if (!nearbyNpcs.Contains(gObject.GetComponent<DialogueNPC>()))
    //                            nearbyNpcs.Add(gObject.GetComponent<DialogueNPC>());
    //                        //Debug.Log("NPC added.");
    //                        break;
    //                    default:
    //                        break;
    //                }

    //                //}                   
    //            }
    //        }
    //    }
    //}

    //public void RemoveFromItemList(ItemPickUp o)
    //{
    //    nearbyItems.Remove(o);
    //}
    //public void RemoveFromNPCList(DialogueNPC o)
    //{
    //    nearbyNpcs.Remove(o);
    //}
}
