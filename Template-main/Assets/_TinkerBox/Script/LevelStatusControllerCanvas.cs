using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using ElephantSDK;
using UnityEngine;
using UnityEngine.UI;

public class LevelStatusControllerCanvas : MonoBehaviour
{
    public Image SuccesBG;
    public Image FailBG;

    public GameObject SuccesPanel;
    public GameObject FailPanel;
    private TimerController _tc;
    private RayManager _rManager;


    private void Start()
    {
        _tc = FindObjectOfType<TimerController>();
        _rManager = FindObjectOfType<RayManager>();
        Elephant.LevelStarted(PlayerPrefs.GetInt("_SavedLevel"));
    }

    public void SuccesPanelActive()
    {
        SuccesPanel.SetActive(true);
        SuccesBG.DOFade(.75f, 0.1f).SetEase(Ease.Linear);
    }

    public void FailPanelActive()
    {
        FailPanel.SetActive(true);
        FailBG.DOFade(.75f, .1f).SetEase(Ease.Linear);
    }

    public void SuccesOnClick()
    {
        FindObjectOfType<GameManager>().SuccesLoadLevel();
        
        Elephant.LevelCompleted( PlayerPrefs.GetInt("_SavedLevel"));
        
        var a = Params.New();
        a.Set("time", _tc.ClaculateTime());
        
        var b = Params.New();
        a.Set("used_move_count", _rManager.GetClickCount());
        
        Elephant.LevelCompleted( PlayerPrefs.GetInt("_SavedLevel"),a);
        Elephant.LevelCompleted( PlayerPrefs.GetInt("_SavedLevel"),b);
        
        
    }

    public void FailOnClick()
    {
        FindObjectOfType<GameManager>().FailLoadLevel();
        Elephant.LevelFailed( PlayerPrefs.GetInt("_SavedLevel"));

    }
    
    public void RestartOnClick()
    {
        FindObjectOfType<GameManager>().FailLoadLevel();
    }
}
