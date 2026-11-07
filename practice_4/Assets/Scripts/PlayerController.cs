using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveForce = 10;
    [SerializeField] private float _jumpForce = 10;
    [SerializeField] private InputActionReference _moveAction;
    [SerializeField] private InputActionReference _jumpAction;

    private Rigidbody _rigidbody;
    private bool _isGrounded;

    private Vector2 _inputVector;
    private bool _isJumpRequested;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        HandleInput();
    }

    void FixedUpdate()
    {
        CheckGround();

        Move();
        
        if (_isJumpRequested)
        {
            if (_isGrounded) Jump();
            _isJumpRequested = false;
        }
    }

    private void HandleInput()
    {
        _inputVector = _moveAction.action.ReadValue<Vector2>();
        
        if (_jumpAction.action.WasPerformedThisFrame())
            _isJumpRequested = true;
    }

    private void Move()
    {
        _rigidbody.AddForce(new Vector3(_inputVector.x, 0, _inputVector.y) * _moveForce);
    }

    private void Jump()
    {
        _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.VelocityChange);
    }

    private void CheckGround()
    {
        Ray ray = new Ray(transform.position + Vector3.up * 0.01f, Vector3.down);
        _isGrounded = Physics.SphereCast(ray, 0.5f, 0.05f);
    }
}