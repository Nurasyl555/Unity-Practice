using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float _innerRadius;
    [SerializeField] private float _outerRadius;
    [SerializeField] private GameObject _enemy;

    [SerializeField] private Player _player;
    [SerializeField] private float _spawnInterval;

    private float _time;
    
    private void Update()
    {
        _time += Time.deltaTime;
        if (_time > _spawnInterval)
        {
            _time = 0;
            var enemy = Instantiate(_enemy, GetRandomPosition(), Quaternion.identity);
            enemy.transform.up = _player.transform.position - enemy.transform.position;
        }
    }

    private Vector3 GetRandomPosition()
    {
        var randomDistance = Random.Range(_innerRadius, _outerRadius);
        var randomAngle = Random.Range(0, 360);

        var rotation = Quaternion.AngleAxis(randomAngle, Vector3.forward);
        var randomPosition = rotation * Vector3.up * randomDistance;
        return randomPosition;
    }
}
