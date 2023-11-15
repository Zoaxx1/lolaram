using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPj : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform pjTransform;
    [SerializeField] private AnimationPjController anim;
    private Vector3 destiny;
    private bool isMoving;

    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            if (!rb.isKinematic)
            {
                rb.isKinematic = true;
            }
            rb.isKinematic = false;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if(Physics.Raycast(ray, out hit))
            {
                destiny = hit.point;
                isMoving = true;
            }
        }
        if (isMoving)
        {
            anim.  setMovement(true);
            Vector3 direction = destiny - rb.position;
            if(direction.magnitude < 4f)
            {
                anim.setMovement(false);
                isMoving = false;
                rb.velocity = Vector3.zero;
                rb.isKinematic = true;
            }
            else
            {
                direction.Normalize();
                Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
                pjTransform.rotation = Quaternion.Slerp(pjTransform.rotation, rotation, Time.deltaTime * 10f);
                rb.velocity = direction * speed;
            }
        }
    }
}
