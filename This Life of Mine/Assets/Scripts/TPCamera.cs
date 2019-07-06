using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPCamera : MonoBehaviour
{
    public Transform playerObject;
    
    public float mouseSensitivity;
    //public bool interacting = false;

    float distanceFromPlayer = 8f;
    float yaw;
    float pitch;
    float smoothTime = 0.1f;

    Vector3 currentRotation;
    Vector3 velocity;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void LateUpdate()
    {       
        yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
        pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;

        pitch = Mathf.Clamp(pitch, -10f, 45f);

        currentRotation = Vector3.SmoothDamp(currentRotation, new Vector3(pitch, yaw), ref velocity, smoothTime);
        transform.eulerAngles = currentRotation;

        transform.position = playerObject.position - transform.forward * distanceFromPlayer;
            
    }

}
