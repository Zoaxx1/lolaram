using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class HabilityEditMode
{
    GameObject habilityGObj = new GameObject();
    Hability habilityH;
    GameObject skillShotH = new GameObject();
    GameObject autoAimH = new GameObject();

    [SetUp]
    public void SetUp()
    {
        habilityH = habilityGObj.AddComponent<HabilityMock>();
        skillShotH.SetActive(false);
        autoAimH.SetActive(false);
    }

    [Test]
    public void hability_ActivateHability()
    {
        habilityH.isHabilityEnable = true;
        habilityH.hability = skillShotH;
        Assert.IsFalse(skillShotH.activeSelf);
        habilityH.activateHability();
        Assert.IsTrue(skillShotH.activeSelf);
    }

    [Test]
    public void hability_IsDisableHability()
    {
        habilityH.isHabilityEnable = false;
        Assert.IsFalse(skillShotH.activeSelf);
        habilityH.activateHability();
        Assert.IsFalse(skillShotH.activeSelf);
    }

    [Test]
    public void hability_ActivateHabilityAndDisableHability()
    {
        habilityH.isHabilityEnable = true;
        habilityH.hability = skillShotH;
        // The Hability is Disabled
        Assert.IsFalse(skillShotH.activeSelf);
        habilityH.activateHability();
        // The Hability is Enabled
        Assert.IsTrue(skillShotH.activeSelf);
        // set isHabilityEnable to false
        Assert.IsFalse(habilityH.isHabilityEnable);
        // Disabled the gameObject
        skillShotH.SetActive(false);
        habilityH.activateHability();
        // If isHabilityEnable is false the gameObject to be disabled
        // cause can't enter in the if
        Assert.IsFalse(skillShotH.activeSelf);
    }

    [Test]
    public void hability_ActivateHabilityAutoAim()
    {
        habilityH.type = Hability.HabilityType.autoaim;
        habilityH.hability = autoAimH;
        Assert.IsNull(habilityH.GetComponent<HabilityMock>().enemyTransform);
        Assert.IsFalse(autoAimH.activeSelf);
        habilityH.activateHability();
        Assert.IsTrue(autoAimH.activeSelf);
        Assert.IsNotNull(habilityH.GetComponent<HabilityMock>().enemyTransform);
    }
}

public class HabilityMock : Hability
{
    public Transform enemyTransform;

    public Transform enemyTransformt
    {
        get { return enemyTransform; }
    }

    public override void activateHability()
    {
        if (base.isHabilityEnable)
        {
            if(base.type == Hability.HabilityType.autoaim)
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Vector3.zero);
                if (Physics.Raycast(ray, out hit))
                {
                    enemyTransform = hit.transform;
                }
            }
            base.hability.SetActive(true);
            base.isHabilityEnable = false;
        }
    }
}
