using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Skillshot : MonoBehaviour
{
    [SerializeField] protected float speed;
    [SerializeField] private float distanceToDestroy;
    [SerializeField] private HabilitiesDamage habilitiesDamage;
    [SerializeField] private float rotation;
    [SerializeField] private bool addAceleration;
    private Rigidbody rb;
    private Vector3 startPoint;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        RaycastHit hitAtk;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitAtk, Mathf.Infinity))
        {
            float transformHeight = transform.position.y;
            float floorHeight = hitAtk.point.y;
            Vector3 point = hitAtk.point - new Vector3(transform.position.x, floorHeight, transform.position.z);
            Vector3 direction = new Vector3(point.x, transformHeight, point.z);
            if (!addAceleration)
            {
                rb.velocity = direction.normalized * speed;
            }
            else
            {
                rb.AddForce(direction * speed, ForceMode.Acceleration);
            }
            startPoint = transform.position;
            float rotateDirection = 1;
            if(hitAtk.point.z < 0)
            {
                rotateDirection = -1;
            }
            transform.rotation = Quaternion.Euler(0f, transform.eulerAngles.y + rotation * rotateDirection + 90f, 90f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
        if(other.gameObject.CompareTag("Minion") && habilitiesDamage.CanDamageMinions)
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if(Vector3.Distance(transform.position, startPoint) >= distanceToDestroy)
        {
            Destroy(gameObject);
        }   
    }
}
