using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player : Entity
{
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _projectile;
    [SerializeField] private float _projectileSpawnDistance;
    [SerializeField] private InputActionReference _moveAction;
    [SerializeField] private InputActionReference _shootAction;


    private void OnEnable()
    {
        if (_moveAction != null) _moveAction.action.Enable();
        if (_shootAction != null) _shootAction.action.Enable();
    }
    private void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        // Turn
        var turnInput = _moveAction.action.ReadValue<Vector2>().x;
        transform.Rotate(0, 0, -turnInput * _speed * Time.deltaTime);

        // Shoot
        if (_shootAction.action.WasPressedThisFrame())
        {
            Instantiate(
                _projectile,
                transform.position + transform.up * _projectileSpawnDistance,
                transform.rotation
            );
        }
    }

    protected override void Die()
    {
        SceneManager.LoadScene(0);
    }
}
