using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset = new Vector3(0, 1, -5); // Khoảng cách giữa camera và player

    void LateUpdate()
    {
        transform.position = player.position + offset;
    }
}

