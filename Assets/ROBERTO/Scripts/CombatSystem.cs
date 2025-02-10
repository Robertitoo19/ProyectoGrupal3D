using System;
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
    [SerializeField] private float attackDamage;
    [SerializeField] private float detectionRadius;
    [SerializeField] private Animator anim;

    private bool isAttacking = false;

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
        if (mainScript.Target != null && mainScript.Target.gameObject.activeSelf)
        {
            float distanceToTarget = Vector3.Distance(transform.position, mainScript.Target.position);

            // Verificar si el objetivo est� dentro del rango de detecci�n
            if (distanceToTarget <= detectionRadius)
            {
                // Perseguir al objetivo
                AimObjetive();
                agent.SetDestination(mainScript.Target.position);

                // Verificar si est� dentro de la distancia para atacar
                if (!agent.pathPending && agent.remainingDistance <= attackDistance)
                {
                    if (!isAttacking)
                    {
                        anim.SetBool("isAttacking", true);
                        isAttacking = true;
                    }
                }
                else if (isAttacking)
                {
                    anim.SetBool("isAttacking", false);
                    isAttacking = false;
                }
            }
            else
            {
                // El objetivo est� fuera del rango de detecci�n, volver a patrullar
                ExitCombat();
            }
        }
        else
        {
            // El objetivo es nulo o inv�lido, volver a patrullar
            ExitCombat();
        }
    }

    private void AimObjetive()
    {
        Vector3 targetDirection = (mainScript.Target.position - transform.position).normalized;
        targetDirection.y = 0;
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        transform.rotation = targetRotation;
    }
    private void ExitCombat()
    {
        anim.SetBool("isAttacking", false);
        isAttacking = false;
        mainScript.Target = null; // El objetivo deja de ser v�lido
        mainScript.ActivePatroll();
    }
    public void Attack()
    {
        mainScript.Target.GetComponent<IDamagable>().ReceiveDamage(attackDamage);
    }
    #region Eventos Animacion
    private void StartAttack()
    {
        if (mainScript.Target != null)
        {
            Debug.Log("Ataca");
        }
    }
    private void EndAttack()
    {
        anim.SetBool("isAttacking", false);
        isAttacking = false;
        Debug.Log("Para de atacar");
    }
    #endregion
}
