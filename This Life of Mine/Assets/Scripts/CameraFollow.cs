using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject playerObject;

    public Vector3 cameraPosition;

    public float mouseSensitivity;

    float distanceFromPlayer = 8f;
    float currentYawX = 0f;
    public float currentYawY = 0f;

    Vector3 playerPos;

    private void Start()
    {
        playerPos = playerObject.GetComponent<Rigidbody>().transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        currentYawX -= Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        currentYawY -= Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        currentYawY = Mathf.Clamp(currentYawY, -45f, 25f);

        transform.position = playerObject.GetComponent<Rigidbody>().transform.position - cameraPosition * distanceFromPlayer;
        
        transform.RotateAround(playerPos, new Vector3(0f, 1f, 0f), currentYawX);
        transform.RotateAround(playerPos, new Vector3(1f, 0f, 0f), currentYawY);

        transform.LookAt(playerObject.GetComponent<Rigidbody>().transform.position);
    }
}
