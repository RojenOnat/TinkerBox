using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotListBase : MonoBehaviour
{
    public List<GameObject> BotList;

    public bool CanClickable = false;

    public GameObject GetFirstBot()
    {
        if(BotList.Count>0) return BotList[0].gameObject;

        return null;
    }
    private void Update()
    {
        ClearNullBots();

        CanClickable = CheckClickable();
    }

    private bool CheckClickable()
    {
        for (int i = 0; i < BotList.Count; i++)
        {
            if (!BotList[i].GetComponent<BotMovement>().CanMove) return false;
        }

        return true;
    }
    private void ClearNullBots()
    {
        if (BotList.Count>0)
        {
            for (int i = 0; i < BotList.Count; i++)
            {
                if (BotList[i] == null) BotList.RemoveAt(i);
            }
        }else if (BotList.Count==0)
        {
            Debug.LogError("BOTNO ");
        }
    }
}
