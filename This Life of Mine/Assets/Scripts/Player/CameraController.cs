using UnityEngine;

public class CameraController : MonoBehaviour
{
    PlayerManager playerManager;

    Vector3 currentRotation;
    Vector3 velocity;
    
    public float distanceFromPlayer = 8f;
    [SerializeField]float yaw;
    [SerializeField]float pitch;
    float smoothTime = 0.1f;

    public Transform player;
    public Transform lockOnTarget;
    //public PlayerControls controls;
    
    public float mouseSensitivity;
    public bool isLockingOn = false;

    //private void Awake()
    //{
    //    controls = new PlayerControls();
    //}

    void Start()
    {
        playerManager = PlayerManager.instance;
        //Lock the mouse cursor to the centre of the game window and hide it from view.
        //Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void LateUpdate()
    {
        if (isLockingOn)
            LookAtTarget(lockOnTarget);
        else
            MoveCamera();

        //Keeps the camera a set distance away from the player while following.
        //transform.position = player.position + Vector3.up * 1.7f - (transform.forward * distanceFromPlayer);
    }

    void MoveCamera()
    {
        //Yaw is looking left and right.
        yaw = playerManager.controls.SimpleControls.MoveCamera.ReadValue<Vector2>().x;
        //Pitch is looking up and down. Inverted for some reason. Works as intended but can be changed if people prefer the inverted controls.
        pitch = -playerManager.controls.SimpleControls.MoveCamera.ReadValue<Vector2>().y;
        //Prevents the camera from completely rolling under or over the player.
        pitch = Mathf.Clamp(pitch, -20f, 65f);

        currentRotation = Vector3.SmoothDamp(currentRotation, new Vector3(pitch, yaw), ref velocity, smoothTime);
        transform.eulerAngles = currentRotation;
        transform.position = player.position - (transform.forward * distanceFromPlayer);
    }

    public void LookAtTarget(Transform target)
    {
        Vector3 lookDirection = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(lookDirection.x, 0f, lookDirection.z));
        //Instead of snapping to a rotation we want to spherically interpolate with a certain speed.        
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, 5f * Time.deltaTime);
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

    //private void OnEnable()
    //{
    //    controls.Enable();   
    //}
    //private void OnDisable()
    //{
    //    controls.Disable();
    //}
}
