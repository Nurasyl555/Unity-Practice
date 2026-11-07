using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Wheel : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 90f;
    // Меняем ось на Vector3.up (поворот влево-вправо вокруг вертикали)
    [SerializeField] private Vector3 rotationAxis = Vector3.up;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        
        Quaternion deltaRotation = Quaternion.Euler(rotationAxis * (rotationSpeed * Time.fixedDeltaTime));

        
        rb.MoveRotation(rb.rotation * deltaRotation);
    }
}