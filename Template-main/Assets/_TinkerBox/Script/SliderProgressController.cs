using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderProgressController : MonoBehaviour
{
    public Image SliderImage;
    public int LevelGoal;
    private float currentSliderValue;
    public TextMeshProUGUI SliderGoalText;
    public RectTransform MaskRect;
    public bool IsComplete = false;
    private AudioManager _aManager;

    public LevelStatusControllerCanvas ControllerCanvas;

    public TextMeshProUGUI LevelTMP;

    private void Start()
    {
        SetLevelText();
        SliderGoalText.text = "0/" + LevelGoal.ToString("0");
        _aManager = FindObjectOfType<AudioManager>();
        MaskRect.DOAnchorPosX(400, 2.5f).SetEase(Ease.Linear).SetLoops(-2, LoopType.Restart).SetDelay(0.25f);
    }

    public void RaiseSlider(int value)
    {
        Debug.LogError(value);
        currentSliderValue += ((float)value / LevelGoal);
        //Debug.LogError(currentSliderValue);

        SliderImage.DOFillAmount(currentSliderValue, 0.1f).SetEase(Ease.Linear).OnUpdate(() =>
        {
            var a = currentSliderValue * LevelGoal;
            SliderGoalText.text = a.ToString("0") + "/" + LevelGoal.ToString("0");
        }).OnComplete(SliderValueController);
    }

    private int GetSavedLevel()
    {
        return PlayerPrefs.GetInt("_savedLevelKey")+1;
    }

    private void RaiseSavedLevel()
    {
        var a = GetSavedLevel();
        PlayerPrefs.SetInt("_savedLevelKey",a);
    }

    private void SetLevelText()
    {
        LevelTMP.text = "Level" + " " + GetSavedLevel().ToString("0");
    }
    private void SliderValueController()
    {
        var a = currentSliderValue * LevelGoal;
        Debug.LogError(a);
        if (a >= LevelGoal )
        {
            _aManager.PlaySuccesSound();
            Debug.LogError("LEVEL UP PANEL ACTİVE");
            RaiseSavedLevel();
            ControllerCanvas.SuccesPanelActive();
            IsComplete = true;
        }

    }
    
   
}
