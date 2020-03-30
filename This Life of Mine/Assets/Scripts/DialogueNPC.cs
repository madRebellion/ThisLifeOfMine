using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

//Attach this to characters you want the player to talk to.
public class DialogueNPC : MonoBehaviour
{
    DialogueArrays npc = new DialogueArrays();
    public Player player;

    //public GameObject talkPrompt;
    
    int dialogueID = 1;
    int previousID;
    public float dst;//Used later.

    private void Start()
    {
        npc.PopulateDictionary(gameObject.name);
        previousID = dialogueID;
    }


    private void Update()
    {
        GetDistance();
        HandleDialogue();
    }

    void ChangeID()
    {
        previousID = dialogueID;
        
        dialogueID++;
    }

    void StartDialogue(Dialogue dialogue)
    {
        player.lookTarget = gameObject.transform;//The player will rotate to look at this NPC when talking (see 'Player' script for more details).
        player.interacting = true;
        DialogueManager.Instance.ActivateDialogue(dialogue);//Access the dialogue manager to show the dialogue UI + other things.
    }

    void HandleDialogue()
    {
        if (DialogueManager.Instance.talkPrompt.activeInHierarchy)//If the player is close enough and they can still engage in converstaion, then show the talk prompt and await input.
        {            
            if (Input.GetKeyDown(KeyCode.E) && npc.dialogueOptions.ContainsKey(dialogueID))
            {
                StartDialogue(npc.dialogueOptions[dialogueID]);

                if (dialogueID < npc.dialogueOptions.Count)
                    ChangeID();
            }
        }        
    }

    void GetDistance()
    {
        dst = Vector3.Distance(transform.position, player.transform.position);

        if (dst <= 4f)
        {
            DialogueManager.Instance.talkPrompt.SetActive(true);
        }
        else
        {
            DialogueManager.Instance.talkPrompt.SetActive(false);
        }
    }

    //void GetDialogue(string newID)
    //{
    //    streamingPath = Application.streamingAssetsPath + "/Dialogue/" + gameObject.name + "/" + newID + " " + gameObject.name + ".json";
    //    jsonFile = File.ReadAllText(streamingPath);
    //    npcDialogue = JsonUtility.FromJson<Dialogue>(jsonFile);
    //}
}
