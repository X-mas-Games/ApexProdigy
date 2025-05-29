using UnityEngine;

public class PlayerJump : IJumpStrategy 
{
    public void Jump(Rigidbody playerRigidbody, float jumpForce, bool isGrounded)
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Vector3 jump = Vector3.up * jumpForce;
            playerRigidbody.AddForce(jump, ForceMode.Impulse);
        }
    }
}