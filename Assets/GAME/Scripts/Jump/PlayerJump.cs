using UnityEngine;

public class PlayerJump : IJumpStrategy
{
    public void JumpPlayer (PlayerController controller)
    {
        if (controller.JumpPressed && controller.IsGrounded)
        {
            controller.Rigidbody.AddForce(Vector3.up * controller.JumpForce, ForceMode.Impulse);
        }
    }
    
    

    public void CrouchPlayer (PlayerController controller)
    {
        bool crouching = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.S) || !controller.IsGrounded;

        Vector3 targetScale = crouching ? new Vector3(1, 0.5f, 1) : new Vector3(1, 1, 1);
        controller.Transform.localScale = Vector3.Lerp(controller.Transform.localScale, targetScale, Time.deltaTime * 15);
    }
}