using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class LookableItem : MonoBehaviour
{
    private Vector3 initPosition;
    private Quaternion initRotation;

    private void Awake()
    {
        initPosition = transform.position;
        initRotation = transform.rotation;
    }
    public void Inspect(Transform lookPoint, float startInspectionDuration, Action OnComplete)
    {
        Sequence sequence = DOTween.Sequence();

        sequence.Join(transform.DOMove(lookPoint.position, startInspectionDuration));
        sequence.Join(transform.DORotateQuaternion(lookPoint.rotation,startInspectionDuration));

        sequence.OnComplete(() => OnComplete());
    }
    public void InspectAround(Vector2 rotationDirection)
    {
        transform.Rotate(new Vector3(rotationDirection.y, rotationDirection.x, 0) * Time.deltaTime, Space.World);


    }

    public void QuitInspection(float putBackInspectionDuration)
    {
        Sequence sequence = DOTween.Sequence();

        sequence.Join(transform.DOMove(initPosition,putBackInspectionDuration));
        sequence.Join(transform.DORotateQuaternion(initRotation,putBackInspectionDuration));
    }
}
