using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyV2 : MonoBehaviour
{
    private PatrollSystem patroll;
    private CombatSystem combat;

    private Transform target;

    public PatrollSystem Patroll { get => patroll; set => patroll = value; }
    public CombatSystem Combat { get => combat; set => combat = value; }
    public Transform Target { get => target; set => target = value; }

    void Start()
    {
        patroll.enabled = true;
    }
    void Update()
    {
        
    }
    public void ActiveCombat(Transform target)
    {
        this.target = target;

        patroll.enabled = false;
        combat.enabled = true;
    }
    public void ActivePatroll()
    {
        combat.enabled = false;
        patroll.enabled = true;
    }
}
