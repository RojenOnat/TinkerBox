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
    private FeedbackManager _fm;
    public AudioSource ASource;

    private TutorialController _tt;
    private BotListBase BLB;
    private BotTableMatchControl BTMC;
    private ReleaseButton _releaseButton;
    
    private void Start()
    {
        _botTextHolder = GetComponent<BotTextHolder>();
        _fm = FindObjectOfType<FeedbackManager>();
        _tt = FindObjectOfType<TutorialController>();
        BLB = FindObjectOfType<BotListBase>();
        BTMC = FindObjectOfType<BotTableMatchControl>();
        _releaseButton = FindObjectOfType<ReleaseButton>();
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
            HoldedTextList[i].transform.DOJump(goTo, 2.5f, 0, 0.15f).SetDelay(0.075f*i).OnComplete(() =>
            {
                TableObject.GetComponent<TableTextHolder>().DecreaseHoldedValue(1);
                _botTextHolder.DecreaseHoldedText(1);
                TableObject.GetComponent<TableScaler>().ScaleFlash();
                _fm.OnLightVibrate();
                ASource.Play();
                ASource.pitch += 0.03f;
            });
            
            
        }

        Invoke(nameof(CheckList),.6f);

        if (_tt != null)
        {
            Invoke(nameof(Tuto),.65f);
        }
    }

    private void CheckList()
    {
        //BTMC.EveryTableIsLastChair(BLB.BotList[0].GetComponent<BotTextHolder>().HoldedValue);
        
        for (int i = 0; i < 30; i++)
        {
            BTMC.ControlLast();
        }
        
        BLB.check = true;
        //StartCoroutine(goo());
    }

    private void Tuto()
    {
        _tt.HandActive();
    }

    IEnumerator goo()
    {
        for (int i = 0; i < 20; i++)
        {
            BTMC.ControlLast();
            if(!BTMC.IsMatched(_botTextHolder.HoldedValue)) _releaseButton.ReleaseIt();

            yield return new WaitForSeconds(0.001f);
        }
    }
    
}
