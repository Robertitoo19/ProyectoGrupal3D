using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, IInteractable
{
    [SerializeField]
    private EventManagerSO eventManager;

    private Animator anim;
    private bool isOpen = false;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Interact()
    {
        //Se activa el paneñl.
        eventManager.ChestInteracted();
    }
    public void Open()
    {
        if (!isOpen)
        {
            isOpen = true;
            anim.SetTrigger("Abrir");
        }
    }
}
