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
        
        var c = PlayerPrefs.GetInt("_SavedLevel")-1;
        Debug.LogError($"LEVEL STARTED: {c}");
        Elephant.LevelStarted(c);
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
        
        var currentLevel = PlayerPrefs.GetInt("_SavedLevel")-1;

        Debug.LogError($"LEVEL SUCCES: {currentLevel}");
        
        
        
        
        
        
        //Debug.LogError($"TIME:{ _tc.ClaculateTime()}");
        
       
        
       // Debug.LogError(_rManager.GetClickCount());

       var p = Params.New()
           .Set("used_move_count", _rManager.GetClickCount())
           .Set("time", _tc.ClaculateTime());
       
       /*Elephant.Event("level_completed", currentLevel,p);
       Elephant.l*/

        Elephant.LevelCompleted(currentLevel,p);

        
        FindObjectOfType<GameManager>().SuccesLoadLevel();

    }

    public void FailOnClick()
    {
        var currentLevel = PlayerPrefs.GetInt("_SavedLevel") - 1;
        
        
        var p = Params.New()
            .Set("used_move_count", _rManager.GetClickCount())
            .Set("time", _tc.ClaculateTime());
       
        //Elephant.Event("level_failed", currentLevel,p);
        Elephant.LevelFailed(currentLevel,p);

            
        Debug.LogError($"FAILED: {currentLevel}");
        FindObjectOfType<GameManager>().FailLoadLevel();

    }
    
    public void RestartOnClick()
    {
        var currentLevel = PlayerPrefs.GetInt("_SavedLevel") - 1;
        
        
        var p = Params.New()
            .Set("used_move_count", _rManager.GetClickCount())
            .Set("time", _tc.ClaculateTime());
       
        //Elephant.Event("level_failed", currentLevel,p);
        Elephant.LevelFailed(currentLevel,p);

        
        FindObjectOfType<GameManager>().FailLoadLevel();
    }
}
