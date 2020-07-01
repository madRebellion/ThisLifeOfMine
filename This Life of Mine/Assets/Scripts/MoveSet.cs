using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoveSet : MonoBehaviour
{
    public MoveCreator_Test playerMoves;
    public TextMeshProUGUI moveName;
    public AnimationClip moveClip;

    // Start is called before the first frame update
    void Start()
    {
        moveName.text = moveClip.name;
    }

    public void ChooseClip()
    {
        playerMoves.comboList.Add(moveClip);
    }
}
