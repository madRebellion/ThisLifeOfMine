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
    ItemPickUp item;

    [SerializeField]
    GameObject popUpBox;
    [SerializeField]
    TextMeshProUGUI itemNameText;
    [SerializeField]
    TextMeshProUGUI descriptionText;

    public void DisplayItemPopUp(ItemPickUp _item)
    {
        item = _item;
        item.interacting = true;
        collectUI.SetActive(false);        
        itemNameText.text = item.item.name;
        descriptionText.text = item.item.itemDesc;
        popUpBox.SetActive(true);

        if (Cursor.lockState == CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        Player.cameraController.enabled = false;
        Player.mover.enabled = false;
    }

    public void CloseWindow()
    {
        popUpBox.SetActive(false);
        player.CollectItem();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Player.cameraController.enabled = true;
        Player.mover.enabled = true;
    }
}