using UnityEngine;

public class HorizontalMovement : IMovementStrategy
{
    public void Move(PlayerController player)
    {
        float moveInput = Input.GetAxis("Horizontal");
        Vector3 velocity = player.Rigidbody.linearVelocity;
        velocity.x = moveInput * player.MoveSpeed;
        player.Rigidbody.linearVelocity = velocity;

        if (player.IsGrounded)
        {
            Vector3 frictionForce = -new Vector3(velocity.x, 0, velocity.z) * player.Friction;
            player.Rigidbody.AddForce(frictionForce, ForceMode.Acceleration);
        }
    }
}