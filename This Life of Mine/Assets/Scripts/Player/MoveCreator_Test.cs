using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class MoveCreator_Test : MonoBehaviour
{
    public List<int> comboListTest = new List<int>();
    public List<Motion> comboList = new List<Motion>();

    int comboIndex = 0;
    int movesetAdded = 0;

    public Animator anim;
    public AnimatorController animatorController;
    Motion move;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            comboListTest.Add(movesetAdded);
            movesetAdded++;
            animatorController.AddMotion(comboList[comboIndex]);
            comboIndex++;
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (comboListTest.Count > comboIndex)
            {
                Debug.Log(comboListTest[comboIndex]);
                comboIndex++;
            }
            else
                return;

            //animatorController.AddMotion(comboList[comboIndex]);
        }
    }
}
