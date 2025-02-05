using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CajonMetal : MonoBehaviour, IInteractable
{
    private Animator anim;

    [Header("-----Audio-----")]
    [SerializeField] AudioManager audioManager;
    public AudioClip[] sonidos;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void Interact()
    {
        audioManager.ReproduceSFX(sonidos[0]);
        anim.SetTrigger("Abrir");
    }
}
