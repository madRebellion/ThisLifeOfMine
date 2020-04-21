using UnityEngine;

[RequireComponent(typeof(PlayerMove))]
public class Player : MonoBehaviour
{
    public TPCamera cam;
    public Interactable target;

    PlayerMove player;
    
    private void Start()
    {
        player = GetComponent<PlayerMove>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameStateManager.instance.isPaused = !GameStateManager.instance.isPaused;
            GameStateManager.instance.PauseGame();
        }
        if (target != null && Input.GetKeyDown(KeyCode.E))
        {
            target.Interact();
        }
        else
        {
            player.MoveCharacter();
        }
    }

    //void SelectTarget(Interactable _target)
    //{
    //    if (_target != target)
    //    {
    //        if (target != null)
    //            target.Defocus();

    //        target = _target;
    //    }

    //    _target.OnFocused(transform);
    //}
   
    void DeselectTarget()
    {
        if (target != null)
            target.Defocus();
        target = null;
    }

    void CalculateObjectIdentity(GameObject objectToIdentify)
    {
        switch (objectToIdentify)
        {
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Interactable>())
            target = other.GetComponent<Interactable>();

        if (other.tag == "NPC / Dialogue")
        {
            Debug.Log(other.gameObject.name);
            DialogueManager.Instance.talkPrompt.SetActive(true);
            player.lookTarget = other.gameObject.transform;
            other.gameObject.GetComponent<DialogueNPC>().CollectDialogue();
        }
        else if (other.tag == "Item")
        {
            Debug.Log(target.ObjectType);
            target.OnFocused(transform);
            player.lookTarget = other.gameObject.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "NPC / Dialogue")
        {
            DialogueManager.Instance.talkPrompt.SetActive(false);
            player.lookTarget = null;
        }
        target = null;
    }
    public void ConvertPosition(float[] pos)
    {
        Vector3 position;
        position.x = pos[0];
        position.y = pos[1];
        position.z = pos[2];
        transform.position = position;
    }

    public void ConvertRotation(float[] rot)
    {
        Vector3 playerRot;
        playerRot.x = rot[0];
        playerRot.y = rot[1];
        playerRot.z = rot[2];
        transform.eulerAngles = playerRot;
    }

}
