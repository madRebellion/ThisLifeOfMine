using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class JsonDialogueTester : MonoBehaviour
{
    string path;
    string jsonPath;
    public Text dialogueText;
    Dialogue roger;

    // Start is called before the first frame update
    void Start()
    {
        path = Application.streamingAssetsPath + "/Dialogue/" + gameObject.name + ".json";
        jsonPath = File.ReadAllText(path);
        roger = JsonUtility.FromJson<Dialogue>(jsonPath);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            dialogueText.text = roger.charName + ": " + roger.charSentence[0];
        }
    }

}
