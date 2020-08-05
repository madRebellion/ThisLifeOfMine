using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] CharacterController controller;
    [SerializeField] Transform cam;

    [SerializeField] float moveSpeed;
    //Smooth Damp Angle variables
    float targetRot, targetRotVel, rotSpeed = 0.1f;
    //Smooth Damp variables
    float currentSpeed, targetSpeedVel, smoothSpeed = 0.1f;

    float gravityEffect;

    public float gravity = -9.81f;

    private void Update()
    {        
        Move();
    }

    public void Move()
    {
        Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        Vector3 inputDirection = input.normalized;

        //Rotate only when we want to - prevent division by zero
        if (inputDirection != Vector3.zero)
        {
            targetRot = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRot, ref targetRotVel, rotSpeed);
        }

        bool moving = (inputDirection != Vector3.zero);
        float targetSpeed = ((moving) ? moveSpeed : 0.0f) * inputDirection.magnitude;
        currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref targetSpeedVel, smoothSpeed);

        gravityEffect += Time.deltaTime * gravity;

        Vector3 veloocity = transform.forward * currentSpeed + Vector3.up * gravityEffect;
        controller.Move(veloocity * Time.deltaTime);

        if (controller.isGrounded)
        {
            gravityEffect = 0.0f;
        }

        float animMove = ((moving) ? 1.0f : 0.0f) * inputDirection.magnitude;
        anim.SetFloat("Run", animMove, smoothSpeed, Time.deltaTime);
    }
}
