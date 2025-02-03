using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Items : MonoBehaviour
{
    [SerializeField] private int itemIndex; // Índice del objeto en el inventario
    [SerializeField] private string itemName; // Nombre para identificar el objeto
    [SerializeField] private GameObject canvasPanel;
    [SerializeField] private GameObject itemModel;
    [SerializeField] private Transform inspeccionPunto;
    [SerializeField] private float rangoItem = 2f;
    [SerializeField] private float velocidadRotacion = 50f;

    private bool estaEnRango = false;
    private bool estaInspeccionando = false;

    public int ItemIndex => itemIndex; // Propiedad para acceder al índice
    public string ItemName => itemName;

    private void Update()
    {
        // Comenzar inspección
        if (estaEnRango && !estaInspeccionando && Input.GetKeyDown(KeyCode.E))
        {
            ComenzarInspeccion();
        }
        // Terminar inspección y recoger el objeto
        else if (estaInspeccionando && Input.GetKeyDown(KeyCode.Escape))
        {
            TerminarInspeccion();
            RecogerItem();
        }
    }

    private void ComenzarInspeccion()
    {
        estaInspeccionando = true;
        canvasPanel.SetActive(true);

        // Activa el modelo del ítem y coloca en el punto de inspección
        itemModel.SetActive(true);
        itemModel.transform.position = inspeccionPunto.position;
        itemModel.transform.rotation = Quaternion.identity;

        // Activar la cámara de inspección
        Camera inspectionCamera = GameObject.Find("InspeccionCamara")?.GetComponent<Camera>();
        if (inspectionCamera != null)
        {
            inspectionCamera.enabled = true;
        }
    }

    private void TerminarInspeccion()
    {
        estaInspeccionando = false;
        canvasPanel.SetActive(false);

        // Desactivar la cámara de inspección
        Camera inspectionCamera = GameObject.Find("InspeccionCamara")?.GetComponent<Camera>();
        if (inspectionCamera != null)
        {
            inspectionCamera.enabled = false;
        }
    }

    private void RecogerItem()
    {
        // Acceder al script Player para añadir el ítem al inventario
        Player player = FindObjectOfType<Player>();
        if (player != null)
        {
            player.AñadirItemAlInventario(itemIndex, gameObject);
            Debug.Log($"Ítem {itemName} (Index: {itemIndex}) recogido y añadido al inventario.");
        }

        // Destruir el objeto tras recogerlo
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            estaEnRango = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            estaEnRango = false;
        }
    }
}
