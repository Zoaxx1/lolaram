using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoAim : MonoBehaviour
{
    [SerializeField] private float speed;
    private Transform positionEnemy;
    private Rigidbody rb;
    public Transform positionEn
    {
        set { positionEnemy = value; }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Debug.Log(positionEnemy != null);
    }

    private void Update()
    {
       Vector3 direction = positionEnemy.position - transform.position;
       transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
       rb.velocity = direction.normalized * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
