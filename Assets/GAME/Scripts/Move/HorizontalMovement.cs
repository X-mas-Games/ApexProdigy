using UnityEngine;

public class HorizontalMovement : IMovementStrategy
{
    public void MovePlayer(Rigidbody playerRigidbody, Transform transform, float moveSpeed, bool isGrounded)
    {
        float input = Input.GetAxis("Horizontal");
        float speedMultiplier = isGrounded ? 1f : 0.2f;
        Vector3 force = input * moveSpeed * speedMultiplier * transform.right;

        playerRigidbody.AddForce(force, ForceMode.VelocityChange);
    }

    public void ApplyFriction(Rigidbody playerRigidbody, float friction)
    {
        Vector3 frictionForce = new Vector3(-playerRigidbody.linearVelocity.x * friction, 0f, 0f);
        playerRigidbody.AddForce(frictionForce, ForceMode.Acceleration);
    }
}