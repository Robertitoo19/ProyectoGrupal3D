using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private Animator anim;
    private bool isOpen = false;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void OpenChest()
    {
        if (!isOpen)
        {
            isOpen = true;
            anim.SetTrigger("Abrir");
        }
    }
}
