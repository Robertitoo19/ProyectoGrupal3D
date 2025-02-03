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

    private bool estaEnRango = false;

    public int ItemIndex => itemIndex;
    public string ItemName => itemName;

    private void Update()
    {
        if (estaEnRango && Input.GetKeyDown(KeyCode.E))
        {
            RecogerItem();
        }
    }

    private void RecogerItem()
    {
        // Buscar el script del jugador
        Player player = FindObjectOfType<Player>();
        if (player != null)
        {
            // Añadir el ítem al inventario
            player.AñadirItemAlInventario(itemIndex, gameObject);
            Debug.Log($"Ítem {itemName} (Index: {itemIndex}) recogido y añadido al inventario.");

            // Desactivar o destruir el objeto después de recogerlo
            Destroy(gameObject);
        }
        else
        {
            Debug.LogError("No se encontró el script Player en la escena.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            estaEnRango = true;
            Debug.Log("El jugador está en rango para recoger el objeto.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            estaEnRango = false;
            Debug.Log("El jugador salió del rango del objeto.");
        }
    }
}
