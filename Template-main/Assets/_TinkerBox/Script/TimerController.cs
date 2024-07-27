using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class TimerController : MonoBehaviour
{
   public TextMeshProUGUI TimerTMP;
   public float Minute;
   public float second;
   public RectTransform TopPanel;
   public bool TimerOn = false;
   public GameObject RestartButton;

   private SliderProgressController _progressController;
   private LevelStatusControllerCanvas ControllerCanvas;

   private void Start()
   {
      _progressController = FindObjectOfType<SliderProgressController>();
      ControllerCanvas = FindObjectOfType<LevelStatusControllerCanvas>();
      
      TimerTMP.transform.DOScale(1.05f, 0.25f).SetEase(Ease.Linear).SetLoops(-2,LoopType.Yoyo);
      TopPanel.DOAnchorPosY(300, 0.5f).SetEase(Ease.OutBack).SetDelay(0.5f).OnComplete(() =>
      {
         TimerOn = true;
         RestartButton.SetActive(true);
      });
   }

   private void Update()
   {

      if(_progressController.IsSucces) return;
      
      if (TimerOn)
      {
         if (Minute>=0)
         {
            if (second>0)
            {
               second -= Time.deltaTime;
            }
            else
            {
               if (Minute!=0)
               {
                  Minute--;
                  second = 60;
               }
               else
               {
                  TimerOn = false;
                  if (!_progressController.IsSucces)
                  {
                     ControllerCanvas.FailPanelActive();

                     Debug.LogError("TIME IS UP!");
                  }
               }
            
            }

            TimerTMP.text = Minute.ToString("00") + ":" + second.ToString("00");
         }
      
      }
     
      
   }
}
