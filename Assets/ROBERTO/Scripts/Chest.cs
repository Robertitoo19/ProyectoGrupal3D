using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, IInteractable
{
    [SerializeField] private EventManagerSO eventManager;

    [SerializeField] private GameObject passwordPanel;
    private Animator anim;
    private bool isOpen = false;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnEnable()
    {

    }
    public void Interact()
    {
        passwordPanel.SetActive(true);
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
