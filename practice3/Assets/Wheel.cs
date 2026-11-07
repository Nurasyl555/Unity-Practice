using UnityEngine;

public class Wheel : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 90f;
    [SerializeField] private Vector3 rotationAxis = Vector3.right;

    void Update()
    {
        transform.Rotate(rotationAxis * (rotationSpeed * Time.deltaTime));
    }
}