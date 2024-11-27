using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

public class ManualGun : MonoBehaviour
{
    [SerializeField] private ArmaSO myData;

    private Camera cam;

    [SerializeField] ParticleSystem particles;
    void Start()
    {
        cam = Camera.main;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            particles.Play();
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hitInfo, myData.attackDistance))
            {
                if (hitInfo.transform.CompareTag("EnemyPart"))
                {
                    hitInfo.transform.GetComponent<EnemyPart>().ReceiveDamageEnemy(myData.attackDamage);
                }
            }
        }
    }
}
