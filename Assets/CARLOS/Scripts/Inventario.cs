using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour
{
    [SerializeField] private GameObject[] items;
    [SerializeField] private bool[] tieneItem;
    private GameObject equiparItem;
    bool estaCambiandoItem = false;
    int itemNº = -1;

    private Animator anim;

    public int ItemNº { get => itemNº; set => itemNº = value; }

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void CambiarArma()
    {
        int itemNº = -1;
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            itemNº = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            itemNº = 1;
        }
        else if ((Input.GetKeyDown(KeyCode.Alpha3)))
        {
            itemNº = 2;
        }
        if (itemNº >= 0 && itemNº < items.Length && tieneItem[itemNº])
        {
            if (equiparItem != null)
            {
                items[itemNº].SetActive(false);
                equiparItem.SetActive(false);
            }

            equiparItem = items[itemNº];
            items[itemNº].SetActive(true);

            anim.SetTrigger("swap");
            estaCambiandoItem = true;

            Invoke("TerminarCambiarArma", 0.4f);
        }
    }
}
