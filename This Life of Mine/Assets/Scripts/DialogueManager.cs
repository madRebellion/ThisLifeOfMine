﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    #region Singleton
    public static DialogueManager Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            return;
        }

        Instance = this;
    }
    #endregion

    Queue<string> dialogueSentences;

    //Accessing the text element of the Text Mesh Pro component for use in UI
    public TextMeshProUGUI namePlate, sentencePlate;

    public GameObject talkPrompt, dialogueBox;

    Color nextColour = new Color(255, 255, 255), completeColour = new Color(0, 198, 0);
    public Image buttonIcon;
    public Sprite next, finish;

    //Prevent the player and camera from moving when in dialogue.
    public Player playerMovement;
    public TPCamera cameraMovement;
    
    //A different way to write a Start function
    void Start() => dialogueSentences = new Queue<string>();

    public void ActivateDialogue(Dialogue characterDialogue)
    {
        Debug.Log("Talking with " + characterDialogue.charName);
        //Show the cursor and unlock it.
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        cameraMovement.enabled = false;
        playerMovement.enabled = false;

        dialogueBox.SetActive(true);        
        talkPrompt.SetActive(false);
                
        namePlate.text = characterDialogue.charName;
       
        dialogueSentences.Clear();
        
        //Add each of the sentences that this NPC will say to a queue.
        foreach (string s in characterDialogue.charSentence)
        {
            dialogueSentences.Enqueue(s);
        }
        //Show first/next sentence
        DisplaySentence();
    }

    public void DisplaySentence()
    {
        switch (dialogueSentences.Count)
        {
            case 0:
                FinishDialogue();
                return;
            case 1:
                buttonIcon.sprite = finish;
                buttonIcon.color = completeColour;
                break;
            default:
                buttonIcon.sprite = next;
                buttonIcon.color = nextColour;
                break;
        }

        //Take the next element in our queue and store it as a new string for later use.
        string sentence = dialogueSentences.Dequeue();

        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    //Animate each letter appearing on scren rather than just throwing the sentence on screen all at once.
    IEnumerator TypeSentence(string sentence)
    {
        sentencePlate.text = "";//Make sure that the UI is empty before adding new elements to it.   
        foreach (char letter in sentence.ToCharArray())//Convert the sentence into an array of characters...
        {
            sentencePlate.text += letter;              //...then add each of the letters one by one to the UI.
            yield return new WaitForSeconds(0.03f);    //This can be seen as the text speed. This should be a variable that player can change but for now lets hard code it in.
        }
    }

    void FinishDialogue()
    {
        dialogueBox.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        playerMovement.enabled = true;
        cameraMovement.enabled = true;
    }

}
