using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector3 inputDirection, inputRotation;

    float rotationTarget;
    float rotationVelocity;
    float rotationSpeed = 0.1f;

    public float speed;
    
    new Transform camera;

    private void Start()
    {
        camera = Camera.main.transform;
    }

    public void Update()
    {
        inputDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        inputRotation = inputDirection.normalized;

        if (inputRotation != Vector3.zero)
        {
            rotationTarget = Mathf.Atan2(inputRotation.x, inputRotation.z) * Mathf.Rad2Deg + camera.eulerAngles.y;
            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, rotationTarget, ref rotationVelocity, rotationSpeed);
        }        

        speed = (Input.GetKey(KeyCode.LeftShift) ? 15f : 10f) * inputRotation.magnitude;

        transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);
    }

}
