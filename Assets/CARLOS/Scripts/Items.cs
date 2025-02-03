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
            // A�adir el �tem al inventario
            player.A�adirItemAlInventario(itemIndex, gameObject);
            Debug.Log($"�tem {itemName} (Index: {itemIndex}) recogido y a�adido al inventario.");

            // Desactivar o destruir el objeto despu�s de recogerlo
            Destroy(gameObject);
        }
        else
        {
            Debug.LogError("No se encontr� el script Player en la escena.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            estaEnRango = true;
            Debug.Log("El jugador est� en rango para recoger el objeto.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            estaEnRango = false;
            Debug.Log("El jugador sali� del rango del objeto.");
        }
    }
}
