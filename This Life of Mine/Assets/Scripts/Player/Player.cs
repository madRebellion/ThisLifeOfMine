using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;

[RequireComponent(typeof(PlayerMove))]
public class Player : MonoBehaviour
{
    public ItemPickUp nearbyItem;
    public DialogueNPC nearbyNpc;
    public Enemy nearbyEnemy;
    //Container container;
    
    public Transform lookTarget;
    public Transform lockOnTarget;
    
    bool inRange;
    bool lockedOn = false;

    public bool combatMode = false;
    public float waitTime = 1.05f;
    public bool jumping = false;

    public float jumpHeight = 1.2f;

    public LayerMask mask;

    public PlayerMove mover;
    public CameraController cameraController;

    public Animator animator;
    
    //The 'TargetSelector' script populates this list
    public static List<GameObject> targetableEntites = new List<GameObject>();
    public static Transform playerTransform;

    private void Start()
    {
        playerTransform = transform;
        mover = GetComponent<PlayerMove>();
        cameraController = Camera.main.GetComponent<CameraController>();
    }

    private void Update()
    {
        Ray ray = new Ray(cameraController.transform.position + new Vector3(0f, 0f, 5f), cameraController.transform.forward * 10f);
        RaycastHit hit;
        Debug.DrawRay(cameraController.transform.position, cameraController.transform.forward * 10f);
        if (Physics.Raycast(ray, out hit, 10f, mask))
        {            
            if (hit.transform.tag == "NPC / No Dialogue")
            {
                Debug.Log(hit.transform.name);
                lockOnTarget = hit.transform;           
            }
        }

        if (lockOnTarget != null && Input.GetKeyDown(KeyCode.L))
            lockedOn = true;

        if (lockedOn)
            cameraController.lockOnTarget = lockOnTarget;
        else
            cameraController.lockOnTarget = null;

        if (nearbyEnemy != null && Input.GetKeyDown(KeyCode.G))
        {
            LookAtTarget(lookTarget);
            nearbyEnemy.Interact();
        }

        HandleInputs();

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
        if (Input.GetKeyDown(KeyCode.Return))
        {
            GameStateManager.instance.isPaused = !GameStateManager.instance.isPaused;
            GameStateManager.instance.PauseGame();
        }
        if (inRange && Input.GetKeyDown(KeyCode.E))
        {
            if (nearbyItem != null)
                nearbyItem.Interact();
            else if (nearbyNpc != null)
            {
                nearbyNpc.Interact();
                mover.anim.SetTrigger("SayHello");
            }
            
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            mover.anim.SetBool("Jump", true);
            mover.Jump();
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            mover.anim.SetTrigger("SayHello");
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            combatMode = !combatMode;
            mover.anim.SetBool("CombatMode", combatMode);
        }      
        if (Input.GetMouseButtonDown(0))
        {
            mover.anim.SetTrigger("Attack");
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            GameStateManager.instance.isPaused = !GameStateManager.instance.isPaused;
            GameStateManager.instance.MovesMenu();
        }
        else if (!HUDManager.instance.isInteracting)
            mover.Move();
    }

    void InteractWithItem()
    {
        nearbyItem.Interact();
    }

    public void StopAnimating()
    {
        mover.anim.SetFloat("Speed", 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
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
                nearbyNpc.CollectDialogue();
                break;
            case "Enemy":
                nearbyEnemy = other.gameObject.GetComponent<Enemy>();
                lookTarget = nearbyEnemy.transform;
                inRange = true;
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
                lookTarget = null;
                inRange = false;
                break;
            case "NPC / Dialogue":
                HUDManager.instance.HidePrompt(nearbyNpc);
                nearbyNpc = null;
                lookTarget = null;
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
   
}
