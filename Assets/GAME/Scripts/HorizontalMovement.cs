using UnityEngine;

public class HorizontalMovement :  IMovementStrategy


{
    public void MovePlayer (Rigidbody playerRigidbody, Transform transform, float moveSpeed)
    {
        float input = Input.GetAxis("Horizontal");
        Vector3 force = input * moveSpeed * transform.right;
        playerRigidbody.AddForce(force, ForceMode.VelocityChange);
    }

    public void ApplyFriction (Rigidbody playerRigidbody, float friction)
    {
        Vector3 frictionForce = new Vector3(-playerRigidbody.linearVelocity.x * friction, 0f, 0f);
        playerRigidbody.AddForce(frictionForce, ForceMode.Acceleration);
    }
}
