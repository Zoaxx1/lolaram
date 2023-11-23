using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HabilitiesController : MonoBehaviour
{
    public List<Hability> habilities = new List<Hability>();

    public void keyDownActivateHability(int index)
    {
        habilities[index].activateHability();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            keyDownActivateHability(0);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            keyDownActivateHability(1);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            keyDownActivateHability(2);
        }
        if (Input.GetKeyUp(KeyCode.R))
        {
            keyDownActivateHability(3);
        }
    }
}
