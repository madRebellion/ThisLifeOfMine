using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableInfo : MonoBehaviour
{    
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.isStatic && !Player.interactables.Contains(other.gameObject))
        {
            Player.interactables.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (Player.interactables.Contains(other.gameObject))
            Player.interactables.Remove(other.gameObject);
    }
}
