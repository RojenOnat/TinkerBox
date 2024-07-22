using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class LevelStatusControllerCanvas : MonoBehaviour
{
    public Image SuccesBG;
    public Image FailBG;

    public GameObject SuccesPanel;
    public GameObject FailPanel;

    public void SuccesPanelActive()
    {
        SuccesPanel.SetActive(true);
        SuccesBG.DOFade(.5f, 0.1f).SetEase(Ease.Linear);
    }

    public void FailPanelActive()
    {
        FailPanel.SetActive(true);
        FailBG.DOFade(.5f, .1f).SetEase(Ease.Linear);
    }

    public void SuccesOnClick()
    {
        FindObjectOfType<GameManager>().SuccesLoadLevel();
    }

    public void FailOnClick()
    {
        FindObjectOfType<GameManager>().FailLoadLevel();
    }
    
    public void RestartOnClick()
    {
        FindObjectOfType<GameManager>().FailLoadLevel();
    }
}
