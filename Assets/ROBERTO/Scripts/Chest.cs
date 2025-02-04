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
        eventManager.OnInteractChest += OpenPanel;
    }
    private void OnDisable()
    {
        eventManager.OnInteractChest -= OpenPanel;
    }
    public void Interact()
    {
        eventManager.InteractChest();
    }
    public void Open()
    {
        if (!isOpen)
        {
            isOpen = true;
            anim.SetTrigger("Abrir");
            passwordPanel.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1f;
        }
    }
    private void OpenPanel()
    {
        if (!isOpen)
        {
            passwordPanel.SetActive(true);
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
