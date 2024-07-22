using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class TableScaler : MonoBehaviour
{
    private bool _canChange = true;

    public void ScaleFlash()
    {
        if(!_canChange) return;
        _canChange = false;

       // transform.DOPunchPosition(transform.position, .1f, 1, 0.015f).SetEase(Ease.Linear).SetLoops(2, LoopType.Yoyo);
        transform.DOScale(1.1f, 0.01f).SetEase(Ease.Linear).SetLoops(2, LoopType.Yoyo)
            .OnComplete(OnScaleFlashCompleted).SetDelay(0.01f);
    }

    private void OnScaleFlashCompleted()
    {
        _canChange = true;
    }
}
