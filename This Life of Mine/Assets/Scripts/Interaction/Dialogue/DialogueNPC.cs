using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

//Attach this to characters you want the player to talk to.
public class DialogueNPC : Interactable
{
    Dialogue npcDialogue;
            
    int dialogueID = 1;
    int previousID;

    private void FixedUpdate()
    {
        //CalculateDistanceAway(transform);
    }

    void ChangeID()
    {
        previousID = dialogueID;        
        dialogueID++;
        try
        {
            npcDialogue = ReadFile();
        }
        catch (FileNotFoundException ex)
        {
            dialogueID = previousID;
        }
    }

    public void StartDialogue()
    {
        DialogueManager.Instance.ActivateDialogue(npcDialogue);
        ChangeID();
    }

    public void CollectDialogue()
    {
        npcDialogue = ReadFile();
        Debug.Log("File read successfully. " + npcDialogue.charName + "s file loaded");
    }

    Dialogue ReadFile()
    {
        string streamingPath = Application.streamingAssetsPath + "/Dialogue/" + gameObject.name + "/" + dialogueID + " " + gameObject.name + ".json";
        string jsonFile = File.ReadAllText(streamingPath);
        Dialogue npc = JsonUtility.FromJson<Dialogue>(jsonFile);
        return npc;
    }
    
}
