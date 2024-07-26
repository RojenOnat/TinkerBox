using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableCalculator : MonoBehaviour
{
    private TableCapaticyHolder _tableCapaticyHolder;
    private TableTextHolder _tableTextHolder;

    private float delayer = 1.25f;
    private void Start()
    {
        _tableTextHolder = GetComponent<TableTextHolder>();
        _tableCapaticyHolder = GetComponent<TableCapaticyHolder>();
    }

    private void Update()
    {

        //TableFalseMatchControl();
    }

    public void TableFalseMatchControl()
    {
        if (_tableCapaticyHolder.TableCapacityList.Count>=3)
        {
            if (_tableTextHolder.CurrentHoldedValue<_tableCapaticyHolder.GetEmptyChairCount())
            {
                if (delayer>0)
                {
                    delayer -= Time.deltaTime;
                }
                else
                {
                    delayer = 1.25f;
                    for (int i = 0; i < GetComponent<TableBotHolder>().HoldedBot.Count; i++)
                    {
                        GetComponent<TableBotHolder>().HoldedBot[i].GetComponent<BotColorChanger>().SetColor(Color.red);
                    }
                    GetComponent<TableSuccesProcces>().OnSucces();
                    Debug.LogError("TABLE FAİL");

                }
            }
        }    
    }

    public bool BotCanSit(int botHoldedValue)
    {
        //Debug.LogError(_tableCapaticyHolder.IsLastChair());
       /* if (_tableCapaticyHolder.IsLastChair())
        {
            if (botHoldedValue != _tableTextHolder.CurrentHoldedValue)
            {
                //Debug.LogError("SON SANDALYE ANCAK DEGER ESİT DEGİL.");

                return false;
            }
            else
            {
                //Debug.LogError("SON SANDALYE ANCAK DEGER ESİT .");

                return true;

            }
        }
        else
        {
            //Debug.LogError("SON SANDALYE DEGİL.");
            if (botHoldedValue < _tableTextHolder.CurrentHoldedValue) return true;
        }*/

       if (_tableCapaticyHolder.IsLastChair())
       {
           if (botHoldedValue != _tableTextHolder.CurrentHoldedValue) return false;
       }
      
       if (botHoldedValue <= _tableTextHolder.CurrentHoldedValue) return true;
       
       return false;
    }
}
