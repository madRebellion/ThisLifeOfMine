using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueNPC : MonoBehaviour
{
    public Dialogue[] npcDialogue;
    public Player player;

    int timesTalked = 0;

    private void Awake()
    {
        for (int i = 1; i < npcDialogue.Length; i++)
        {
            npcDialogue[i].charName = npcDialogue[0].charName;
        }
    }

    void StartDialogue(Dialogue dialogue)
    {
        player.lookTarget = gameObject.transform;
        DialogueManager.Instance.ActivateDialogue(dialogue);
    }

    private void OnTriggerEnter(Collider other)
    {
        DialogueManager.Instance.talkPrompt.SetActive(true);
    }

    private void OnTriggerStay(Collider other)
    {
        
        if (other.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {          
            switch (timesTalked)
            {
                case 0:
                    Debug.Log("Pressed E");
                    StartDialogue(npcDialogue[0]);
                    timesTalked++;
                    break;
                case 1:
                    StartDialogue(npcDialogue[1]);
                    timesTalked++;
                    break;
                default:
                    break;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        DialogueManager.Instance.talkPrompt.SetActive(false);
    }
}
