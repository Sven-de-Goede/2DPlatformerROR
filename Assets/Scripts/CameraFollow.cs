using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float mouseScroll = 0f;
    public Vector3 offset = new Vector3(0f, 0f, -10f);
    private float smoothTime = 0.25f;
    private Vector3 velocity = Vector3.zero;

    [SerializeField] private Transform target;


    void Update() 
    {
        offset = new Vector3(0f, 0f, -10f + mouseScroll);
        mouseScroll += Input.mouseScrollDelta.y;
    }
    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Vector3.SmoothDamp(transform.position, target.position + offset, ref velocity, smoothTime);
        
    }
}
