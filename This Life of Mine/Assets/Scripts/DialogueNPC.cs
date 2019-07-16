using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Attach this to characters you want the player to talk to.
public class DialogueNPC : MonoBehaviour
{
    public Dialogue[] npcDialogue;
    public Player player;

    int timesTalked = 0;
    float dst;//Used later.

    private void Awake()
    {
        //Haven't figured out an easier way to this yet...
        for (int i = 1; i < npcDialogue.Length; i++)
        {
            npcDialogue[i].charName = npcDialogue[0].charName;//It just simply makes the name of character the same when opening up a new dialogue box.
        }
    }

    private void Update()
    {
        DistanceFromPlayer();
        HandleDialogue();
    }

    void StartDialogue(Dialogue dialogue)
    {
        player.lookTarget = gameObject.transform;//The player will rotate to look at this NPC when talking (see 'Player' script for more details).
        player.interacting = true;
        DialogueManager.Instance.ActivateDialogue(dialogue);//Access the dialogue manager to show the dialogue UI + other things.
    }

    void HandleDialogue()
    {
        if (dst <= 3.5f && timesTalked < npcDialogue.Length)//If the player is close enough and they can still engage in converstaion, then show the talk prompt and await input.
        {
            DialogueManager.Instance.talkPrompt.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                switch (timesTalked)//Needs to be refined. Maybe use XML or JSON for dialogue. This will do for now.
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
        else
        {
            DialogueManager.Instance.talkPrompt.SetActive(false);
        }
    }

    //Allows us to know when the player is within talking range.
    void DistanceFromPlayer()
    {        
        dst = Vector3.Distance(transform.position, player.transform.position);
    }   

}
