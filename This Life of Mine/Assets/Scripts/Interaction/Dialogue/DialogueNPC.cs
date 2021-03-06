﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

//Attach this to characters you want the player to talk to.
public class DialogueNPC : MonoBehaviour
{
    [SerializeField]
    Dialogue npcDialogue;
            
    int dialogueID = 1;
    int previousID;

    public float interactionTimer = 2f;
    public bool talkable = true;

    private void Start()
    {
        CollectDialogue();
    }

    private void Update()
    {
        //CalculateDistanceAway(transform);
        if (!talkable)
            interactionTimer -= 1f * Time.deltaTime;
        if (interactionTimer <= 0)
        {
            talkable = true;
            interactionTimer = 2f;
        }
    }

    public void Interact()
    {
        if (talkable)
        {
            StartDialogue();
        }
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

    void StartDialogue()
    {
        DialogueManager.Instance.ActivateDialogue(npcDialogue);
        ChangeID();
    }

    public void CollectDialogue()
    {
        npcDialogue = ReadFile();
        if (npcDialogue != null)
            Debug.Log("File read successfully. " + npcDialogue.charName + "s file loaded");        
        else
            Debug.Log("Failed to get dialogue");
    }

    Dialogue ReadFile()
    {
        string streamingPath = Application.streamingAssetsPath + "/Dialogue Scripts/" + gameObject.name + "/" + dialogueID + " " + gameObject.name + ".json";
        string jsonFile = File.ReadAllText(streamingPath);
        Dialogue npc = JsonUtility.FromJson<Dialogue>(jsonFile);
        return npc;
    }
    
}
