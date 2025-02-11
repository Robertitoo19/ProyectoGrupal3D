using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBloq : MonoBehaviour
{
    [SerializeField] private Puerta1[] doors;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (Puerta1 door in doors)
            {
                door.BloqDoor();
            }
        }
    }
}
