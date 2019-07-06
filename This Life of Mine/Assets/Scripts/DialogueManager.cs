using System.Collections;
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

    // Accessing the text element of the Text Mesh Pro component for use in UI
    public TextMeshProUGUI namePlate, sentencePlate;

    public GameObject talkPrompt, dialogueBox;

    Color nextColour = new Color(255, 255, 255), completeColour = new Color(0, 198, 0);
    public Image buttonIcon;
    public Sprite next, finish;

    public Player playerMovement;
    public TPCamera cameraMovement;
    
    // A different way to write a Start function apparently
    void Start() => dialogueSentences = new Queue<string>();

    public void ActivateDialogue(Dialogue d)
    {
        // Show the cursor
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        // Quick fixes to prevent the player from moving and looking around while in dialogue
        //playerMovement.interacting = true;
        playerMovement.interacting = true;
        //cameraMovement.interacting = true;
        cameraMovement.enabled = false;

        dialogueBox.SetActive(true);
        
        Debug.Log("Talking to " + d.charName);

        talkPrompt.SetActive(false);
                
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
        else if (dialogueSentences.Count == 1)
        {
            buttonIcon.sprite = finish;
            buttonIcon.color = completeColour;
        }
        else
        {
            buttonIcon.sprite = next;
            buttonIcon.color = nextColour;
        }
        
        //sentencePlate.text = dialogueSentences.Dequeue();
        string sentence = dialogueSentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        sentencePlate.text = "";        
        foreach (char letter in sentence.ToCharArray())
        {
            sentencePlate.text += letter;
            yield return new WaitForSeconds(0.03f);
        }
    }

    void FinishDialogue()
    {
        Debug.Log("Conversation is done.");
        //talkPrompt.SetActive(true);
        dialogueBox.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        playerMovement.interacting = false;
        cameraMovement.enabled = true;
    }

}
