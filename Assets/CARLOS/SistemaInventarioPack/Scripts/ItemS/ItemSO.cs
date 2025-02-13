using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item")]
[Serializable]
public class ItemSO : ScriptableObject
{
    public string itemName;

    public Sprite icon;
}
