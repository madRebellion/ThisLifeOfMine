using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Vector3 input, inputDirection;
    Transform camera;

    public Animator anim;
    
    public Rigidbody characterController;

    float rotationTarget;
    float rotationVelocity;
    float rotationSpeed = 0.1f;
    float speed;
    float velocityY;
    float distance;

    public bool airbourne;

    public float jumpHeight = 1.5f;
    public float animationTime = 10f;
    public int prevSeed, seed;
    public float gravity = -12f;

    public float walkSpeed = 1.6f;
    public float runSpeed = 10f;
    
    private void Awake()
    {
        camera = Camera.main.transform;
        anim = GetComponentInChildren<Animator>();
        characterController = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //if (!characterController.isGrounded)
        //{
        //    airbourne = true;
        //    anim.SetBool("Airbourne", airbourne);
        //}
        //else
        //{
        //    airbourne = false;
        //    anim.SetBool("Airbourne", airbourne);
        //    anim.SetBool("Jump", false);
        //}

        FindGround();
    }

    public void Jump()
    {
        //if (characterController.isGrounded)
        //{
            float jumpVel = Mathf.Sqrt(-2f * gravity * jumpHeight);
            velocityY = jumpVel;            
        //}
        
        characterController.AddForce(Vector3.up * 1000f, ForceMode.Force);
        
    }

    void FindGround()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity))
        {            
            distance = Vector3.Distance(transform.position, hit.point);           
        }
    }


    // Input and animation control
    public void Move()
    {
        input = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        inputDirection = input.normalized;

        //Prevents a division by 0. Only rotate when we move.
        if (inputDirection != Vector3.zero)
        {
            //Mathf.ATan2 contains functionality for when the x value is 0 and so throws the correct rotation and not a division by zero error.
            rotationTarget = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg + camera.eulerAngles.y;
            //Don't snap to a direction, rotate smoothly towards the new direction.
            //transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, rotationTarget, ref rotationVelocity, rotationSpeed);
            Vector3 rbRotation = Vector3.up * Mathf.SmoothDampAngle(/*transform.eulerAngles.y*/characterController.rotation.eulerAngles.y, rotationTarget, ref rotationVelocity, rotationSpeed);
            characterController.rotation = Quaternion.Euler(rbRotation);
            //characterController.velocity = transform.forward * speed * Time.deltaTime;
            //characterController.MovePosition(transform.position * speed * Time.deltaTime);
            //characterController.position += transform.forward * speed * Time.deltaTime;
        }

        speed = (Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed) * inputDirection.magnitude;

        //velocityY += Time.deltaTime * gravity;

        //Vector3 velocity = transform.forward * speed + Vector3.up * velocityY;

        //characterController.Move(velocity * Time.deltaTime);
        //characterController.Move(transform.forward * speed * Time.deltaTime);

        //characterController.MovePosition(transform.forward * speed * Time.fixedDeltaTime);

        characterController.velocity = (transform.forward * speed * Time.fixedDeltaTime) * inputDirection.magnitude;

        //speed = new Vector2(characterController.velocity.x, characterController.velocity.z).magnitude;

        //if (characterController.isGrounded)
        //{
        //    velocityY = 0f;
        //}

        float animSpeed = (Input.GetKey(KeyCode.LeftShift) ? 1f : 0.5f) * inputDirection.magnitude;
        anim.SetFloat("Speed", animSpeed, 0.1f, Time.deltaTime);

        if (animSpeed < 0.1f && !HUDManager.instance.isInteracting)
        {
            IdleAnimationsController();
        }
        else
        {
            seed = 0;
            animationTime = 8f;
        }
    }

    // Rigidbody movement
    //public void RbMove()
    //{
    //    if (inputDirection != Vector3.zero && !HUDManager.instance.isInteracting)
    //    {
    //        //Mathf.ATan2 contains functionality for when the x value is 0 and so throws the correct rotation and not a division by zero error.
    //        rotationTarget = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg + camera.eulerAngles.y;
    //        //Don't snap to a direction, rotate smoothly towards the new direction.
    //        transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, rotationTarget, ref rotationVelocity, rotationSpeed);
    //        rbRotation = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, rotationTarget, ref rotationVelocity, rotationSpeed);
    //        rb.rotation = Quaternion.Euler(rbRotation);
    //        rb.MovePosition(input * speed * Time.fixedDeltaTime);
    //        rb.position += transform.forward * speed * Time.deltaTime;
    //    }
    //}

    void IdleAnimationsController()
    {
        animationTime -= 1f * Time.deltaTime;

        if (animationTime <= 0)
        {
            prevSeed = seed;
            seed = Random.Range(0, 3);
            animationTime = Random.Range(5f, 15f);
        }

        anim.SetFloat("IdleSeed", seed, 0.2f, Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * 0.3f);
    }

}

//Old Movement using transform
//input = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
//inputDirection = input.normalized;

////Prevents a division by 0. Only rotate when we move.
//if (inputDirection != Vector3.zero)
//{
//    //Mathf.ATan2 contains functionality for when the x value is 0 and so throws the correct rotation and not a division by zero error.
//    rotationTarget = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg + camera.eulerAngles.y;
//    //Don't snap to a direction, rotate smoothly towards the new direction.
//    transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, rotationTarget, ref rotationVelocity, rotationSpeed);
//}

//speed = (Input.GetKey(KeyCode.LeftShift) ? 6f : 1.8f) * inputDirection.magnitude;

//transform.position += transform.forward * speed * Time.deltaTime;

//float animSpeed = (Input.GetKey(KeyCode.LeftShift) ? 1f : 0.5f) * inputDirection.magnitude;
//anim.SetFloat("Speed", animSpeed, 0.1f, Time.deltaTime);

//if (animSpeed < 0.1f && !HUDManager.instance.isInteracting)
//{
//    IdleAnimationsController();
//}else
//{
//    seed = 0;
//    animationTime = 8f;
//}
