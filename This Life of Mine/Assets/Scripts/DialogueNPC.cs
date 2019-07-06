using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueNPC : MonoBehaviour
{
    public Dialogue[] npcDialogue;
    public Player player;

    int timesTalked = 0;
    float dst;

    private void Awake()
    {
        for (int i = 1; i < npcDialogue.Length; i++)
        {
            npcDialogue[i].charName = npcDialogue[0].charName;
        }
    }

    private void Update()
    {
        DistanceFromPlayer();
        HandleDialogue();
    }

    void StartDialogue(Dialogue dialogue)
    {
        player.lookTarget = gameObject.transform;
        player.interacting = true;
        DialogueManager.Instance.ActivateDialogue(dialogue);
    }

    void HandleDialogue()
    {
        if (dst <= 3.5f && timesTalked < npcDialogue.Length)
        {
            DialogueManager.Instance.talkPrompt.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
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
        else if (timesTalked > npcDialogue.Length)
        {
            DialogueManager.Instance.talkPrompt.SetActive(false);
        }
    }

    void DistanceFromPlayer()
    {        
        dst = Vector3.Distance(transform.position, player.transform.position);
    }   

}
