using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    [SerializeField] private float _speed = 1.5f;
    [SerializeField] private int _healAmount = 1;

    private Player _player;

    private void Start()
    {
        _player = FindFirstObjectByType<Player>();
    }

    private void Update()
    {
        if (_player != null)
        {
            transform.up = _player.transform.position - transform.position;
        }

        transform.Translate(_speed * Time.deltaTime * Vector3.up, Space.Self);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.attachedRigidbody == null)
            return;

        var player = other.attachedRigidbody.GetComponent<Player>();
        if (player == null)
            return;

        player.Heal(_healAmount);
        Destroy(gameObject);
    }
}