using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerMovement playerMove = new PlayerMovement();
    Rigidbody rb;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponentInChildren<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        playerMove.MovePlayer(rb);
    }
}
