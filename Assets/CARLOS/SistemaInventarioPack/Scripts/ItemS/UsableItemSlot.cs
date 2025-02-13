using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UsableItemSlot : ItemSlot
{
    [SerializeField]
    private GameManagerSO gM;

    [SerializeField]
    private int slotIndex;
}
