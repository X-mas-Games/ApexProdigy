using UnityEngine;

public interface IMovementStrategy 
{
  public  void MovePlayer     (Rigidbody playerRigidbody, Transform transform, float moveSpeed);
  public  void ApplyFriction  (Rigidbody playerRigidbody, float friction);
  
  
  
}





