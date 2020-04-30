//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class InteractableInfo : MonoBehaviour
//{
//    Player player;

//    private void Awake()
//    {
//        player = FindObjectOfType<Player>();
//    }

//    private void OnTriggerEnter(Collider other)
//    {
//        // Make all terrain based game objects static game objects to avoid adding them to the list of interactables
//        if (!other.gameObject.isStatic && !Player.interactables.Contains(other.gameObject))
//        {
//            Player.interactables.Add(other.gameObject);

//            //float distanceAway = Vector3.Distance(other.transform.position, transform.position);

//            //Debug.Log("In range. Adding component...");
//            //switch (other.tag)
//            //{
//            //    case "Item":
//            //        player.nearbyItems = other.GetComponent<ItemPickUp>();
//            //        Debug.Log("Item added.");
//            //        break;
//            //    case "NPC / Dialogue":
//            //        player.nearbyNpcs = other.GetComponent<DialogueNPC>();
//            //        Debug.Log("NPC added.");
//            //        break;
//            //    default:
//            //        break;
//            //}
//        }
//    }

//    //private void OnTriggerExit(Collider other)
//    //{
//    //    if (Player.interactables.Contains(other.gameObject))
//    //        Player.interactables.Remove(other.gameObject);

//    //    if (other.tag == "Item")
//    //    {
//    //        player.RemoveFromItemList(other.GetComponent<ItemPickUp>());
//    //    }
//    //    else if (other.tag == "NPC / Dialogue")
//    //    {
//    //        player.RemoveFromNPCList(other.GetComponent<DialogueNPC>());
//    //    }
//    //}
//}
