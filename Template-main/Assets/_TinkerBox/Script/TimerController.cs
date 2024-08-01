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
   public GameObject TapToStartPanel;

   private float startM;
   private float startS;
   
   private SliderProgressController _progressController;
   private LevelStatusControllerCanvas ControllerCanvas;

   public double ClaculateTime()
   {
      var m = (startM*60) + startS;
      var c = (Minute * 60) + second;
      var total = (m - c);
      
      Debug.LogError($"minute : {m} , secc: {c} , total:{total}");
      return total;
   }
   private void Start()
   {
      startM = Minute;
      startS = second;
      
      TimerTMP.text = Minute.ToString("00") + ":" + second.ToString("00");

      _progressController = FindObjectOfType<SliderProgressController>();
      ControllerCanvas = FindObjectOfType<LevelStatusControllerCanvas>();

      TapToStartPanel.transform.DOScale(1.1f, 0.5f).SetEase(Ease.Linear).SetLoops(-2, LoopType.Yoyo);
      TimerTMP.transform.DOScale(1.05f, 0.25f).SetEase(Ease.Linear).SetLoops(-2,LoopType.Yoyo);
      TopPanel.DOAnchorPosY(300, 0.5f).SetEase(Ease.OutBack).SetDelay(0.5f).OnComplete(() =>
      {
         //TimerOn = true;
         
         RestartButton.SetActive(true);
      });

      float f = 0;
      DOTween.To(x => f = x, 0, 1, 0.2f).SetEase(Ease.Linear).OnComplete(() =>
      {
         TapToStartPanel.SetActive(true);

      });
   }

   private void Update()
   {

      if (Input.GetMouseButtonDown(0))
      {
         TapToStartPanel.SetActive(false);
         TimerOn = true;
      }
      
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
