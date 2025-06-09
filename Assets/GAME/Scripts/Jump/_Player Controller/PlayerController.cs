using UnityEngine;
using UnityEngine.Serialization;

[System.Serializable]  
public class PlayerController
{
    
   [HideInInspector] public bool isGrounded;
   [HideInInspector] public bool jumpPressed;

    public Rigidbody rb;
    public Transform transform;
    public CapsuleCollider capsule;
    
    public float jumpForce;
    public LayerMask groundLayer;
   
}