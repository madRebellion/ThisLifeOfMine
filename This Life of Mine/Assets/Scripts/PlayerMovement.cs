using UnityEngine;

public class PlayerMovement
{
    Vector3 inputDirection, inputRotation;

    float rotationTarget;
    float rotationVelocity;

    public float speed = 10f;
    float rotationSpeed = 0.1f;


    public void MovePlayer(Rigidbody rb)
    {
        inputDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        inputRotation = inputDirection.normalized;

        if (inputRotation != Vector3.zero)
        {
            rotationTarget = Mathf.Atan2(inputRotation.x, inputRotation.z) * Mathf.Rad2Deg;
            rb.transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(rb.transform.eulerAngles.y, rotationTarget, ref rotationVelocity, rotationSpeed);
        }        

        speed = Input.GetKey(KeyCode.LeftShift) ? 15f : 10f;

        rb.MovePosition(rb.position + inputDirection * speed * Time.fixedDeltaTime);

    }

}
