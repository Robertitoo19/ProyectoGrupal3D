using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LlaveCasa : MonoBehaviour,IInteractable
{
    [SerializeField] private Puerta1[] doors;
    public void Interact()
    {
        foreach (Puerta1 door in doors)
        {
            door.takeKey(); 
        }
        Destroy(gameObject);
    }
}
