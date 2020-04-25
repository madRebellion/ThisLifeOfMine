using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat
{
    [SerializeField]
    int initialValue;

    List<int> modifiers = new List<int>();

    public int GetValue()
    {
        int finalValue = initialValue;
        modifiers.ForEach(x => finalValue += x);
        return finalValue;
    }

    public void AddStatModifier(int _mod)
    {
        if (_mod != 0)
        {
            modifiers.Add(_mod);
        }
    }

    public void RemoveStatModifier(int _mod)
    {
        if (_mod != 0)
        {
            modifiers.Remove(_mod);
        }
    }
}
