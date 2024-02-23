using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"{other.name} collision with {transform.name}");
        
        if (other.CompareTag("NPC"))
        {
            float thisSpeed = transform.GetComponentInParent<NPCController>().speed;
            float otherSpeed = other.attachedRigidbody.GetComponentInParent<NPCController>().speed;

            Debug.Log($"NPCs about to collide, reducing speed; this: {thisSpeed}, other: {otherSpeed}");

            if (thisSpeed > otherSpeed)
            {
                transform.GetComponentInParent<NPCController>().ChangeSpeed(otherSpeed);
            }
        }
    }
}
