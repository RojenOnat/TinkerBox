using System;
using System.Collections;
using System.Collections.Generic;

using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;


public class BotMovement : MonoBehaviour
{
   public bool CanMove;
   private BotAnimatorController _botAnimatorController;
   
   private BotListBase _botListBase;
   private BotColorChanger _botColorChanger;
   private BotScaler _botScaler;
   private BotTextHolder _botTextHolder;
   public AudioSource ASource;
   private BotTableMatchControl _matchControl;
   private ReleaseButton _releaseButton;
   
   private void Start()
   {
      _botTextHolder = GetComponent<BotTextHolder>();
      _botScaler = GetComponent<BotScaler>();
      _botColorChanger = GetComponent<BotColorChanger>();
      ASource.pitch += Random.Range(-0.2f, 0.2f);
      _matchControl = FindObjectOfType<BotTableMatchControl>();
      _releaseButton = FindObjectOfType<ReleaseButton>();
      
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
      
      transform.DOMove(goTo, .1f).SetEase(Ease.Linear).OnComplete(OnReachedMovement);
   }

 

   public void OnReachedMovement()
   {
      CanMove = true;
      _botAnimatorController.SetWalkState(false);

      if (_botListBase.BotList[0].gameObject == gameObject)
      {
         //_botColorChanger.SetColor(Color.white);
         ASource.Play();
         _botScaler.ScaleUp();

        // if(tt!=null) tt.HandActive();
         
         
         if (!_botTextHolder.ShowText)
         {
            _botTextHolder.TextEnable();
         }
         
         if(!_matchControl.IsMatched(_botTextHolder.HoldedValue)) _releaseButton.ReleaseIt();

      }
      //Debug.Log("Movement is ended.");
   }

   private void Update()
   {
      if (transform.position.x>=5f)
      {
         gameObject.SetActive(false);
      }
   }
}
