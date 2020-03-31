using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

//Attach this to characters you want the player to talk to.
public class DialogueNPC : MonoBehaviour
{
    DialogueArrays npc = new DialogueArrays();
    public Player player;
        
    int dialogueID = 1;
    int previousID;
    float dst;//Used later.
    
    private void Start()
    {
        //npc.PopulateDictionary(gameObject.name);
        previousID = dialogueID;
    }

    private void Update()
    {
        HandleDialogue();
    }

    public void PopulateDialogue(GameObject thisObj)
    {
        npc.PopulateDictionary(thisObj.name);
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

    //void GetDialogue(string newID)
    //{
    //    streamingPath = Application.streamingAssetsPath + "/Dialogue/" + gameObject.name + "/" + newID + " " + gameObject.name + ".json";
    //    jsonFile = File.ReadAllText(streamingPath);
    //    npcDialogue = JsonUtility.FromJson<Dialogue>(jsonFile);
    //}

    //Talk prompt triggers. 
    //private void OnTriggerEnter(Collider other)
    //{
    //    DialogueManager.Instance.talkPrompt.SetActive(true);        
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    DialogueManager.Instance.talkPrompt.SetActive(false);        
    //}
}
