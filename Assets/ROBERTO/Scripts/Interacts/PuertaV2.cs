using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaV2 : MonoBehaviour,IInteractable
{
    private Animator anim;

    [Header("-----Audio-----")]
    public AudioClip[] sonidos;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void Interact()
    {
        AudioManager.instance.ReproduceSFX(sonidos[0]);
        anim.SetTrigger("Abrir");
    }
}
