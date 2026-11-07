using UnityEngine;

/// <summary>
/// Controls and rotates the clock hand.
/// </summary>
public class ClockHand : MonoBehaviour
{
    [SerializeField, Tooltip("Time in seconds in which hand does full circle")] 
    private float _period;

    private void Update()
    {
        if (_period != 0)
            transform.Rotate(new Vector3(0, 0, -360 / _period * Time.deltaTime));
    }
}
