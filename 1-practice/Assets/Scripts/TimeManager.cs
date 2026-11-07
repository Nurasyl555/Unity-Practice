using UnityEngine;

/// <summary>
/// Controls timescale of the game. Only 1 instance should exist during the game
/// </summary>
public class TimeManager : MonoBehaviour
{
    [SerializeField, Tooltip("Time scale of the game. Increase it to make the game run faster (up to 100)")] 
    private float _timeScale = 1;

    private void OnValidate()
    {
        Time.timeScale = _timeScale;
    }

    private void Awake()
    {
        Time.timeScale = _timeScale;
    }
}
