using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    #region Singleton
    public static HUDManager instance;
    private void Awake()
    {
        if (instance != null)
            return;
        instance = this;
    }
    #endregion

    public GameObject talkUI;
    public GameObject collectUI;

    public Player player;
    //ItemPickUp item;

    [SerializeField]
    GameObject popUpBox;
    [SerializeField]
    TextMeshProUGUI itemNameText;
    [SerializeField]
    TextMeshProUGUI descriptionText;

    #region Show/Hide Prompts
    public void ShowPrompt(ItemPickUp item)
    {
        collectUI.SetActive(true);
    }

    public void ShowPrompt(DialogueNPC npc)
    {
        talkUI.SetActive(true);
    }

    public void HidePrompt(ItemPickUp item)
    {
        collectUI.SetActive(false);
    }

    public void HidePrompt(DialogueNPC npc)
    {
        talkUI.SetActive(false);
    }
    #endregion

    public void DisplayItemPopUp(ItemPickUp _item)
    {
        //player.LookAtTarget(_item.transform);
        //item = _item;
        collectUI.SetActive(false);        
        itemNameText.text = _item.item.itemBasics.itemName;
        descriptionText.text = _item.item.itemBasics.itemDesc;
        popUpBox.SetActive(true);

        if (Cursor.lockState == CursorLockMode.Locked)
        {
            player.cameraController.enabled = false;
            player.mover.enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

    }

    public void CloseWindow()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        player.cameraController.enabled = true;
        player.mover.enabled = true;
        popUpBox.SetActive(false);
    }
}