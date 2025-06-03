using UnityEngine;

public class PlayerJump : IJumpStrategy
{
    public void Jump(Rigidbody playerRigidbody, float jumpForce, bool isGrounded, bool jumpPressed)
    {
        if (jumpPressed && isGrounded)
        {
          
            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}