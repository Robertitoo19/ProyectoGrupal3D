using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cinemachine.DocumentationSortingAttribute;

public class Player : MonoBehaviour
{
    [SerializeField] int vidaPlayer;

    [SerializeField] Light linterna;

    [SerializeField] public float alturaMinimaCaida;
    [SerializeField] private float alturaMaximaCaida;
    private Rigidbody rb;
    
    public int VidaPlayer { get => vidaPlayer; set => vidaPlayer = value; }

    void Start()
    {
        rb= GetComponent<Rigidbody>();
        alturaMaximaCaida = transform.position.y;
    }
    void Update()
    {
        OnOffFlashLight();
        CaidaPlayer();
    }
    private void CaidaPlayer()
    {
        if(transform.position.y > alturaMaximaCaida)
        {
            alturaMaximaCaida = transform.position.y;
        }
        if(estaCayendo() && alturaMaximaCaida - transform.position.y >= alturaMinimaCaida)
        {
            Debug.Log("Has Caido Muy alto");
            vidaPlayer = 0;
        }
        if(estaCayendo())
        {
            alturaMaximaCaida =transform.position.y;
        }
    }
    bool estaCayendo()
    {
        return Physics.Raycast(transform.position, Vector3.down, 5f);
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
