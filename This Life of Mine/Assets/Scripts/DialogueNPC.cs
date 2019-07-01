using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueNPC : MonoBehaviour
{
    public Dialogue npcDialogue;

    void StartDialogue(Dialogue dialogue)
    {
        DialogueManager.Instance.ActivateDialogue(dialogue);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StartDialogue(npcDialogue);
        }
    }
}
