using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float zOffset = 10.0f;

    void Update()
    {
        transform.position = new Vector3(target.position.x, transform.position.y, target.position.z + zOffset);
    }
}
