using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent agent;
    private Player player;
    private Animator anim;

    private bool OpenWindow;
    [Header("-----Sistema Combate-----")]
    [SerializeField] private Transform AttackPoint;
    [SerializeField] private float detectionRatio;
    [SerializeField] private LayerMask WhatIsDamagable;
    [SerializeField] private int enemyDamage;
    private bool canDamage = true;

    Rigidbody[] joints;
    private bool isDead = false;

    [SerializeField] private float livesEnemy;

    public float LivesEnemy { get => livesEnemy; set => livesEnemy = value; }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindObjectOfType<Player>();
        anim = GetComponent<Animator>();

        joints = GetComponentsInChildren<Rigidbody>();
        ChangeJointsState(true);
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
            AimObjetive();
        }
    }
    private void AimObjetive()
    {
        //sacar vector que mira al player desde nuestra posicion.
        Vector3 objetiveDirection = (player.transform.position - transform.position).normalized;
        //enemigo no se tumbe.
        objetiveDirection.y = 0;
        //calcular rotacion para conseguir rotacion.
        Quaternion objetiveRotation = Quaternion.LookRotation(objetiveDirection);

        transform.rotation = objetiveRotation;
    }
    private void DetectImpact()
    {
        //detectar colliders.
        Collider[] collDetectates = Physics.OverlapSphere(AttackPoint.position, detectionRatio, WhatIsDamagable);
        //si ha detectado algo en el ataque.
        if (collDetectates.Length > 0)
        {
            //aplicas da�o a cada colllider
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
    private void ChangeJointsState(bool State)
    {
        for (int i = 0; i < joints.Length; i++)
        {
            joints[i].isKinematic = State;
        }
    }
    public void Dead()
    {
        if (!isDead) 
        {
            ChangeJointsState(false);
            anim.enabled = false;
            agent.enabled = false;
            isDead = true;
        }
    }
}
