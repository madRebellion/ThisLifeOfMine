using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] CinemachineFreeLook cineCam;

    float ySpeed, xSpeed;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        if (cineCam != null)
        {
            ySpeed = cineCam.m_YAxis.m_MaxSpeed;
            xSpeed = cineCam.m_XAxis.m_MaxSpeed;
        }
    }

}
