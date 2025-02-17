using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Event manager")]
public class EventManagerSO : ScriptableObject
{
    public event Action<float, float> OnInspecting;
    public event Action<float> OnStopInspecting;




    public event Action OnNewInteractuable;
    public event Action OnNoInteractuable;
    public event Action OnInteractChest;
    public void NewInteractuable()
    {
        OnNewInteractuable?.Invoke();
    }
    public void NoInteractuable()
    {
        OnNoInteractuable?.Invoke();
    }
    public void InteractChest()
    {
        OnInteractChest?.Invoke();
    }




    public void PlayerStartsInspecting(float duration, float inspectionDistance)
    {
        OnInspecting?.Invoke(duration, inspectionDistance);
    }
    public void PlayersStopsInspecting(float quitInspectionDuration)
    {
        OnStopInspecting?.Invoke(quitInspectionDuration);
    }
}
