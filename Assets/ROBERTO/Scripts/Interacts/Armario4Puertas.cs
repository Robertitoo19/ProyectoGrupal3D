using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armario4Puertas : MonoBehaviour,IInteractable
{
    private Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void Interact()
    {
        Debug.Log("abro");
        anim.SetTrigger("Abrir");
    }
}
