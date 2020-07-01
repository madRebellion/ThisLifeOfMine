using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveSlot : MonoBehaviour, IDropHandler
{
    RectTransform pos;

    private void Awake()
    {
        pos = GetComponent<RectTransform>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = pos.anchoredPosition;
        }
    }

}
