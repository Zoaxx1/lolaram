using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset = new Vector3 (0, 10f, 0f);
    [SerializeField] private float smoothed = 5f;
    private Vector3 smoothedVelocity;

    private void Start()
    {
        transform.position = target.position + offset;
    }

    void Update()
    {
        if(target != null)
        {
            Vector3 position = target.position + offset;            
            
            transform.position = Vector3.SmoothDamp(transform.position, position, ref smoothedVelocity, smoothed);

            transform.LookAt(target.position);
        }
    }
}
