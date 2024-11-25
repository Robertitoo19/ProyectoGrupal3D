using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cinemachine.DocumentationSortingAttribute;

public class Player : MonoBehaviour
{
    [SerializeField] int vidaPlayer;

    public int VidaPlayer { get => vidaPlayer; set => vidaPlayer = value; }

    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public void ReceiveDamage(int enemyDamage)
    {
        vidaPlayer -= enemyDamage;
    }
}
