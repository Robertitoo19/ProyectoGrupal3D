using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cinemachine.DocumentationSortingAttribute;

public class Player : MonoBehaviour
{
    [SerializeField] int vidaPlayer;

    [SerializeField] Light linterna;

    public int VidaPlayer { get => vidaPlayer; set => vidaPlayer = value; }

    void Start()
    {
        
    }
    void Update()
    {
        OnOffFlashLight();
    }
    public void ReceiveDamage(int enemyDamage)
    {
        vidaPlayer -= enemyDamage;
    }
    private void OnOffFlashLight()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            linterna.enabled = !linterna.enabled;
        }
    }
}
