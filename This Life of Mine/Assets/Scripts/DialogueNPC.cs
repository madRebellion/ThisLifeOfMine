using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

//Attach this to characters you want the player to talk to.
public class DialogueNPC : MonoBehaviour
{
    public Dialogue npcDialogue;
    public Player player;

    string streamingPath, jsonFile;

    int previousID;
    int dialogueID = 1;
    //int timesTalked = 0;
    float dst;//Used later.

    private void Start()
    {
        GetDialogue(dialogueID.ToString());
    }

    void ChangeID()
    {
        previousID = dialogueID;
        dialogueID++;
    }

    private void Update()
    {
        DistanceFromPlayer();
        HandleDialogue();

        if (dialogueID != previousID)
        {
            GetDialogue(dialogueID.ToString());
        }
    }

    void StartDialogue(Dialogue dialogue)
    {
        player.lookTarget = gameObject.transform;//The player will rotate to look at this NPC when talking (see 'Player' script for more details).
        player.interacting = true;
        DialogueManager.Instance.ActivateDialogue(dialogue);//Access the dialogue manager to show the dialogue UI + other things.
    }

    void HandleDialogue()
    {
        if (dst <= 3.5f)//If the player is close enough and they can still engage in converstaion, then show the talk prompt and await input.
        {
            DialogueManager.Instance.talkPrompt.SetActive(true);    
            
            if (Input.GetKeyDown(KeyCode.E))
            {
                StartDialogue(npcDialogue);
                ChangeID();
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

    void GetDialogue(string newID)
    {
        streamingPath = Application.streamingAssetsPath + "/Dialogue/" + gameObject.name + "/" + newID + " " + gameObject.name + ".json";
        jsonFile = File.ReadAllText(streamingPath);
        npcDialogue = JsonUtility.FromJson<Dialogue>(jsonFile);
    }

    //private void OnTriggerStay(Collider other)
    //{
    //    if (other.tag == "Player" && Input.GetKeyDown(KeyCode.E))
    //    {
    //        StartDialogue(npcDialogue);
    //        ChangeID();
    //    }
    //}

}
