using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stuns : MonoBehaviour
{
    [SerializeField] private float stunSeconds;
    private GameObject pjStuned;
    private float time = 0;
    private bool isTund;
    private bool cantStund = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") && !cantStund)
        {
            pjStuned = other.gameObject;
            other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            isTund = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            cantStund = true;
        }
    }

    private void Update()
    {
        if (isTund)
        {
            if (time >= stunSeconds)
            {
                pjStuned.GetComponent<Rigidbody>().isKinematic = false;
                time = 0;
                isTund = false;
            } else
            {
                time += Time.deltaTime;
            }
        }
    }
}
