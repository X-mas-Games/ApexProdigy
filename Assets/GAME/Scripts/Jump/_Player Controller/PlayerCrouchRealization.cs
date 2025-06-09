using UnityEngine;

public class PlayerCrouchRealization : IJumpStrategy, ICrouchStrategy
{
    public void JumpPlayer(PlayerController controller)
    {
        if (controller.jumpPressed && controller.isGrounded)
        {
            controller.rb.AddForce(Vector3.up * controller.jumpForce, ForceMode.Impulse);
        }
    }

    public void CrouchPlayer(PlayerController controller, bool isCrouching)
    {
        Vector3 targetScale = isCrouching || !controller.isGrounded
            ? new Vector3(1, 0.5f, 1)
            : new Vector3(1, 1, 1);

        controller.transform.localScale = Vector3.Lerp(controller.transform.localScale, targetScale, Time.deltaTime * 15f);
    }
}