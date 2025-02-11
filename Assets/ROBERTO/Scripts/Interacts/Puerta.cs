using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta1 : MonoBehaviour, IInteractable
{
    private Animator anim;
    private static bool hasKey = false;
    private bool bloqued = false;

    [Header("-----Audio-----")]
    public AudioClip[] sonidos;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void Interact()
    {
        if (bloqued)
        {

            Debug.Log("bloqueada, necesitas palanca");
            return;
        }
        if (!hasKey)
        {
            Debug.Log("bloqueada necesitas llave");
            return;
        }
        Debug.Log("abre");
        AudioManager.instance.ReproduceSFX(sonidos[0]);
        anim.SetTrigger("Abrir");
    }
    public void takeKey()
    {
        Debug.Log("recoge llave");
        hasKey = true;
    }
    public void BloqDoor()
    {
        if (!bloqued)
        {
            anim.SetTrigger("Cerrar");
            bloqued = true;
            Debug.Log("puertas bloq");
        }
    }
    public void UnlockDoor()
    {
        if (bloqued)
        {
            bloqued = false;
            Debug.Log("desbloqueadas");
        }
    }
}
