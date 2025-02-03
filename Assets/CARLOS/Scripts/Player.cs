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
    int itemN� = -1;

    private Animator anim;

    public int ItemN� { get => itemN�; set => itemN� = value; }
    public GameObject[] Items { get => items; set => items = value; }

    [SerializeField] int vidaPlayer;

    [SerializeField] Light linterna;

    [SerializeField] public float alturaMinimaCaida;
    [SerializeField] private float alturaMaximaCaida;
    private Rigidbody rb;
    private Inventario inv;



    
    public int VidaPlayer { get => vidaPlayer; set => vidaPlayer = value; }
    public bool[] TieneItem { get => tieneItem; set => tieneItem = value; }

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
    public void A�adirItemAlInventario(int index, GameObject objeto)
    {
        if (index >= 0 && index < items.Length)
        {
            // Activar el flag de inventario
            tieneItem[index] = true;
            Debug.Log($"�tem {index} a�adido al inventario.");

            // Destruir el objeto de la escena si corresponde
            Destroy(objeto);
        }
        else
        {
            Debug.LogWarning("�ndice fuera de rango. No se puede a�adir al inventario.");
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
        int nuevoItemN� = -1;

        // Detectar la tecla presionada
        if (Input.GetKeyDown(KeyCode.Alpha1)) nuevoItemN� = 0;
        else if (Input.GetKeyDown(KeyCode.Alpha2)) nuevoItemN� = 1;
        else if (Input.GetKeyDown(KeyCode.Alpha3)) nuevoItemN� = 2;
        else if (Input.GetKeyDown(KeyCode.Alpha4)) nuevoItemN� = 3;
        else if (Input.GetKeyDown(KeyCode.Alpha5)) nuevoItemN� = 4;

        // Validar el �ndice y si el �tem est� desbloqueado
        if (nuevoItemN� >= 0 && nuevoItemN� < items.Length && tieneItem[nuevoItemN�])
        {
            // Si ya est� equipado, no hacer nada
            if (equiparItem == items[nuevoItemN�])
                return;

            // Desactivar el �tem actualmente equipado (si existe)
            if (equiparItem != null)
            {
                equiparItem.SetActive(false);
            }

            // Activar el nuevo �tem y asignarlo como el actual
            equiparItem = items[nuevoItemN�];
            equiparItem.SetActive(true);

            // Opcional: Lanzar animaci�n de cambio de arma
            anim.SetTrigger("swap");
            estaCambiandoItem = true;

            // Temporizador para finalizar el cambio de arma
            Invoke("TerminarCambiarArma", 0.4f);
        }
    }
    private void TerminarCambiarArma()
    {
        estaCambiandoItem = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Objeto1"))
        {
            Items item = other.GetComponent<Items>();

            //int itenmN� = item.Valor;
        }
    }
}
