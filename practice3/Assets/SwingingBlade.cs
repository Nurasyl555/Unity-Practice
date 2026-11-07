using UnityEngine;

public class SwingingBlade : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private float maxAngle = 45f;
    [SerializeField] private Vector3 swingAxis = Vector3.forward;

    private Quaternion initialRotation;

    void Start()
    {
        initialRotation = transform.localRotation;
    }

    void Update()
    {
        float angle = Mathf.Sin(Time.time * speed) * maxAngle;
        transform.localRotation = initialRotation * Quaternion.AngleAxis(angle, swingAxis);
    }
}