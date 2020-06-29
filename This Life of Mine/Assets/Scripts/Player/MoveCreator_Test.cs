using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCreator_Test : MonoBehaviour
{
    public List<AnimationClip> comboList = new List<AnimationClip>();

    public int comboIndex = 0;

    public Animator anim;
    public AnimatorOverrideController moveOverride;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (comboIndex >= comboList.Count)
        {
            comboIndex = 0;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (comboList.Count > comboIndex)
            {
                ComboCreator(comboList[comboIndex]);
                anim.SetTrigger("Attack");
                comboIndex++;
            }            
        }
    }

    public void ComboCreator(AnimationClip newMove)
    {
        // Access the Player Override Controller and find the motion (or Animation Clip)
        // called "Idle_Basic" - this is just a template motion.
        // Replace that template with a new clip defined by the player.
        moveOverride["Idle_Basic"] = newMove;
    }
}
