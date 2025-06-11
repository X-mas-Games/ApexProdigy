
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    private ICrouchStrategy crouchStrategy;
    private IJumpStrategy  jumpStrategy;
    private IMoveStrategy  moveStrategy;

    public PlayerData data;

    private void Awake()
    {
        data.playerRigidbody = GetComponent<Rigidbody>();
        data.playerCollider  = GetComponent<CapsuleCollider>();
        data.playerTransform = GetComponent<Transform>();

        var crouchJumpRealization = new PlayerCrouchRealization();
        jumpStrategy   = crouchJumpRealization;
        crouchStrategy = crouchJumpRealization;

        moveStrategy = new PlayerHorizontalMove();
    }

    private void Update()
    {
        data.jumpPressed = Input.GetButtonDown("Jump");
        data.isGrounded  = CheckGrounded();
        
        float horizontalInput = Input.GetAxis("Horizontal");
        bool isCrouching = Input.GetKey(KeyCode.LeftShift);
        
        jumpStrategy.JumpPlayer(data);
        crouchStrategy.CrouchPlayer(data, isCrouching);
        moveStrategy.MovePlayer(data, horizontalInput);
    }

    private bool CheckGrounded()
    {
        float radius = data.playerCollider.radius * 0.9f;
        float halfHeight = data.playerCollider.height / 2f;
        Vector3 point1 = transform.position + Vector3.up * (halfHeight - radius);
        Vector3 point2 = transform.position + Vector3.down * (halfHeight - radius + 0.05f);
        return Physics.CheckCapsule(point1, point2, radius, data.groundLayer, QueryTriggerInteraction.Ignore);
    }
}