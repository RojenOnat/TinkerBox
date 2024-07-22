using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class BotScaler : MonoBehaviour
{
    private bool _canChange = true;

    public void ScaleFlashY()
    {
        if(!_canChange) return;
        _canChange = false;
        
        transform.DOScaleY(1.25f, 0.5f).SetEase(Ease.Linear).SetLoops(2, LoopType.Yoyo)
            .OnComplete(OnScaleFlashCompleted);
    }

    public void SetStartScale()
    {
        if(!_canChange) return;
        _canChange = false;
        
        transform.DOScale(.75f, 0.1f).SetEase(Ease.Linear)
            .OnComplete(OnScaleFlashCompleted);
    }
    
    public void ScaleUp()
    {
        if(!_canChange) return;
        _canChange = false;
        
        transform.DOScale(.85f, 0.1f).SetEase(Ease.OutBack)
            .OnComplete(OnScaleFlashCompleted);
    }
    
    public void ScaleFlashXYZ()
    {
        if(!_canChange) return;
        _canChange = false;
        
        transform.DOScale(1.25f, 0.5f).SetEase(Ease.Linear).SetLoops(2, LoopType.Yoyo)
            .OnComplete(OnScaleFlashCompleted);
    }

    private void OnScaleFlashCompleted()
    {
        _canChange = true;
    }
}
