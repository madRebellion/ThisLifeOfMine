using UnityEngine;

public class Player : MonoBehaviour
{
    Vector3 inputDirection, inputRotation;

    float rotationTarget;
    float rotationVelocity;
    float rotationSpeed = 0.1f;
    float speed = 10f;

    public bool interacting = false;    
    
    new Transform camera;
    [HideInInspector]
    public Transform lookTarget;

    private void Start()
    {
        camera = Camera.main.transform;
    }

    public void Update()
    {
        if (!interacting)
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
        else
        {
            LookAtTarget(lookTarget);
        }
    }

    void LookAtTarget(Transform target)
    {
        Vector3 lookDirection = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(lookDirection.x, 0f, lookDirection.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, 5f * Time.deltaTime);
    }

}
