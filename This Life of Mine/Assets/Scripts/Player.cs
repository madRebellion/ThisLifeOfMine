using UnityEngine;

public class Player : MonoBehaviour
{
    Vector3 input, inputDirection;

    float rotationTarget;
    float rotationVelocity;
    float rotationSpeed = 0.1f;
    float speed = 10f;

    public bool interacting = false;    
    
    private Transform camera;    
    [HideInInspector]
    public Transform lookTarget;
    
    private void Start()
    {
        camera = Camera.main.transform;
    }

    public void Update()
    {
        if (!interacting)
            MoveCharacter();        
        else
            LookAtTarget(lookTarget);        
    }

    //Rotate the player to look at an object when interacting with it, Transform target = the object we want to focus on.
    public void LookAtTarget(Transform target)
    {//                       The object to look at   The object to rotate - the player
     //                                 |                     |
        Vector3 lookDirection = (target.position  -   transform.position).normalized; //The direction the player needs to look in with a magnitude (length) of 1.
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(lookDirection.x, 0f, lookDirection.z)); //We don't want the player to look up or down - y axis (not yet anyway).
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, 5f * Time.deltaTime); //Instead of snapping to a rotation we want to spherically interpolate with a certain speed.
    }//                                  |
     //Spherical interpolation = estimating values with known data points in 3D space (x, y, z). a W value is the scalar around the vector but we dont need this, nor do I know anything about it.

    void MoveCharacter()
    {//                               left/right        don't move up or down       forward/backwards
        input = new Vector3(Input.GetAxis("Horizontal"),         0f,           Input.GetAxis("Vertical"));//Returns a value of -1, 0 or 1 for its axis when the key is pressed and creates a new vector with these values.
        inputDirection = input.normalized;//The direction we wish to move in.

        //Prevents a division by 0. Only rotate when we move.
        if (inputDirection != Vector3.zero)
        {
            //Mathf.ATan2 contains functionality for when the x value is 0 and so throws the correct rotation and not a division by zero error.
            rotationTarget = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg + camera.eulerAngles.y;//Move forward in the direction the camera is looking. Eular angles uses degrees, where rotation is calculated in radians.
            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, rotationTarget, ref rotationVelocity, rotationSpeed);//Don't snap to a direction, rotate smoothly towards the new direction.
         //                                                                                                               |
         //                                                                                  No idea. Used within the function, we dont set this value ourselves.
        }

        speed = (Input.GetKey(KeyCode.LeftShift) ? 25f : 10f) * inputDirection.magnitude;
        
        transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);
    }
}
