using UnityEngine;

public class PlayerMovement
{
    Vector3 direction;

    public float speed = 10f;

    public void MovePlayer(Rigidbody rb)
    {
        direction = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
    }
}
