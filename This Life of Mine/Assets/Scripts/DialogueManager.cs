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

    Queue<string> dialogueSentences;//It's like a list.

    //public Dictionary<int, Dialogue> dialogues = new Dictionary<int, Dialogue>();

    //Accessing the text element of the Text Mesh Pro component for use in UI
    public TextMeshProUGUI namePlate, sentencePlate;

    public GameObject talkPrompt, dialogueBox;

    Color nextColour = new Color(255, 255, 255), completeColour = new Color(0, 198, 0);//The colour of the button to let the player know if more dialogue exists or if the converation has ended.
    public Image buttonIcon;
    public Sprite next, finish;//Two different icons exist - an arrow that says 'next' and a checkmark to indicate that the converation is ending.

    //Quick fixes to prevent the player and camera from moving when in dialogue.
    public Player playerMovement;
    public TPCamera cameraMovement;
    
    //A different way to write a Start function
    void Start() => dialogueSentences = new Queue<string>();

    public void ActivateDialogue(Dialogue d)
    {
        //Show the cursor and unlock it.
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        //Quick fixes to prevent the player from moving and looking around while in dialogue
        playerMovement.interacting = true;
        //cameraMovement.interacting = true;
        cameraMovement.enabled = false;//Disable the script that allows the camera to move.

        dialogueBox.SetActive(true);//Show the dialogue box.
        
        talkPrompt.SetActive(false);//Hide the '[E] - Talk' prompt.
                
        namePlate.text = d.charName;//Show the name of the current NPC on the UI window.
       
        //Clears the queue of any string elements that was added to the queue from another NPC or dialogue source.
        //Prevents dialogue from appearing that does't belong to the current object.
        dialogueSentences.Clear();
        
        //Add each of the sentences that this NPC will say to a queue.
        foreach (string s in d.charSentence)
        {
            dialogueSentences.Enqueue(s);
        }

        NextSentence();
    }

    public void NextSentence()
    {
        if (dialogueSentences.Count == 0)       //If we have no more elements in our queue...
        {
            FinishDialogue();                   //...then we end the conversation.
            return;
        }
        else if (dialogueSentences.Count == 1)  //If we are on our last sentence then we want to show the checkmark icon.
        {
            buttonIcon.sprite = finish;
            buttonIcon.color = completeColour;
        }
        else                                    //Otherwise show the arrow icon to let the player know that more needs to be said.
        {
            buttonIcon.sprite = next;
            buttonIcon.color = nextColour;
        }
        
        //sentencePlate.text = dialogueSentences.Dequeue();
        string sentence = dialogueSentences.Dequeue();//Take the next element in our queue and store it as a new string for later use.
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    //Animate each letter appearing on scren rather than just throwing the sentence on screen all at once. This looks nicer.
    IEnumerator TypeSentence(string sentence)
    {
        sentencePlate.text = "";//Make sure that the UI is empty before adding new elements to it.   
        foreach (char letter in sentence.ToCharArray())//Convert the sentence into an array of characters...
        {
            sentencePlate.text += letter;              //...then add each of the letters one by one to the UI.
            yield return new WaitForSeconds(0.03f);    //This can be seen as the text speed. This should be a variable that player can change but for now lets hard code it in.
        }
    }

    //Generic dialogue ending crap.
    void FinishDialogue()
    {
        dialogueBox.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        playerMovement.interacting = false;
        cameraMovement.enabled = true;
    }

}
