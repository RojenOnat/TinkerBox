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
         GetComponent<BotColorChanger>().SetColor(Color.white);

         GetComponent<BotScaler>().ScaleUp();
         
         if (!GetComponent<BotTextHolder>().ShowText)
         {
            GetComponent<BotTextHolder>().TextEnable();
         }
      }
      //Debug.Log("Movement is ended.");
   }
}
