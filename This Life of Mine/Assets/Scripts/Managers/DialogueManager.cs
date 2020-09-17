using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Cinemachine;

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
    public TextMeshProUGUI charName, charSentence, conversationPrompts;

    public GameObject talkPrompt, itemPrompt, dialogueBox, hotbar;

    Color nextColour = new Color(255, 255, 255), completeColour = new Color(0, 198, 0);

    //Prevent the player and camera from moving when in dialogue.
    public Player player;
    public CinemachineFreeLook freeLookCamera;

    public bool isInConversation = false;

    //A different way to write a Start function
    void Start()
    {
        dialogueSentences = new Queue<string>();
        PlayerManager.instance.controls.SimpleControls.Interact.performed += dialogue => DisplaySentence();
    }

    private void LateUpdate()
    {
        //if (Input.GetKeyDown(KeyCode.Q) && isInConversation)
        //{
        //    DisplaySentence();
        //}
    }

    #region Dialogue
    public void ActivateDialogue(Dialogue characterDialogue)
    {
        isInConversation = true;
        //HUDManager.instance.isInteracting = true;
        Debug.Log("Talking with " + characterDialogue.charName);

        hotbar.SetActive(false);
        dialogueBox.SetActive(true);        
        talkPrompt.SetActive(false);

        freeLookCamera.enabled = false;
        player.state = PlayerState.Interacting;

        charName.text = characterDialogue.charName;
       
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
        if (isInConversation)
        {
            switch (dialogueSentences.Count)
            {
                case 0:
                    FinishDialogue();
                    return;
                case 1:
                    conversationPrompts.text = "- End -";
                    conversationPrompts.color = completeColour;
                    break;
                default:
                    conversationPrompts.text = "> Next [E]";
                    conversationPrompts.color = nextColour;
                    break;
            }

            //Take the next element in our queue and store it as a new string for later use.
            string sentence = dialogueSentences.Dequeue();

            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));
        }
    }

    //Animate each letter appearing on scren rather than just throwing the sentence on screen all at once.
    IEnumerator TypeSentence(string newSentence)
    {
        charSentence.text = "";//Make sure that the UI is empty before adding new elements to it.   
        foreach (char letter in newSentence.ToCharArray())//Convert the sentence into an array of characters...
        {
            charSentence.text += letter;              //...then add each of the letters one by one to the UI.
            yield return new WaitForSeconds(0.03f);    //This can be seen as the text speed. This should be a variable that player can change but for now lets hard code it in.
        }
    }

    void FinishDialogue()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        player.state = PlayerState.Moving;
        freeLookCamera.enabled = true;
        isInConversation = false;
        //HUDManager.instance.isInteracting = false;
        dialogueBox.SetActive(false);
        //PlayerManager.instance.player.state = PlayerState.Moving;
        hotbar.SetActive(true);
    }
    #endregion

    private void OnEnable()
    {
        //PlayerManager.instance.controls.SimpleControls.Interact.performed += dialogue => DisplaySentence();
    }
    private void OnDisable()
    {
        PlayerManager.instance.controls.SimpleControls.Interact.performed -= dialogue => DisplaySentence();
    }
}
