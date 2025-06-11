using UnityEngine;

public class PlayerCrouchRealization : IJumpStrategy, ICrouchStrategy
{
    public void JumpPlayer(PlayerData data)
    {
        if (data.jumpPressed && data.isGrounded)
        {
            data.playerRigidbody.AddForce(Vector3.up * data.jumpForce, ForceMode.Impulse);
        }
    }

    public void CrouchPlayer(PlayerData data, bool isCrouching)
    {
        Vector3 targetScale = isCrouching || !data.isGrounded
            ? new Vector3(1, 0.5f, 1)
            : new Vector3(1, 1, 1);

        data.playerTransform.localScale = Vector3.Lerp(data.playerTransform.localScale, targetScale, Time.deltaTime * 15f);
    }
}