using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemHUDHelper : MonoBehaviour
{
    [SerializeField] TMP_Text text;

    [SerializeField] Animator anim;

    public void DisplayHUD(Item i)
    {
        text.text = i.itemName + " was added!";
        anim.SetTrigger("ShowHUD");
    }

}
