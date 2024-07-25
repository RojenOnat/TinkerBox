using System;
using System.Collections;
using System.Collections.Generic;

using DG.Tweening;
using UnityEngine;


public class BotMovement : MonoBehaviour
{
   public bool CanMove;
   private BotAnimatorController _botAnimatorController;
   
   private BotListBase _botListBase;
   private BotColorChanger _botColorChanger;
   private BotScaler _botScaler;
   private BotTextHolder _botTextHolder;

   private void Start()
   {
      _botTextHolder = GetComponent<BotTextHolder>();
      _botScaler = GetComponent<BotScaler>();
      _botColorChanger = GetComponent<BotColorChanger>();
   }

   private void Awake()
   {
      _botAnimatorController = GetComponent<BotAnimatorController>();
      _botListBase = FindObjectOfType<BotListBase>();
   }

   public void MoveToTarget(Vector3 goTo)
   {
      if(!CanMove) return;

      CanMove = false;
      
      _botAnimatorController.SetWalkState(true);
      transform.DOMove(goTo, .15f).SetEase(Ease.Linear).OnComplete(() =>
      {
         OnReachedMovement();
      });
   }

   public void OnReachedMovement()
   {
      CanMove = true;
      _botAnimatorController.SetWalkState(false);

      if (_botListBase.BotList[0].gameObject == gameObject)
      {
         _botColorChanger.SetColor(Color.white);

         _botScaler.ScaleUp();
         
         if (!_botTextHolder.ShowText)
         {
            _botTextHolder.TextEnable();
         }
      }
      //Debug.Log("Movement is ended.");
   }
}
