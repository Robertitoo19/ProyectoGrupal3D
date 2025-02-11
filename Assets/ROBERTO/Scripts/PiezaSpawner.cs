using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiezaSpawner : MonoBehaviour, IInteractable
{
    [SerializeField] private Spawner spawner;
    public void Interact()
    {
        spawner.ActivateSpawner();
        Destroy(gameObject);
    }
}
