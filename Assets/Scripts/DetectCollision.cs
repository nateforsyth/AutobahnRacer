using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Debug.Log($"{other.name} collision with {transform.name}");
    }
}
