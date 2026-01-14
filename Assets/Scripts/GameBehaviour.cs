using UnityEngine;

public class GameBehaviour : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {        
        if (other.CompareTag("NPC"))
        {
            // Debug.Log($"{other.name} collision with {transform.name}");
            float thisSpeed = transform.GetComponentInParent<NPCController>().speed;
            float otherSpeed = other.attachedRigidbody.GetComponentInParent<NPCController>().speed;

            if (thisSpeed > otherSpeed)
            {
                transform.GetComponentInParent<NPCController>().ChangeSpeed(otherSpeed);
            }
        }
    }
}
