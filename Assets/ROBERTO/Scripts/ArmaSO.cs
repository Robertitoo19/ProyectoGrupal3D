using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Arma")] 
public class ArmaSO : ScriptableObject
{
    public int bullets;
    public int chamberBullets;
    public float cadence;
    public float attackDistance;
    public float attackDamage;
}
