using UnityEngine;
using UnityEngine.Serialization;


[System.Serializable]  
public class PlayerData
{
    
    
   [HideInInspector] public bool isGrounded;
   [HideInInspector] public bool jumpPressed;
   
   public float airControlPlayer = 0.5f;
       
   public Rigidbody playerRigidbody; 
   public Transform playerTransform;
   public CapsuleCollider playerCollider;
   
    public float moveSpeed;
    public float jumpForce;
    public LayerMask groundLayer;
   
}