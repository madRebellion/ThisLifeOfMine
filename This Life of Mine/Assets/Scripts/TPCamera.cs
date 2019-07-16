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
        //Lock the mouse cursor to the centre of the game window and hide it from view.
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void LateUpdate()
    {       
        yaw += Input.GetAxis("Mouse X") * mouseSensitivity;//Yaw is looking left and right.
        pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;//Pitch is looking up and down. Inverted for some reason. Works as intended but can be changed if people prefer the inverted controls.

        pitch = Mathf.Clamp(pitch, -10f, 45f);//Prevents the camera from completely rolling under or over the player.

        //Smoothly rotate our current rotation to the target rotation (new Vector3(...)) as defined by the pitch and yaw of the camera. smoothTime = the time is takes to reach our target.
        currentRotation = Vector3.SmoothDamp(currentRotation, new Vector3(pitch, yaw), ref velocity, smoothTime);//ref velocity is set and used within the function, do not give a default value.
        transform.eulerAngles = currentRotation;

        //Keeps the camera a set distance away from the player while following.
        transform.position = playerObject.position - transform.forward * distanceFromPlayer;
            
    }

}
