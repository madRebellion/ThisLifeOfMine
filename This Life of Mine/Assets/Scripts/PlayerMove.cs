using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Vector3 input, inputDirection;
    Transform camera;
    public Transform lookTarget;

    Animator anim;

    float rotationTarget;
    float rotationVelocity;
    float rotationSpeed = 0.1f;
    float speed;

    public bool inRange = false;

    private void Awake()
    {
        camera = Camera.main.transform;
        anim = GetComponentInChildren<Animator>();
    }

    //private void Update()
    //{
    //    if (inRange && Input.GetKeyDown(KeyCode.E))
    //    {
    //        lookTarget.GetComponent<DialogueNPC>().StartDialogue();
    //        LookAtTarget(lookTarget);
    //    }
    //    else
    //    {
    //        MoveCharacter();
    //    }
    //}

    //Rotate the player to look at an object when interacting with it.
    public void LookAtTarget(Transform target)
    {
        Vector3 lookDirection = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(lookDirection.x, 0f, lookDirection.z));
        //Instead of snapping to a rotation we want to spherically interpolate with a certain speed.
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, 5f * Time.deltaTime);
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

        speed = (Input.GetKey(KeyCode.LeftShift) ? 6f : 2f) * inputDirection.magnitude;

        transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);

        float animSpeed = (Input.GetKey(KeyCode.LeftShift) ? 1f : 0.5f) * inputDirection.magnitude;
        anim.SetFloat("Speed", animSpeed, 0.1f, Time.deltaTime);
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "NPC / Dialogue")
    //    {
    //        Debug.Log(other.gameObject.name);
    //        DialogueManager.Instance.talkPrompt.SetActive(true);
    //        lookTarget = other.gameObject.transform;
    //        inRange = true;
    //        other.gameObject.GetComponent<DialogueNPC>().CollectDialogue();
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.tag == "NPC / Dialogue")
    //    {
    //        DialogueManager.Instance.talkPrompt.SetActive(false);
    //        lookTarget = null;
    //        inRange = false;
    //    }
    //}
}
