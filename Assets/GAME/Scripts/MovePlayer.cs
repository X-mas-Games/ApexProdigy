using System;
using UnityEngine;
using UnityEngine.Serialization;

public class MovePlayer : MonoBehaviour
{
    [Header("PlayerMovement")]
    [SerializeField]  private  Rigidbody _playerRigidbody;
    [SerializeField]  private  float _moveSpeed ;
    [SerializeField]  private  float _frictionMove;

    private IMovementStrategy movementStrategy;
    
    private void Awake()
    {
        movementStrategy = new HorizontalMovement();

    }

    
    
    private void FixedUpdate()
    {
        movementStrategy.MovePlayer(_playerRigidbody, transform, _moveSpeed);
        movementStrategy.ApplyFriction(_playerRigidbody, _frictionMove);
    }

    
}