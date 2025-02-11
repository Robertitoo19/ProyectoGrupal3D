using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crowbar : MonoBehaviour,IInteractable
{
    [SerializeField] private Puerta1[] doors;
    [SerializeField] private Collider collBloq;

    public void Interact()
    {
        Debug.Log("coger palanca desbloqueo puertas");
        foreach (Puerta1 door in doors)
        {
            door.UnlockDoor();
            collBloq.enabled = false;
            Debug.Log("desbloqueando:" + door.gameObject.name);
        }
        Destroy(gameObject);
    }
}
