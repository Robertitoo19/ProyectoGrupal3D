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
    public void A�adirItemAlInventario(int index, GameObject objeto)
    {
        if (index >= 0 && index < items.Length)
        {
            // Marcar el �tem como obtenido
            tieneItem[index] = true;

            // Asegurarse de que el �tem en el array corresponde al GunManager
            if (items[index] == null)
            {
                items[index] = objeto; // Asignar el �tem al array
            }

            Debug.Log($"�tem {index} a�adido al inventario.");
        }
        else
        {
            Debug.LogWarning($"�ndice fuera de rango: {index}. No se puede a�adir al inventario.");
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
        int nuevoItemN� = -1;

        // Detectar la tecla presionada
        if (Input.GetKeyDown(KeyCode.Alpha1)) nuevoItemN� = 0;
        else if (Input.GetKeyDown(KeyCode.Alpha2)) nuevoItemN� = 1;
        else if (Input.GetKeyDown(KeyCode.Alpha3)) nuevoItemN� = 2;
        else if (Input.GetKeyDown(KeyCode.Alpha4)) nuevoItemN� = 3;
        else if (Input.GetKeyDown(KeyCode.Alpha5)) nuevoItemN� = 4;

        // Validar si el �ndice es v�lido y el jugador tiene ese �tem
        if (nuevoItemN� >= 0 && nuevoItemN� < Items.Length && TieneItem[nuevoItemN�])
        {
            // Desactivar el �tem actualmente equipado (si existe)
            if (equiparItem != null)
            {
                equiparItem.SetActive(false);
            }

            // Activar el nuevo �tem y asignarlo como el actual
            equiparItem = Items[nuevoItemN�];
            equiparItem.SetActive(true);

            // Actualizar el estado de los objetos en el GunManager
            for (int i = 0; i < Items.Length; i++)
            {
                if (i == nuevoItemN�)
                {
                    Items[i].SetActive(true); // Activar el �tem seleccionado
                }
                else
                {
                    Items[i].SetActive(false); // Desactivar los dem�s �tems
                }
            }

            // Opcional: Lanzar animaci�n de cambio de arma
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

            //int itenmN� = item.Valor;
        }
    }
}
