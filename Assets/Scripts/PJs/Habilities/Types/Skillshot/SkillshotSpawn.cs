using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillshotSpawn : MonoBehaviour
{
    [SerializeField] private float time;
    private float clock;

    void Start()
    {
        clock = 0;
        RaycastHit hitAtk;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitAtk, Mathf.Infinity))
        {
            transform.position = new Vector3(hitAtk.point.x, 4, hitAtk.point.z);
        }
    }

    void Update()
    {
        if(clock >= time)
        {
            clock = 0;
            Destroy(gameObject);
        } else
        {
            clock += Time.deltaTime;
        }
    }
}
