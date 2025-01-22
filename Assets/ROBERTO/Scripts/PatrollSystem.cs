using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrollSystem : MonoBehaviour
{
    [SerializeField] private EnemyV2 mainScript;
    [SerializeField] private float detectionRadius;
    [SerializeField] private float angleVission;
    [SerializeField] private LayerMask whatIsTarget;
    [SerializeField] private LayerMask whatIsObstacle;

    [SerializeField] private float patrollVelocity;
    [SerializeField] private NavMeshAgent agent;

    
    private void Awake()
    {
        mainScript.Patroll = this;
    }
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        Collider[] collDetected = Physics.OverlapSphere(transform.position, detectionRadius, whatIsTarget);

        if (collDetected.Length > 0) //Player in range
        {
            mainScript.Target = collDetected[0].transform;
            Vector3 directionToTarget = (mainScript.Target.transform.position - transform.position);
            //Tirar un raycast desde mi posici�n al target y ver que NO haya obst�culos de por medio.
            if(!Physics.Raycast(transform.position, directionToTarget, detectionRadius, whatIsObstacle)) //No hay obst�culos de mi a player.
            {
                if (Vector3.Angle(directionToTarget, transform.forward) < angleVission / 2)
                {
                    mainScript.ActiveCombat(mainScript.Target);
                }
            }
        }
        
    }
}
