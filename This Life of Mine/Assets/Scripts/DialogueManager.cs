using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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

    // Accessing the text element of the Text Mesh Pro component for use in UI
    public TextMeshProUGUI namePlate, sentencePlate;

    public Animator dialogueBoxAnimator;
    public GameObject talkPrompt;
    
    // A different way to write a Start function apparently
    void Start() => dialogueSentences = new Queue<string>();

    public void ActivateDialogue(Dialogue d)
    {
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        Debug.Log("Talking to " + d.charName);

        talkPrompt.SetActive(false);
        
        dialogueBoxAnimator.SetBool("StartConvo", true);
        dialogueBoxAnimator.SetBool("ConvoFinish", false);      // Preventing the dialogue box from looping between opening and closing transtions when an NPC was talked to after the first time

        namePlate.text = d.charName;
       
        // Clears the queue of any string elements that was added to the queue from another NPC or dialogue source
        // Prevents dialogue from appearing that does't belong to the current object
        dialogueSentences.Clear();

        foreach (string s in d.charSentence)
        {
            dialogueSentences.Enqueue(s);
        }

        NextSentence();
    }

    public void NextSentence()
    {
        if (dialogueSentences.Count == 0)
        {
            FinishDialogue();
            return;
        }

        sentencePlate.text = dialogueSentences.Dequeue();
    }

    void FinishDialogue()
    {
        Debug.Log("Conversation is done.");
        dialogueBoxAnimator.SetBool("StartConvo", false);
        dialogueBoxAnimator.SetBool("ConvoFinish", true);
        talkPrompt.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

}
