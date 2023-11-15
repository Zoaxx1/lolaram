using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HabilitiesPjController : MonoBehaviour
{
    [SerializeField] private List<HabilityPj> habilities = new List<HabilityPj>();

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            habilities[0].activateHability();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            habilities[1].activateHability();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            habilities[2].activateHability();
        }
        if (Input.GetKeyUp(KeyCode.R) && habilities[3].EnabledHability)
        {
            habilities[3].activateHability();
        }
    }
}
