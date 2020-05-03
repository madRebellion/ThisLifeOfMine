using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Vector3 input, inputDirection;
    Transform camera;

    public Animator anim;

    float rotationTarget;
    float rotationVelocity;
    float rotationSpeed = 0.1f;
    float speed;
    
    public float animationTime = 10f;
    public int prevSeed, seed;
    
    private void Awake()
    {
        camera = Camera.main.transform;
        anim = GetComponentInChildren<Animator>();
    }

    public void MoveCharacter()
    {
        input = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        inputDirection = input.normalized;

        //Prevents a division by 0. Only rotate when we move.
        if (inputDirection != Vector3.zero)
        {
            //Mathf.ATan2 contains functionality for when the x value is 0 and so throws the correct rotation and not a division by zero error.
            rotationTarget = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg + camera.eulerAngles.y;
            //Don't snap to a direction, rotate smoothly towards the new direction.
            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, rotationTarget, ref rotationVelocity, rotationSpeed);

        }

        speed = (Input.GetKey(KeyCode.LeftShift) ? 6f : 1.8f) * inputDirection.magnitude;

        transform.position += transform.forward * speed * Time.deltaTime;
        //transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);

        float animSpeed = (Input.GetKey(KeyCode.LeftShift) ? 1f : 0.5f) * inputDirection.magnitude;
        anim.SetFloat("Speed", animSpeed, 0.1f, Time.deltaTime);

        if (animSpeed < 0.1f && !HUDManager.instance.isInteracting)
        {
            IdleAnimationsController();
        }else
        {
            seed = 0;
            animationTime = 8f;
        }
    }

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

}
