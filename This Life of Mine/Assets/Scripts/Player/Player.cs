using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;

public class Player : PlayerController
{    
    public PlayerState state;

    public DialogueNPC nearbyNpc;
    public Enemy nearbyEnemy;
    
    public bool combatMode = false;
    //public float waitTime = 1.05f;

    //public LayerMask mask;

    //public Animator animator;
    
    private void Start()
    {
        state = PlayerState.Moving;
    }

    private void Update()
    {
        if (state == PlayerState.Moving)
            Move();
        else if (state == PlayerState.Interacting)
            anim.SetFloat("Run", 0.0f);

        Idle();
    }

    public void LookAtTarget(Transform target)
    {
        Transform newTarget = target;
        Vector3 lookDirection = (newTarget.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(lookDirection.x, 0f, lookDirection.z));
        //Instead of snapping to a rotation we want to spherically interpolate with a certain speed.        
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, 5f * Time.deltaTime);        
    }
  
    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Item":
                InventoryManager.Instance.AddItemToInventory(other.GetComponent<ItemHandler>().item);
                other.gameObject.SetActive(false);
                break;
            case "NPC / Dialogue":
                other.GetComponent<DialogueNPC>().StartDialogue();
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

public enum PlayerState { Moving, Interacting, Combat, Paused }