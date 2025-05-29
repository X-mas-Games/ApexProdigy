using UnityEngine;
[CreateAssetMenu(fileName = "PlayerMovementConfig", menuName = "Configs/Movement")]

public class MovementConfig :  ScriptableObject

{
    public  float  _moveSpeed ;
    public  float  _friction;
    public float  _jumpForce;
}

