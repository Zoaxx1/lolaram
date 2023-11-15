using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemy : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float distance;
    private Rigidbody rb;
    private int position = 1;

    void Start()
    {
        rb = GetComponent<Rigidbody>();    
    }

    void Update()
    {
        if(transform.position.z >= distance)
        {
            position = -1;
        } else if(transform.position.z <= -distance)
        {
            position = 1;
        }
        rb.velocity = transform.forward.normalized * speed * position;
    }
}
