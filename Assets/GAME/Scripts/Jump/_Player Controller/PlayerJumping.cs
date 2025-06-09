using UnityEngine;

public class PlayerJumping : MonoBehaviour
{
    private ICrouchStrategy crouchStrategy;
    private IJumpStrategy jumpStrategy;
    public PlayerController controller;

    private void Awake()
    {
        controller.rb = GetComponent<Rigidbody>();
        controller.capsule = GetComponent<CapsuleCollider>();
        controller.transform = GetComponent<Transform>();
        
        jumpStrategy  =   new PlayerCrouchRealization();
        crouchStrategy = new PlayerCrouchRealization();
    }

    private void Update()
    {
        controller.jumpPressed = Input.GetButtonDown("Jump");
        controller.isGrounded = CheckGrounded();
        bool isCrouching = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.S);
        
        crouchStrategy.CrouchPlayer(controller, isCrouching);
        jumpStrategy.JumpPlayer(controller);
       
        
      
    }

    private bool CheckGrounded()
    {
        float radius = controller.capsule.radius * 0.9f;
        float halfHeight = controller.capsule.height / 2f;
        Vector3 point1 = transform.position + Vector3.up * (halfHeight - radius);
        Vector3 point2 = transform.position + Vector3.down * (halfHeight - radius + 0.05f);
        return Physics.CheckCapsule(point1, point2, radius, controller.groundLayer, QueryTriggerInteraction.Ignore);
    }
}