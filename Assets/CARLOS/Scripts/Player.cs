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

    [SerializeField] int CurasPlayer;

    [SerializeField] Light linterna;

    [SerializeField] public float alturaMinimaCaida;
    [SerializeField] private float alturaMaximaCaida;
    private Rigidbody rb;
    private Inventario inv;

    [Header("-----Audio-----")]
    public AudioClip[] sonidos;


    public int VidaPlayer { get => vidaPlayer; set => vidaPlayer = value; }
    public bool[] TieneItem { get => tieneItem; set => tieneItem = value; }
    public int CurasPlayer1 { get => CurasPlayer; set => CurasPlayer = value; }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();
        alturaMaximaCaida = transform.position.y;
    }
    void Update()
    {
        OnOffFlashLight();
        CaidaPlayer();
        CambiarArma();
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
            anim.SetTrigger("die");
        }
        if(estaCayendo())
        {
            alturaMaximaCaida =transform.position.y;
        }
    }
    public void AñadirItemAlInventario(int index, GameObject objeto)
    {
        if (index >= 0 && index < items.Length)
        {
            // Marcar el ítem como obtenido
            tieneItem[index] = true;

            // Asegurarse de que el ítem en el array corresponde al GunManager
            if (items[index] == null)
            {
                items[index] = objeto; // Asignar el ítem al array
            }

            Debug.Log($"Ítem {index} añadido al inventario.");
        }
        else
        {
            Debug.LogWarning($"Índice fuera de rango: {index}. No se puede añadir al inventario.");
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
            AudioManager.instance.ReproduceSFX(sonidos[0]);
            linterna.enabled = !linterna.enabled;
        }
    }
    
    public void CambiarArma()
    {
        int nuevoItemNº = -1;

        // Detectar la tecla presionada
        if (Input.GetKeyDown(KeyCode.Alpha1)) nuevoItemNº = 0;
        else if (Input.GetKeyDown(KeyCode.Alpha2)) nuevoItemNº = 1;
        else if (Input.GetKeyDown(KeyCode.Alpha3)) nuevoItemNº = 2;
        else if (Input.GetKeyDown(KeyCode.Alpha4)) nuevoItemNº = 3;
        else if (Input.GetKeyDown(KeyCode.Alpha5)) nuevoItemNº = 4;

        // Validar si el índice es válido y el jugador tiene ese ítem
        if (nuevoItemNº >= 0 && nuevoItemNº < Items.Length && TieneItem[nuevoItemNº])
        {
            // Desactivar el ítem actualmente equipado (si existe)
            if (equiparItem != null)
            {
                equiparItem.SetActive(false);
            }

            // Activar el nuevo ítem y asignarlo como el actual
            equiparItem = Items[nuevoItemNº];
            equiparItem.SetActive(true);

            // Actualizar el estado de los objetos en el GunManager
            for (int i = 0; i < Items.Length; i++)
            {
                if (i == nuevoItemNº)
                {
                    Items[i].SetActive(true); // Activar el ítem seleccionado
                }
                else
                {
                    Items[i].SetActive(false); // Desactivar los demás ítems
                }
            }

            // Opcional: Lanzar animación de cambio de arma
            anim.SetTrigger("swap");
            estaCambiandoItem = true;

            // Temporizador para finalizar el cambio de arma
            Invoke("TerminarCambiarArma", 0.4f);
        }
        Debug.Log("CambiarArma llamado");
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

            //int itenmNº = item.Valor;
        }
    }
}
