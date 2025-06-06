using UnityEngine;
using UnityEngine.Serialization;

public class MovePlayer : MonoBehaviour
{
    
    [Header("References")]
    [SerializeField] private Rigidbody _playerRigidbody; 
    [SerializeField] private LayerMask _groundLayer;

    
    [Header("Settings")]
    [SerializeField] private float _moveSpeed = 5f; 
    [SerializeField] private float _jumpForce = 5f; 
    [SerializeField] private float _friction = 0.5f;

    private IJumpStrategy jumpStrategy;
    private IMovementStrategy movementStrategy;
    private CapsuleCollider capsuleCollider;
    private PlayerController _controller;

    private void Awake()
    {
        capsuleCollider = GetComponent<CapsuleCollider>();

        jumpStrategy = new PlayerJump();
        movementStrategy = new HorizontalMovement();

        _controller = new PlayerController
        {
            Rigidbody = _playerRigidbody,
            Transform = transform,
            Collider = capsuleCollider,
            MoveSpeed = _moveSpeed,
            JumpForce = _jumpForce,
            Friction = _friction
        };
    }

    private void Update()
    {
        _controller.JumpPressed = Input.GetButtonDown("Jump");
        _controller.IsGrounded = CheckGrounded();

        jumpStrategy.JumpPlayer(_controller);
        jumpStrategy.CrouchPlayer(_controller);
    }

    private void FixedUpdate()
    {
        movementStrategy.Move(_controller);
    }

    private bool CheckGrounded()
    {
        if (capsuleCollider == null) return false;

        float halfHeight = capsuleCollider.height / 2f;
        float radius = capsuleCollider.radius * 0.9f;
        Vector3 point1 = transform.position + Vector3.up * (halfHeight - radius);
        Vector3 point2 = transform.position + Vector3.down * (halfHeight - radius + 0.05f);

        return Physics.CheckCapsule(point1, point2, radius, _groundLayer, QueryTriggerInteraction.Ignore);
    }
}