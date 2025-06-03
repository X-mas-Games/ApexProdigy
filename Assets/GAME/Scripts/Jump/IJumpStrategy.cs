using UnityEngine;

public interface IJumpStrategy
{
    void Jump (Rigidbody playerRigidbody, float jumpForce, bool isGrounded, bool jumpPressed);
}