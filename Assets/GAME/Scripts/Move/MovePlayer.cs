using System;
using UnityEngine;
using UnityEngine.Serialization;

public class MovePlayer : MonoBehaviour
{
    
    [SerializeField] private Rigidbody _playerRigidbody;
    [SerializeField] private bool _isGrounded;
    [SerializeField] private float groundCheckDistance = 1.1f; 
    [SerializeField] private LayerMask groundLayer;
    
    [SerializeField] private MovementConfig movementConfig;

    private IMovementStrategy movementStrategy;
    private PlayerJump jumpStrategy;

    private void Awake()
    {
        movementStrategy = new HorizontalMovement();
        jumpStrategy = new PlayerJump();
    }

    private void Update()
    {
        jumpStrategy.Jump(_playerRigidbody, movementConfig._jumpForce, _isGrounded);
        _isGrounded = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, groundLayer);
    }

    private void FixedUpdate()
    {
        movementStrategy.MovePlayer(_playerRigidbody, transform, movementConfig._moveSpeed, _isGrounded);
    
        if (_isGrounded)
        {
            movementStrategy.ApplyFriction(_playerRigidbody, movementConfig._friction);
        }
    }

}
