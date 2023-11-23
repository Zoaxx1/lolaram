using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class HabilitiesControllerEditMode
{
    GameObject hControllerGObj;
    GameObject hability;
    HabilitiesController hController;
    List<Hability> habilitiesList = new List<Hability>();

    [SetUp]
    public void SetUp()
    {
        hControllerGObj = new GameObject();
        hController = hControllerGObj.AddComponent<HabilitiesController>();
        hability = new GameObject();
        hability.AddComponent<HabilityActiveMock>();
        hability.gameObject.SetActive(false);
        habilitiesList.Add(hability.GetComponent<HabilityActiveMock>());
        hController.GetComponent<HabilitiesController>().habilities = habilitiesList;
    }

    [TestCase(0)] // Q
    [TestCase(1)] // W
    [TestCase(2)] // E
    [TestCase(3)] // R
    public void habilitiesController_PressKey(int index)
    {
        Assert.IsFalse(hController.GetComponent<HabilitiesController>().habilities[index].gameObject.activeSelf);
        hController.keyDownActivateHability(index);
        Assert.IsTrue(hController.GetComponent<HabilitiesController>().habilities[index].gameObject.activeSelf);
    }
}

public class HabilityActiveMock : Hability
{
    public override void activateHability()
    {
        gameObject.SetActive(true);
    }
}
