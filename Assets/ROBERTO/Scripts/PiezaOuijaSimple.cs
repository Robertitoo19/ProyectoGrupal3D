using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiezaOuijaSimple : MonoBehaviour,IInteractable
{
    public void Interact()
    {
        Destroy(gameObject);
    }
}
