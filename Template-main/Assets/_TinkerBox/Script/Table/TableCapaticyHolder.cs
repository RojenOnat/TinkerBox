using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.Feel;
using UnityEngine;

public class TableCapaticyHolder : MonoBehaviour
{
    public List<bool> TableCapacityList;


    public void ChangeCapacity(int count) => TableCapacityList = new List<bool>(count);

    public int GetEmptyChairCount()
    {
        int a = 0;

        for (int i = 0; i < TableCapacityList.Count; i++)
        {
            if (!TableCapacityList[i]) a++;
        }

        return a;
    }
    public bool IsLastChair()
    {
        if (TableCapacityList[^2])
        {
            //Debug.LogError("SONN SANDALYE");
            return true;
        }
        
        return false;
    }

    public void SetTableBoolState(int index, bool status)
    {
        for (int i = 0; i < TableCapacityList.Count; i++)
        {
            if (i == index) TableCapacityList[i] = status;
        }
    }
    
    public void SetTableBoolState(bool reset)
    {
      if(!reset) return;
      
      for (int i = 0; i < TableCapacityList.Count; i++)
      {
          TableCapacityList[i] = false;
      }
    }
    

}
