using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DialogueArrays 
{
    public Dictionary<int, Dialogue> dialogueOptions = new Dictionary<int, Dialogue>();

    public void PopulateDictionary(string _name)
    {
        dialogueOptions.Clear();        

        string[] files = Directory.GetFiles(Application.streamingAssetsPath + "/Dialogue/" + _name + "/", "*.json");

        foreach (string s in files)
        {
            string jsonString = File.ReadAllText(s);
            Dialogue npc = JsonUtility.FromJson<Dialogue>(jsonString);
            dialogueOptions.Add(npc.id, npc);
            Debug.Log("Dictionary compiled " + dialogueOptions.Count + " files");
        }
    }
}
