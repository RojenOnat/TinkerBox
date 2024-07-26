using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class BotColorChanger : MonoBehaviour
{
    public SkinnedMeshRenderer SMR;
    private bool _canChange = true;
    private bool _changed = false;
    public void RedFlash()
    {
        if(!_canChange) return;
        _canChange = false;
        
        SMR.material.DOColor(Color.red, 0.25f).SetEase(Ease.Linear).SetLoops(2, LoopType.Yoyo).
            OnComplete(OnColorFlashEnd);
    }

    public void SetColor(Color c)
    {
        //if(_changed) return;
        SMR.material.DOColor(c, 0.1f).SetEase(Ease.Linear);
        _changed = true;
    }

    private void OnColorFlashEnd()
    {
        _canChange = true;
    }
}
