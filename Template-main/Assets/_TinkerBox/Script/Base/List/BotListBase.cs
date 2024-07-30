using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotListBase : MonoBehaviour
{
    public List<GameObject> BotList;

    public bool CanClickable = false;
    public bool check = false;
    private BotTableMatchControl _btmc;
    private ReleaseButton _releaseButton;

    private void Start()
    {
        _btmc = FindObjectOfType<BotTableMatchControl>();
        _releaseButton = FindObjectOfType<ReleaseButton>();
    }

    public GameObject GetFirstBot()
    {
        if(BotList.Count>0) return BotList[0].gameObject;

        return null;
    }
    private void Update()
    {
        ClearNullBots();

        CanClickable = CheckClickable();

        if (check)
        {
            if (BotList.Count>0)
            {
                if (!_btmc.IsMatched(BotList[0].GetComponent<BotTextHolder>().HoldedValue))
                {
                    _releaseButton.ReleaseIt();
                }
                else
                {
                    check = false;
                }
            }
        }
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
