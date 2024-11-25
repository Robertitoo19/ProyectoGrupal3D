using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent agent;
    private Player player;
    private Animator anim;

    [Header("-----Sistema Combate-----")]
    private bool OpenWindow;
    [SerializeField] private Transform AttackPoint;
    [SerializeField] private float detectionRatio;
    [SerializeField] private LayerMask WhatIsDamagable;
    [SerializeField] private int enemyDamage;
    private bool canDamage;

    [SerializeField] private float livesEnemy;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindObjectOfType<Player>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (agent.enabled)
        {
            Follow();
        }
        if (OpenWindow && canDamage)
        {
            DetectImpact();
        }
    }

    private void Follow()
    {
        //Enemy va a la posicion del player.
        agent.SetDestination(player.transform.position);
        //el enemigo esta cerca del player.
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            //se para el enemigo.
            agent.isStopped = true;
            //activar anim.
            anim.SetBool("isAttacking", true);
        }
    }
    private void DetectImpact()
    {
        //detectar colliders.
        Collider[] collDetectates = Physics.OverlapSphere(AttackPoint.position, detectionRatio, WhatIsDamagable);
        //si ha detectado algo en el ataque.
        if (collDetectates.Length > 0)
        {
            //aplicas daño a cada colllider
            for (int i = 0; i < collDetectates.Length; i++)
            {
                collDetectates[i].GetComponent<Player>().ReceiveDamage(enemyDamage);
            }
            canDamage = false;
        }
    }
    private void EndAttack()
    {
        agent.isStopped = false;
        anim.SetBool("isAttacking", false);
        canDamage = true;
    }
    private void OpenAttackWindow()
    {
        OpenWindow = true;
    }
    private void CloseAttackWindow()
    {
        OpenWindow = false;
    }
}
