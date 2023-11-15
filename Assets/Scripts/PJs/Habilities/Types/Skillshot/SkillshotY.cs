using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillshotY : MonoBehaviour
{
    [SerializeField] private float distanceY;
    [SerializeField] protected float speed;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameObject.transform.position = new Vector3(transform.position.x, distanceY, transform.position.z);
        RaycastHit hitAtk;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitAtk, Mathf.Infinity))
        {
            float transformHeight = transform.position.y;
            Vector3 point = hitAtk.point - new Vector3(transform.position.x, transformHeight, transform.position.z);
            Vector3 direction = new Vector3(point.x * -1, transformHeight, point.z * -1);
            rb.AddForce(direction * speed * -1, ForceMode.Acceleration);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            Destroy(gameObject);
        }
    }
}
