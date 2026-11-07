using UnityEngine;

public class Broom : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private float distance = 2f;
    [SerializeField] private Vector3 moveDirection = Vector3.right;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.localPosition;
    }

    void Update()
    {
        float offset = Mathf.Sin(Time.time * speed) * distance;
        transform.localPosition = startPosition + moveDirection * offset;
    }
}