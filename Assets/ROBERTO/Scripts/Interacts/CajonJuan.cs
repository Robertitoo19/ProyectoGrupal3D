using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CajonJuan : MonoBehaviour, IInteractable
{
    private Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void Interact()
    {
        anim.SetTrigger("Abrir");
    }
}
