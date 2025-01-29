using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour
{
    [SerializeField] private GameObject[] items;
    [SerializeField] private bool tieneItem;
    private GameObject equiparItem;
    int itemN� = -1;


    public int ItemN� { get => itemN�; set => itemN� = value; }

    private void Start()
    {
        
    }
    public void CambiarArma()
    {
        int itemN� = -1;
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
             itemN�= 0;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            itemN� = 1;
        }
        else if ((Input.GetKeyDown(KeyCode.Alpha3)))
        {
            itemN� = 2;
        }
        if (itemN� >= 0 && itemN� < items.Length && tieneItem[itemN�])
        {
            if (equiparItem != null)
            {
                items[itemN�].SetActive(false);
                equiparItem.SetActive(false);
            }

            equiparItem = items[itemN�];
            items[itemN�].SetActive(true);

            animator.SetTrigger("swap");
            estaCambiandoArma = true;

            Invoke("TerminarCambiarArma", 0.4f);
        }
    }
}
