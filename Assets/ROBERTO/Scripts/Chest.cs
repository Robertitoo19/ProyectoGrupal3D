using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, IInteractable
{
    private Animator anim;
    private bool isOpen = false;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Interact()
    {
        if (!isOpen)
        {
            isOpen = true;
            anim.SetTrigger("Abrir");
        }
    }
}
