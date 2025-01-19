using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportZone : MonoBehaviour
{
    [SerializeField] private Transform tpDestination;
    private Vector3 returnPosition;
    private bool canReturn = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!canReturn)
            {
                //Guarda la posición actual del jugador para volver
                returnPosition = other.transform.position;
                canReturn = true; // Ahora el jugador puede voler

                //Teletransporta al jugador al destino
                other.transform.position = tpDestination.position;
                other.transform.rotation = tpDestination.rotation;
            }
            else
            {
                // Teletransporta al jugador a la posición original
                other.transform.position = returnPosition;
                canReturn = false; // Una vez regrese, ya no puede volver
            }
        }
    }
}
