using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class UIInfinityRotation : MonoBehaviour
{
    [SerializeField] private float duration;

    private void OnEnable()
    {
        transform.DOLocalRotate(Vector3.back * 360, duration, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart)
            .SetEase(Ease.Linear);
    }

    private void OnDisable()
    {
        transform.DOKill();
    }
}
