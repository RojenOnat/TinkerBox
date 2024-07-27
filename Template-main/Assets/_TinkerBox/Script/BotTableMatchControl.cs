using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotTableMatchControl : MonoBehaviour
{
    public List<TableTextHolder> TList;


    public bool IsMatched(int value)
    {
        var sum = 0;
        
        for (int i = 0; i < TList.Count; i++)
        {

            if (value > TList[i].CurrentHoldedValue)
            {
                sum++;
            }
        }

        if (sum == TList.Count) return false;
        
        return true;
    }

    private void Update()
    {
        
    }
}
