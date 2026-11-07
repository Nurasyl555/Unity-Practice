using UnityEngine;

public class Finish : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody == null)
            return;
        
        if (other.attachedRigidbody.GetComponent<Player>() != null)
        {
            Debug.Log("Win!");
            Time.timeScale = 0;
        }
    }
}
