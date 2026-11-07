using UnityEngine;

public class Enemy : Entity
{
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _healthPickupPrefab;
    [SerializeField, Range(0f, 1f)] private float _dropChance = 0.5f; // 50% шанс

    private void Update()
    {
        transform.Translate(_speed * Time.deltaTime * Vector3.up, Space.Self);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.attachedRigidbody == null)
            return;

        var player = other.attachedRigidbody.GetComponent<Player>();
        if (player == null)
            return;

        player.TakeDamage(1);
        Destroy(gameObject);
    }
    protected override void Die()
    {
        if (_healthPickupPrefab != null && Random.value <= _dropChance)
        {
            var pickup = Instantiate(_healthPickupPrefab, transform.position, Quaternion.identity);

            
            var player = FindFirstObjectByType<Player>();
            if (player != null)
            {
                pickup.transform.up = player.transform.position - pickup.transform.position;
            }
        }

        
        base.Die();
    }
}