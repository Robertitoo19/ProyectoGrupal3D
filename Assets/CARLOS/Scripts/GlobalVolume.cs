using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class GlobalVolume : MonoBehaviour
{
    [SerializeField] private EventManagerSO eventManager;
    private Volume volume;

    private DepthOfField dof;


    private float dofInitialValue;
    private float dofCurrentValue;

    private void Awake()
    {
        volume = GetComponent<Volume>();
        if(volume.profile.TryGet(out DepthOfField dOf))
        {
            dof = dOf;
            dofInitialValue = dof.focusDistance.value;
            dofCurrentValue = dofInitialValue;
        }

    }

    private void OnEnable()
    {
        eventManager.OnInspecting += EnableDOF;
        eventManager.OnStopInspecting += DisableDOF;
    }

    private void EnableDOF(float duration, float distance)
    {
        DOTween.To(() => dofCurrentValue, x => dofCurrentValue = x, distance, duration).
            OnUpdate(() => dof.focusDistance.value = dofCurrentValue);
    }
    private void DisableDOF(float duration)
    {
        DOTween.To(() => dofCurrentValue, x => dofCurrentValue = x, dofInitialValue, duration).
            OnUpdate(() => dof.focusDistance.value = dofCurrentValue);
    }

}
