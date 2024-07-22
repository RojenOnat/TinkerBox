using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class BotPositionSetter : MonoBehaviour

{
   public Transform StartPos;
   
   [SerializeField] private float _offset;

   private BotListBase _bListBase;
   
   
   private void Start()
   {
      _bListBase = GetComponent<BotListBase>();
   }

   private void Update()
   {
      SetBotPosition();
   }

   /// <summary />
   public void SetBotPosition()
   {
      if(_bListBase.BotList.Count==0) return;
      
      for (int i = 0; i < _bListBase.BotList.Count; i++)
      {
         if(_bListBase.BotList[i] == null) return;
         var BotMovement = _bListBase.BotList[i].GetComponent<BotMovement>();
       //Todo: sıralaması açık mı kapalı mı kontrolü yapmam gerek.
       if (BotMovement.CanMove)
       {
          var goTo = StartPos.position - new Vector3(0, 0, i * _offset);
          var dist = Vector3.Distance(_bListBase.BotList[i].transform.position, goTo);
         
          if (dist>0.25f)
          {
             //Debug.Log($"Bot need to move position. Bot number {i}");
             BotMovement.MoveToTarget(goTo);
          }
       }
         
      }
   }

}
