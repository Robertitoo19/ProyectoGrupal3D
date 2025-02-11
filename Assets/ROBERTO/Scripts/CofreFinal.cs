using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CofreFinal : MonoBehaviour, IInteractable
{
    private Animator anim;
    private bool hasKey;


    void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void Interact()
    {
        if (!hasKey)
        {
            return;
        }
        anim.SetTrigger("Abrir");
    }
    public void TakeFinalKey()
    {
        hasKey = true;
    }
}
