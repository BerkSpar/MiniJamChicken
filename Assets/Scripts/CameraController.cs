using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;

    void Start () 
    {
        offset = transform.position - player.transform.position;
    }

    void LateUpdate () 
    {
        transform.position = player.transform.position + offset;
        // transform.position = Vector3.SmoothDamp(transform.position, player.transform.position, ref velocity, smoothTime);
    }
}
