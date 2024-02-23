using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private Vector3 cameraOffset = new(0, 2.2f, -7.5f);

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new(-230, 2.2f, player.transform.position.z + cameraOffset.z); // (player.transform.position.z) player.transform.position + cameraOffset;
    }
}
