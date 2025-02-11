using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelefonoInicio : MonoBehaviour
{
    [SerializeField] private AudioSource ringSonido;
    private AudioSource audioInicio;

    private void Start()
    {
        audioInicio = GetComponent<AudioSource>();
        audioInicio.enabled = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            audioInicio.enabled = true;
            ringSonido.enabled = false;
        }
    }
}
