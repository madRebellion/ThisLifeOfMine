using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class JsonTest : MonoBehaviour
{
    string path;
    string json;

    public Dialogue npc;
    
    // Start is called before the first frame update
    void Start()
    {        
           path = Application.streamingAssetsPath + "/Dialogue/" + gameObject.name + ".json";
           json = File.ReadAllText(path);
           Dialogue convo = JsonUtility.FromJson<Dialogue>(json);           
               
        //DialogueManager.Instance.ActivateDialogue(Chris);
        //Debug.Log(Chris.charSentence[0]);
    }

}
