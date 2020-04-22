using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMove))]
public class Player : MonoBehaviour
{
    //[SerializeField]
    //Interactable target;

    public ItemPickUp item;
    public DialogueNPC npc;
    //Container container;

    // List of objects close to us that we can interact with
    //-- INTERACTABLE INFO SCRIPT POPULATES THIS LIST --
    public static List<GameObject> interactables = new List<GameObject>();

    public static PlayerMove mover;
    public static CameraController cameraController;

    public float interactionRange = 3f;
    //public float distanceAway;

    private void Start()
    {
        mover = GetComponent<PlayerMove>();
        cameraController = Camera.main.GetComponent<CameraController>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameStateManager.instance.isPaused = !GameStateManager.instance.isPaused;
            GameStateManager.instance.PauseGame();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
        else
        {
            mover.MoveCharacter();
        }

        InteractacblesInScene();
    }

    public void LookAtTarget(Transform target)
    {
        Vector3 lookDirection = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(lookDirection.x, 0f, lookDirection.z));
        //Instead of snapping to a rotation we want to spherically interpolate with a certain speed.
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, 5f * Time.deltaTime);
    }

    //public void UseAsTarget(Interactable _target)
    //{
    //    target = _target;
    //    target.interactReady = true;
    //}

    //public void ClearTarget()
    //{
    //    target = null;
    //}

    //bool ReadyToInteract()
    //{
    //    if (target != null && target.interactReady)
    //        return true;
    //    return false;
    //}

    void Interact()
    {
        if (item != null)
        {
            RotateToItem();
            HUDManager.instance.DisplayItemPopUp(item);
        }
    }

    void RotateToItem()
    {
        LookAtTarget(item.transform);
    }

    public void CollectItem()
    {
        item.Interact();
        item = null;
    }

    void Talk()
    {
        npc.Interact();
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.GetComponent<Interactable>())
    //        target = other.GetComponent<Interactable>();

    //    if (other.tag == "NPC / Dialogue")
    //    {
    //        Debug.Log(other.gameObject.name);
    //        DialogueManager.Instance.talkPrompt.SetActive(true);
    //        player.lookTarget = other.gameObject.transform;
    //        other.gameObject.GetComponent<DialogueNPC>().CollectDialogue();
    //    }
    //    else if (other.tag == "Item")
    //    {
    //        Debug.Log(target.ObjectType);
    //        target.OnFocused(transform);
    //        player.lookTarget = other.gameObject.transform;
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.tag == "NPC / Dialogue")
    //    {
    //        DialogueManager.Instance.talkPrompt.SetActive(false);
    //        player.lookTarget = null;
    //    }
    //    target = null;
    //}

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

    private void InteractacblesInScene()
    {
        if (interactables != null)
        {
            foreach (GameObject gObject in interactables)
            {
                if (gObject != null)
                {
                    float distanceAway = Vector3.Distance(gObject.transform.position, transform.position);
                    Debug.DrawLine(transform.position, gObject.transform.position, Color.red);

                    //if (distanceAway <= interactionRange)
                    //{
                    Debug.Log("In range. Adding component...");
                    switch (gObject.tag)
                    {
                     case "Item":
                         item = gObject.GetComponent<ItemPickUp>();
                         Debug.Log("Item added.");
                         break;
                     case "NPC / Dialogue":
                         npc = gObject.GetComponent<DialogueNPC>();
                         Debug.Log("NPC added.");
                         break;
                     default:
                         break;
                    }

                    //}                   
                }
            }
        }
    }
}
