using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialController : MonoBehaviour
{
    private BotListBase BBase;

    public List<TableTextHolder> TText;
    void Start()
    {
        BBase = FindObjectOfType<BotListBase>();
        Invoke("HandActive",.2f);
    }

    private void Update()
    {
        //HandActive();
    }

    public void HandActive()
    {

        for (int i = 0; i < TText.Count; i++)
        {
            if (TText[i].GetComponent<TableCapaticyHolder>().IsLastChair())
            {
                if (BBase.BotList[0].GetComponent<BotTextHolder>().HoldedValue ==TText[i].CurrentHoldedValue)
                {
                    TText[i].transform.GetChild(2).GetComponent<BoxCollider>().enabled = true;
                    TText[i].GetComponent<HandController>().SetHand(true);
                    if (i == 0)
                    {
                        TText[i+1].transform.GetChild(2).GetComponent<BoxCollider>().enabled = false;
                        TText[i+1].GetComponent<HandController>().SetHand(false);
                    }
                    
                    if (i == 1)
                    {
                        TText[i-1].transform.GetChild(2).GetComponent<BoxCollider>().enabled = false;
                        TText[i-1].GetComponent<HandController>().SetHand(false);

                    }
                    break;
                }
            }
        }
        
        for (int i = 0; i < TText.Count; i++)
        {
            if (TText[i].GetComponent<TableCapaticyHolder>().IsLastChair())
            {
                if (BBase.BotList[0].GetComponent<BotTextHolder>().HoldedValue ==TText[i].CurrentHoldedValue )
                {
                    TText[i].transform.GetChild(2).GetComponent<BoxCollider>().enabled = true;
                    TText[i].GetComponent<HandController>().SetHand(true);
                    if (i == 0)
                    {
                        TText[i+1].transform.GetChild(2).GetComponent<BoxCollider>().enabled = false;
                        TText[i+1].GetComponent<HandController>().SetHand(false);
                    }
                    
                    if (i == 1)
                    {
                        TText[i-1].transform.GetChild(2).GetComponent<BoxCollider>().enabled = false;
                        TText[i-1].GetComponent<HandController>().SetHand(false);

                    }
                    break;
                }
            }
            else
            {
                if (BBase.BotList[0].GetComponent<BotTextHolder>().HoldedValue <= TText[i].CurrentHoldedValue)
                {
                    TText[i].transform.GetChild(2).GetComponent<BoxCollider>().enabled = true;
                    TText[i].GetComponent<HandController>().SetHand(true);
                    if (i == 0)
                    {
                        TText[i+1].transform.GetChild(2).GetComponent<BoxCollider>().enabled = false;
                        TText[i+1].GetComponent<HandController>().SetHand(false);

                    }

                    if (i == 1)
                    {
                        TText[i-1].transform.GetChild(2).GetComponent<BoxCollider>().enabled = false;
                        TText[i-1].GetComponent<HandController>().SetHand(false);

                    }
                    break;
                }
           
            }
          
        }
    }
    
}
