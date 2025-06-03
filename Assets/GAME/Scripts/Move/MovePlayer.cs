using UnityEngine;
using UnityEngine.Serialization;

public class MovePlayer : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody _playerRigidbody;
    [SerializeField] private LayerMask _groundLayer;

    [FormerlySerializedAs("moveSpeed")]
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _friction ;
    [SerializeField] private float _jumpForce;

  
    [Header("Ground Check")]
    [SerializeField] private float _groundCheckDistance ;

    private CapsuleCollider _capsuleCollider;
    
    private IMovementStrategy movementStrategy;
    private IJumpStrategy jumpStrategy;

    private bool _isGrounded;
    private bool _jumpPressed;

    private void Awake()
    {
         movementStrategy = new HorizontalMovement();
         jumpStrategy = new PlayerJump();
        _capsuleCollider = GetComponent<CapsuleCollider>();
    }

    private void Update()
    {
        _jumpPressed = Input.GetButtonDown("Jump");
        _isGrounded = CheckGrounded();

        jumpStrategy.Jump(_playerRigidbody, _jumpForce, _isGrounded, _jumpPressed);
    }

    private void FixedUpdate()
    {
        movementStrategy.MovePlayer(_playerRigidbody, transform, _moveSpeed, _isGrounded);

        if (_isGrounded)
        {
            movementStrategy.ApplyFriction(_playerRigidbody, _friction);
        }
    }

    private bool CheckGrounded()
    {
        if (_capsuleCollider == null) return false;

        // Верхняя и нижняя точки капсулы (с учётом радиуса)
        float halfHeight = _capsuleCollider.height / 2f;
        float radius = _capsuleCollider.radius * 0.9f; // чтобы избежать ложных срабатываний

        // Точка сверху — чуть ниже верхней части капсулы
        Vector3 point1 = transform.position + Vector3.up * (halfHeight - radius);
    
        // Точка снизу — чуть ниже нижней части капсулы (добавим 0.05 проверим что касается земли)
        Vector3 point2 = transform.position + Vector3.down * (halfHeight - radius + 0.05f);

        // Проверка, пересекается ли визуал нашей капсулы с каким-либо коллайдером земли 
        return Physics.CheckCapsule(point1, point2, radius, _groundLayer, QueryTriggerInteraction.Ignore);
    }
    
    }


