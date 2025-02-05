using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

public class ManualGun : MonoBehaviour
{
    [SerializeField] private ArmaSO myData;
    [SerializeField] ParticleSystem particles;
    [SerializeField] private Animator anim;

    private Camera cam;


    [Header("-----Sistema Recarga-----")]

    [SerializeField] private TMP_Text txtCurrentAmmo;
    [SerializeField] private TMP_Text txtCurrentChamber;

    private int currentAmmo;
    private int currentChamber;

    private float reloadTime = 1.5f;
    private bool isReloading = false;

    [Header("-----Audio-----")]
    [SerializeField] private AudioClip[] sonidos;

    void Start()
    {
        cam = Camera.main;

        currentAmmo = myData.bullets;
        currentChamber = myData.chamberBullets;

        txtCurrentAmmo.text = currentAmmo.ToString();
        txtCurrentChamber.text = currentChamber.ToString();
    }
    private void OnEnable()
    {
        isReloading = false;
    }
    void Update()
    {
        if (isReloading)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.R) && currentAmmo < myData.bullets)
        {
            StartCoroutine(Reload());
            return;
        }
        Shoot();
    }

    private void Shoot()
    {
        if (Input.GetMouseButtonDown(0) && currentAmmo >0)
        {
            particles.Play();
            AudioManager.instance.ReproduceSFX(sonidos[0]);
            anim.SetTrigger("Shoot");
            currentAmmo--;
            txtCurrentAmmo.text = currentAmmo.ToString();

            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hitInfo, myData.attackDistance))
            {
                if (hitInfo.transform.TryGetComponent(out EnemyPart enemyPartScript))
                {
                    enemyPartScript.ReceiveDamageEnemy(myData.attackDamage);
                }
            }
        }
    }
    private IEnumerator Reload()
    {
        int emptys = myData.bullets - currentAmmo;

        if (currentChamber >= emptys) 
        {
            isReloading = true;
            AudioManager.instance.ReproduceSFX(sonidos[1]);
            anim.SetTrigger("Reload");

            yield return new WaitForSeconds(reloadTime);

            currentAmmo = myData.bullets;
            currentChamber -= emptys;

            txtCurrentAmmo.text = currentAmmo.ToString();
            txtCurrentChamber.text = currentChamber.ToString();

            isReloading = false;
        }
        else
        {
            currentAmmo = currentAmmo + currentChamber;
            currentChamber = 0;

            txtCurrentAmmo.text = currentAmmo.ToString();
            txtCurrentChamber.text = currentChamber.ToString();
        }
    }
}
