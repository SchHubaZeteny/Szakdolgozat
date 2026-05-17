using System;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset = new Vector3(0, 0, -30);
    private float smoothSpeed = 0.125f;

    void FixedUpdate()
    {
        Vector3 playerPosition = player.transform.position + offset;

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, playerPosition, smoothSpeed);

        transform.position = smoothedPosition;
    }
}
