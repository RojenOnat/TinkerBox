using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class TextInstantor : MonoBehaviour
{
    public GameObject TextPrefab;
    private BotTextHolder _botTextHolder;
    public List<GameObject> HoldedTextList;

    public GameObject TableObject;
    private void Start()
    {
        _botTextHolder = GetComponent<BotTextHolder>();
        
       
    }

    public void AddTableListThisBot()
    {
        TableObject.GetComponent<TableBotHolder>().HoldedBot.Add(gameObject);
    }
    
    public void InstText(int count)
    {
        
        
        for (int i = 0; i < count; i++)
        {
            GameObject go = Instantiate(TextPrefab, transform.position, TextPrefab.transform.rotation);
            go.transform.parent = transform;
            HoldedTextList.Add(go);
        }
    }

    public void OnTextJumpToTarget()
    {
        
        for (int i = 0; i < HoldedTextList.Count; i++)
        {
            HoldedTextList[i].transform.DOLookAt(-Camera.main.transform.position, 0.01f, AxisConstraint.X);

                
            HoldedTextList[i].SetActive(true);
            var goTo = TableObject.transform.position + Vector3.down;
            HoldedTextList[i].transform.DOJump(goTo, 2.5f, 0, 0.2f).SetDelay(0.075f*i).OnComplete(() =>
            {
                TableObject.GetComponent<TableTextHolder>().DecreaseHoldedValue(1);
                _botTextHolder.DecreaseHoldedText(1);
                TableObject.GetComponent<TableScaler>().ScaleFlash();
            });
            

        }
    }
}
