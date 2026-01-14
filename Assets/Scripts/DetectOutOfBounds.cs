using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectOutOfBounds : MonoBehaviour
{
    public float leftBoundary = -242f;
    public float rightBoundary = -216f;

    public float finishLine = 1000f;
    public float despawnBoundZCoord = 1200f;

    void Update()
    {
        if (!gameObject.CompareTag("NPC")) // handle player out of bounds
        {
            if (transform.position.x < leftBoundary)
            {
                Debug.Log($"GAME OVER! {leftBoundary}");
            }

            if (transform.position.x > rightBoundary)
            {
                Debug.Log($"GAME OVER! {rightBoundary}");
            }

            if (transform.position.z > finishLine)
            {
                Debug.Log("You win!");
            }
        }
        else // handle NPC out of bounds
        {
            if (transform.position.z >= despawnBoundZCoord)
            {
                Debug.Log($"Removing {gameObject.name}");
                Destroy(gameObject);
            }
        }
    }
}
