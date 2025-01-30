using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cinemachine.DocumentationSortingAttribute;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject[] items;
    [SerializeField] private bool[] tieneItem;
    private GameObject equiparItem;
    bool estaCambiandoItem = false;
    int itemNº = -1;

    private Animator anim;

    public int ItemNº { get => itemNº; set => itemNº = value; }
    public GameObject[] Items { get => items; set => items = value; }

    [SerializeField] int vidaPlayer;

    [SerializeField] Light linterna;

    [SerializeField] public float alturaMinimaCaida;
    [SerializeField] private float alturaMaximaCaida;
    private Rigidbody rb;
    private Inventario inv;
    
    public int VidaPlayer { get => vidaPlayer; set => vidaPlayer = value; }

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
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
    
    public void CambiarArma()
    {
        int itemNº = -1;
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            itemNº = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            itemNº = 1;
        }
        else if ((Input.GetKeyDown(KeyCode.Alpha3)))
        {
            itemNº = 2;
        }
        if (itemNº >= 0 && itemNº < Items.Length && tieneItem[itemNº])
        {
            if (equiparItem != null)
            {
                Items[itemNº].SetActive(false);
                equiparItem.SetActive(false);
            }

            equiparItem = Items[itemNº];
            Items[itemNº].SetActive(true);

            anim.SetTrigger("swap");
            estaCambiandoItem = true;

            Invoke("TerminarCambiarArma", 0.4f);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Objeto1"))
        {
            Items item = other.GetComponent<Items>();

            //int itenmNº = item.Valor;
        }
    }
}
