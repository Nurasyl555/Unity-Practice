using UnityEngine;
using UnityEngine.InputSystem;

public class CowboyDuelManager : MonoBehaviour
{
    [SerializeField] private float _timeUntilHighNoon = 3f;
    [SerializeField] private float _opponentReactionTime = 1f;

    private bool _isGameEnded;
    private bool _isHighNoon;

    private void Start()
    {
        Debug.Log("Get ready for the duel! Wait for High Noon...");
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
