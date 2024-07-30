using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class BotTableMatchControl : MonoBehaviour
{
    public List<TableTextHolder> TList;
    private ReleaseButton _releaseButton;
    private BotListBase _blb;
    private float f = 2.5f;
    private void Start()
    {
        _releaseButton = FindObjectOfType<ReleaseButton>();
        _blb = FindObjectOfType<BotListBase>();
    }

    [Button]
    public void FindTableTextHolders()
    {
        TList.Clear();
            foreach (var VARIABLE in FindObjectsOfType<TableTextHolder>())
            {
                TList.Add(VARIABLE);
            }
        
    }

  

    
    
    public bool IsMatched(int value)
    {
        var sum = 0;
        var sum2 = 0;
        
       for (int i = 0; i < TList.Count; i++)
        {

            if (value > TList[i].HoldedValue)
            {
                sum++;
            }
        }
       
        for (int i = 0; i < TList.Count; i++)
        {
            if (TList[i].GetComponent<TableCapaticyHolder>().IsLastChair())
            {
                if (value != TList[i].HoldedValue)
                {
                    sum2++;
                }
            }
          
        }
        //Debug.Log(sum+" "+TList.Count/2f);
//        Debug.Log(sum+" "+sum2);
        if (sum2 == TList.Count) return false;
        if (sum == (TList.Count)) return false;
        
        return true;
        
    }
    
    private bool CheckList()
    {
        for (int i = 0; i < TList.Count; i++)
        {
            if (_blb.BotList[0].GetComponent<BotTextHolder>().HoldedValue == TList[i].HoldedValue)
            {
                return true;
            }
            
            
        }

        return false;
    }

    private int Greatherthan()
    {
        var sum = 0;
        for (int i = 0; i < TList.Count; i++)
        {
            
            if (_blb.BotList[0].GetComponent<BotTextHolder>().HoldedValue > TList[i].HoldedValue &&
                _blb.BotList[0].GetComponent<BotTextHolder>().HoldedValue != TList[i].HoldedValue)
            {
                sum++;
            }
        }

        return sum;
    }
    
    private void Update()
    {
      /*  if (EveryTableIsLastChair()>(TList.Count/2))
        {
            Debug.Log(EveryTableIsLastChair() + " " + TList.Count/2);
            if (!CheckList())
            {
                _releaseButton.ReleaseIt();

            }
        }*/

    /*  if (f>0)
      {
          f -= Time.fixedDeltaTime;
      }
      else
      {
          f = 2.5f;
      }*/
      
      
      //ControlLast();
      
    }

    public void ControlLast()
    {
        //Debug.Log($"Full Count : {GetFullTableCount()} , get t list: {TList.Count/2 + (1)}");
     /*   if (GetFullTableCount()>(TList.Count/2) )
        {
            var sum = 0;
            for (int i = 0; i < TList.Count; i++)
            {
                if (_blb.BotList[0].GetComponent<BotTextHolder>().HoldedValue != 
                    TList[i].HoldedValue)
                {
                    sum++;
                }
            }
            if(sum==TList.Count) _releaseButton.ReleaseIt();
        }*/

     for (int i = 0; i < 20; i++)
     {
         if(Greatherthan() == (TList.Count-1)) _releaseButton.ReleaseIt();

     }

    }
    
    
    public int GetFullTableCount()
    {
        var sum = 0;
        
        for (int i = 0; i < TList.Count; i++)
        {
            if (TList[i].GetComponent<TableCapaticyHolder>().IsLastChair())
            {
                sum++;
            }
          
        }

        return sum;
    }
}
