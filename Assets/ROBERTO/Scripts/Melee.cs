using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    [SerializeField] private ArmaSO myData;
    [SerializeField] private Animator anim;
    private Camera cam;

    private void Awake()
    {
        cam = Camera.main;
    }
    void Update()
    {
        Attack();
    }

    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            anim.SetTrigger("Attack");

            if(Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hitInfo, myData.attackDistance))
            {
                if(hitInfo.transform.TryGetComponent(out EnemyPart enemyPartScript))
                {
                    enemyPartScript.ReceiveDamageEnemy(myData.attackDamage);
                }
            }
        }
    }
}
