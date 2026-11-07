using UnityEngine;
using UnityEngine.InputSystem;

public class CowboyDuelManager : MonoBehaviour
{
    [Header("Wait Time Settings")]
    [SerializeField] private float _minWaitTime = 1f;
    [SerializeField] private float _maxWaitTime = 5f;

    [Header("Opponent Reaction Settings")]
    [SerializeField] private float _minReactionTime = 0.2f;
    [SerializeField] private float _maxReactionTime = 0.8f;

    private float _timeUntilHighNoon;
    private float _opponentReactionTime;

    private bool _isGameEnded;
    private bool _isHighNoon;

    private void Start()
    {
        // Генерация случайных значений времени через Unity API (Random.Range)
        _timeUntilHighNoon = Random.Range(_minWaitTime, _maxWaitTime);
        _opponentReactionTime = Random.Range(_minReactionTime, _maxReactionTime);

        Debug.Log($"Get ready for the duel! Wait for High Noon... (Wait: {_timeUntilHighNoon:F2}s, Reaction: {_opponentReactionTime:F2}s)");
        Invoke(nameof(StartHighNoon), _timeUntilHighNoon);
    }

    private void Update()
    {
        if (_isGameEnded)
            return;

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        if (_isHighNoon)
            Win();
        else
        {
            _isGameEnded = true;
            Debug.Log("You shot too early! You lost your reputation!");
        }
    }

    private void Win()
    {
        _isGameEnded = true;
        Debug.Log("You shot first! You win the duel!");
    }

    private void StartHighNoon()
    {
        if (_isGameEnded)
            return;

        Debug.Log("High Noon! Draw your weapon!");

        _isHighNoon = true;
        Invoke(nameof(OpponentShoot), _opponentReactionTime);
    }

    private void OpponentShoot()
    {
        if (_isGameEnded)
            return;

        _isGameEnded = true;
        Debug.Log("Opponent shoots! You lose!");
    }
}