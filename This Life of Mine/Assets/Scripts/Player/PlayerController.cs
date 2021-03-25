using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] PlayerManager playerManager;

    private void Start()
    {
        playerManager = PlayerManager.instance;
    }

    [SerializeField] protected Animator anim;
    [SerializeField] CharacterController controller;
    [SerializeField] Transform cam;

    [SerializeField] float moveSpeed;
    [SerializeField] protected float walkSpeed, sprintSpeed;
    //Smooth Damp Angle variables
    float targetRot, targetRotVel, rotSpeed = 0.1f;
    //Smooth Damp variables
    float currentSpeed, targetSpeedVel, smoothSpeed = 0.1f;

    float gravityEffect;
    float idleTime = 0.0f;

    public float gravity = -9.81f;
       
    public void Move()
    {
        Vector2 input = playerManager.controls.SimpleControls.Move.ReadValue<Vector2>();

        //Rotate only when we want to - prevent division by zero
        if (input != Vector2.zero)
        {
            targetRot = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg + cam.eulerAngles.y;
            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRot, ref targetRotVel, rotSpeed);
            idleTime = 0.0f;
        }

        bool moving = (input != Vector2.zero);
        moveSpeed = ((playerManager.controls.SimpleControls.Sprint.activeControl != null) ? sprintSpeed : walkSpeed) * input.magnitude;
        currentSpeed = Mathf.SmoothDamp(currentSpeed, moveSpeed, ref targetSpeedVel, smoothSpeed);
 
        gravityEffect += Time.deltaTime * gravity;

        Vector3 velocity = transform.forward * currentSpeed + Vector3.up * gravityEffect;
        controller.Move(velocity * Time.deltaTime);
        if (controller.isGrounded)
        {
            gravityEffect = 0.0f;
        }

        float animMove = ((moving) ? 1.0f : 0.0f) * input.magnitude;
        anim.SetFloat("Run", animMove, smoothSpeed, Time.deltaTime);
    }     

    protected void Idle()
    {
        anim.SetFloat("IdleTime", idleTime += Time.deltaTime);
    }
}
