using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float _speed;
    
    private void Update()
    {
        transform.Translate(_speed * Time.deltaTime * Vector3.up, Space.Self);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.attachedRigidbody == null)
            return;

        var enemy = other.attachedRigidbody.GetComponent<Enemy>();
        if (enemy == null)
            return;
        
        enemy.TakeDamage(1);
    }
}
