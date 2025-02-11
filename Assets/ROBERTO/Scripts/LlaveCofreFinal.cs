using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LlaveCofreFinal : MonoBehaviour,IInteractable
{
    [SerializeField] private CofreFinal finalChest;
    public void Interact()
    {
        finalChest.TakeFinalKey();
        Destroy(gameObject);
    }
}
