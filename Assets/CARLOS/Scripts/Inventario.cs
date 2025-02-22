using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour
{
    [SerializeField] private GameObject[] items;
    [SerializeField] private bool[] tieneItem;
    private GameObject equiparItem;
    bool estaCambiandoItem = false;
    int itemN� = -1;

    private Animator anim;

    public int ItemN� { get => itemN�; set => itemN� = value; }
    public GameObject[] Items { get => items; set => items = value; }

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void CambiarArma()
    {
        int itemN� = -1;
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            itemN� = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            itemN� = 1;
        }
        else if ((Input.GetKeyDown(KeyCode.Alpha3)))
        {
            itemN� = 2;
        }
        if (itemN� >= 0 && itemN� < Items.Length && tieneItem[itemN�])
        {
            if (equiparItem != null)
            {
                Items[itemN�].SetActive(false);
                equiparItem.SetActive(false);
            }

            equiparItem = Items[itemN�];
            Items[itemN�].SetActive(true);

            anim.SetTrigger("swap");
            estaCambiandoItem = true;

            Invoke("TerminarCambiarArma", 0.4f);
        }
    }
}
