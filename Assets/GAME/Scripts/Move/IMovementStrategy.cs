using UnityEngine;

public interface IMovementStrategy 
{
    void MovePlayer (Rigidbody playerRigidbody, Transform transform, float moveSpeed, bool isGrounded);
    void ApplyFriction( Rigidbody playerRigidbody, float friction);
}
