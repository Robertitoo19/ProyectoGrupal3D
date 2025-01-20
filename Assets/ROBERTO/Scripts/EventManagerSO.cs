using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Event manager")]
public class EventManagerSO : ScriptableObject
{
    public event Action OnNewInteractuable;
    public event Action OnNoInteractuable;
    public void NewInteractuable()
    {
        OnNewInteractuable?.Invoke();
    }
    public void NoInteractuable()
    {
        OnNoInteractuable?.Invoke();
    }
}
