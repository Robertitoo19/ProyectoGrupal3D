using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    [SerializeField] private ArmaSO myData;
    [SerializeField] private Animator anim;
    private Camera cam;

    [Header("-----Audio-----")]
    [SerializeField] private AudioClip[] sonidos;

    private void Awake()
    {
        cam = Camera.main;
    }
    private void Start()
    {
        //anim = GetComponentInParent<Animator>();
    }
    void Update()
    {
        Attack();
    }

    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            anim.SetTrigger("MeleeAttack");
            AudioManager.instance.ReproduceSFX(sonidos[0]);

            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hitInfo, myData.attackDistance))
            {
                if(hitInfo.transform.TryGetComponent(out EnemyPart enemyPartScript))
                {
                    enemyPartScript.ReceiveDamageEnemy(myData.attackDamage);
                }
            }
        }
    }
}
