using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPj : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform pjTransform;
    [SerializeField] private MovementAnimationPjController anim;
    private Vector3 destiny;
    protected bool isMoving;

    private void startMoving()
    {
        rb.isKinematic = false;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            destiny = hit.point;
            isMoving = true;
        }
    }

    private void stopMoving()
    {
        anim.setMovement(false);
        isMoving = false;
        rb.velocity = Vector3.zero;
        rb.isKinematic = true;
    }

    private void moving()
    {
        anim.setMovement(true);
        Vector3 direction = destiny - rb.position;
        if(direction.magnitude < 4f)
        {
            stopMoving();
        }
        else
        {
            direction.Normalize();
            Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
            pjTransform.rotation = Quaternion.Slerp(pjTransform.rotation, rotation, Time.deltaTime * 10f);
            rb.velocity = direction * speed;
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            startMoving();
        }
        if (isMoving)
        {
            moving();
        }
    }
}
