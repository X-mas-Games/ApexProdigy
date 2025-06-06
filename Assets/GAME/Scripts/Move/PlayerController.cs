using UnityEngine;


public class PlayerController
{
    public Rigidbody Rigidbody;
    public Transform Transform;
    public CapsuleCollider Collider;
    public bool IsGrounded;
    public bool JumpPressed;
    public float MoveSpeed;
    public float Friction;
    public float JumpForce;
}