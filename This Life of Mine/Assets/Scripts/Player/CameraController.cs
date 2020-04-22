using UnityEngine;

public class CameraController : MonoBehaviour
{
    Vector3 currentRotation;
    Vector3 velocity;

    public float distanceFromPlayer = 8f;
    float yaw;
    float pitch;
    float smoothTime = 0.1f;

    public Transform playerObject;

    public float mouseSensitivity;

    void Start()
    {
        //Lock the mouse cursor to the centre of the game window and hide it from view.
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void LateUpdate()
    {
        //Yaw is looking left and right.
        yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
        //Pitch is looking up and down. Inverted for some reason. Works as intended but can be changed if people prefer the inverted controls.
        pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;

        //Prevents the camera from completely rolling under or over the player.
        pitch = Mathf.Clamp(pitch, -10f, 45f);

        //Smoothly rotate our current rotation to the target rotation (new Vector3(...)) as defined by the pitch and yaw of the camera.
        currentRotation = Vector3.SmoothDamp(currentRotation, new Vector3(pitch, yaw), ref velocity, smoothTime);
        transform.eulerAngles = currentRotation;

        //Keeps the camera a set distance away from the player while following.
        transform.position = playerObject.position - transform.forward * distanceFromPlayer;
    }

    public void ConvertPosition(float[] camPos)
    {
        Vector3 camPosition;
        camPosition.x = camPos[0];
        camPosition.y = camPos[1];
        camPosition.z = camPos[2];
        transform.position = camPosition;
    }

    public void ConvertRotation(float[] camRot)
    {
        Vector3 cameraRot;
        cameraRot.x = camRot[0];
        cameraRot.y = camRot[1];
        cameraRot.z = camRot[2];
        transform.eulerAngles = cameraRot;
    }
}
