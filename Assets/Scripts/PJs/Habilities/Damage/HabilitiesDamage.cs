using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HabilitiesDamage : MonoBehaviour
{
    public static HabilitiesDamage Instance { get; private set; }
    [SerializeField] private float damage;
    [SerializeField] private bool canDamageMinions;
    public float Damage { get { return damage; } }
    public bool CanDamageMinions { get {  return canDamageMinions; } }
}
