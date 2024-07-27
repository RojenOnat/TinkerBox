using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Pathfinding;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ReleaseButton : MonoBehaviour
{
    private BotListBase BListBase;
    public TextMeshProUGUI CountTmp;
    public int MaxCount;
    private int currentCount;
    public Image ButtonImage;
    public TextMeshProUGUI ButtonTMP;
    public Image CountBG;
    private void Start()
    {
        BListBase = FindObjectOfType<BotListBase>();
        SetReleaseCountTMP();
    }

    private void RaiseReleaseCount()
    {
        currentCount++;
        SetReleaseCountTMP();
    }

    private void Update()
    {
        if (currentCount >= MaxCount)
        {
            ButtonTMP.DOFade(0.25f,0.1f);
            ButtonImage.DOFade(0.25f,0.1f);
            CountTmp.DOFade(0.25f, 0.1f);
            CountBG.DOFade(0.25f, 0.1f);
        }
    }

    private void SetReleaseCountTMP()
    {
        CountTmp.text = currentCount.ToString("0")+"/"+MaxCount.ToString("0");
    }
    public void ReleaseIt()
    {
        if(currentCount>=MaxCount) return;
        
        var a =BListBase.GetFirstBot();
        BListBase.BotList.Remove(a);
        GameObject go = Instantiate(new GameObject(), new Vector3(7, 0.5f, .5f), Quaternion.identity);
        a.GetComponent<BotAIDestinationSetter>().target = go.transform;

        a.GetComponent<BotAIReachedController>().IsClearState = true;
        a.GetComponent<BotColorChanger>().SetColor(Color.red);
        //RaiseReleaseCount();
    }

    public void ReleaseIt(List<GameObject> go)
    {
        GameObject go1 = Instantiate(new GameObject(), new Vector3(7, 0.5f, .5f), Quaternion.identity);
        //AstarPath.active.Scan();

        for (int i = 0; i < go.Count; i++)
        {

           // go[i].AddComponent<AIPath>();
            //go[i].GetComponent<BotAIReachedController>().IsClearState = true;

            go[i].GetComponent<BotAIDestinationSetter>().enabled = false;
            //go[i].GetComponent<AIPath>().SearchPath();

            

           // go[i].GetComponent<AIPath>().speed = 10f;
            //go[i].GetComponent<AIPath>().maxAcceleration = 5f;
            //Debug.Log(go[i].GetComponent<AIPath>().hasPath + " " +go[i].GetComponent<AIPath>().maxAcceleration +  " " + go[i].GetComponent<AIPath>().speed );

            go[i].GetComponent<BotColorChanger>().SetColor(Color.green);

           go[i].transform.DOMove(go1.transform.position, 1f).SetEase(Ease.Linear);
            go[i].transform.DOLookAt(go1.transform.position, 1f).SetEase(Ease.Linear);

        }
    }
}
