using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class HandController : MonoBehaviour
{
    public GameObject HandCanvas;
    public GameObject HandUI;

    private void Start()
    {
        DOTween.SetTweensCapacity(5000,5000);
    }

    public void SetHand(bool isActive)
    {
        if (isActive)
        {
            
            HandCanvas.SetActive(true);
            HandUI.transform.DOScale(1.2f, 0.4f).SetEase(Ease.Linear).SetLoops(-2, LoopType.Yoyo).From(Vector3.one);
        }
        else
        {
            HandUI.transform.localScale = Vector3.one;
            HandCanvas.SetActive(false);
            
        }
    }
}
