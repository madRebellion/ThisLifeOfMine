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

    public TextMeshProUGUI namePlate, sentencePlate;

    public Animator dialogueBoxAnimator;
    
    // Start is called before the first frame update
    void Start() => dialogueSentences = new Queue<string>();

    public void ActivateDialogue(Dialogue d)
    {
        Debug.Log("Talking to " + d.charName);

        dialogueBoxAnimator.SetBool("StartConvo", true);
        dialogueBoxAnimator.SetBool("ConvoFinish", false);

        namePlate.text = d.charName;
       
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
    }

}
