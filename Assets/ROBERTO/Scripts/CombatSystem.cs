using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CombatSystem : MonoBehaviour
{
    [SerializeField] private EnemyV2 mainScript;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private float combatVelocity;
    [SerializeField] private float attackDistance;
    [SerializeField] private Animator anim;

    private void Awake()
    {
        mainScript.Combat = this;
    }
    private void OnEnable()
    {
        agent.speed = combatVelocity;
        agent.stoppingDistance = attackDistance;
    }
    void Update()
    {
        if (mainScript != null && agent.CalculatePath(mainScript.Target.position, new NavMeshPath()))
        {
            AimObjetive();

            agent.SetDestination(mainScript.Target.position);

            if(!agent.pathPending && agent.remainingDistance <= attackDistance)
            {
                anim.SetBool("isAttacking", true);
            }
        }
        else
        {
            mainScript.ActivePatroll();
        }
    }
    private void AimObjetive()
    {
        Vector3 targetDirection = (mainScript.Target.position - transform.position).normalized;
        targetDirection.y = 0;
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        transform.rotation = targetRotation;
    }
    #region Eventos Animacion
    private void Attack()
    {

    }
    private void EndAttack()
    {

    }
    #endregion
}
