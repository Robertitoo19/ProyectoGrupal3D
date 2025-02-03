using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Items : MonoBehaviour
{
    [SerializeField] private int itemIndex; // �ndice del objeto en el inventario
    [SerializeField] private string itemName; // Nombre para identificar el objeto
    [SerializeField] private GameObject canvasPanel;
    [SerializeField] private GameObject itemModel;
    [SerializeField] private Transform inspeccionPunto;
    [SerializeField] private float rangoItem = 2f;
    [SerializeField] private float velocidadRotacion = 50f;

    private bool estaEnRango = false;
    private bool estaInspeccionando = false;

    public int ItemIndex => itemIndex; // Propiedad para acceder al �ndice
    public string ItemName => itemName;

    private void Update()
    {
        // Comenzar inspecci�n
        if (estaEnRango && !estaInspeccionando && Input.GetKeyDown(KeyCode.E))
        {
            ComenzarInspeccion();
        }
        // Terminar inspecci�n y recoger el objeto
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

        // Activa el modelo del �tem y coloca en el punto de inspecci�n
        itemModel.SetActive(true);
        itemModel.transform.position = inspeccionPunto.position;
        itemModel.transform.rotation = Quaternion.identity;

        // Activar la c�mara de inspecci�n
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

        // Desactivar la c�mara de inspecci�n
        Camera inspectionCamera = GameObject.Find("InspeccionCamara")?.GetComponent<Camera>();
        if (inspectionCamera != null)
        {
            inspectionCamera.enabled = false;
        }
    }

    private void RecogerItem()
    {
        // Acceder al script Player para a�adir el �tem al inventario
        Player player = FindObjectOfType<Player>();
        if (player != null)
        {
            player.A�adirItemAlInventario(itemIndex, gameObject);
            Debug.Log($"�tem {itemName} (Index: {itemIndex}) recogido y a�adido al inventario.");
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
