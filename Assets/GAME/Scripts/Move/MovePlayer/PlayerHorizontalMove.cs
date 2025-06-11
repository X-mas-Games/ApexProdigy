
using UnityEngine;

public class PlayerHorizontalMove : IMoveStrategy
{
    public void MovePlayer(PlayerData data, float horizontalInput)
    {
        float currentSpeed = data.isGrounded
            ? data.moveSpeed
            : data.moveSpeed * data.airControlPlayer;

        Vector3 move = new Vector3(horizontalInput, 0, 0);
        data.playerRigidbody.linearVelocity = new Vector3(move.x * currentSpeed, data.playerRigidbody.linearVelocity.y, data.playerRigidbody.linearVelocity.z);

    }
}





