using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    public float speed = 0f;
    void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.forward);
    }

    public void ChangeSpeed(float targetSpeed)
    {
        speed = targetSpeed;
    }
}
