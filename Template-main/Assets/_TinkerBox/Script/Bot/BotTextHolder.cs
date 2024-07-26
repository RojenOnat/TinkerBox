
using System;
using System.Collections;
using System.Collections.Generic;
using _TinkerBox.Script.Base;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class BotTextHolder : TextBase
{
    
    /// <summary>
    /// Table holded value.
    /// </summary>
    public int HoldedValue;
    
    [Tooltip("Text mesh pro component")]
    [SerializeField]private TextMeshProUGUI _bot_TMP;
    public override TextMeshProUGUI TMP { get; set; }

    public int RandomMin;
    public int RandomMax;

    [Range(0, 10)] public int PossibilityOfShowingText;
    
    public bool ShowText;

    private TextInstantor _textInstantor;
    
    public override void SetText(TextMeshProUGUI tmp, string value)
    {
        base.SetText(tmp,value);
    }

    private void Awake()
    {
        _textInstantor = GetComponent<TextInstantor>();
    }

    private void SetTMPEnable(bool isEnable)
    {
        _bot_TMP.gameObject.SetActive(isEnable);
    }

    public void CalculateOfPosibilityOfShowingText()
    {
        var a = Random.Range(0, 10);
        
        if (a > PossibilityOfShowingText)
        {
            TextDisable();
            GetComponent<BotColorChanger>().SetColor(Color.gray);
        }
        else
        {
            TextEnable();
        }

        SetTMPEnable(true);
    }
    
    public void TextDisable()
    {
        ShowText = false;
        SetText(_bot_TMP,"?");

    }

    public void TextEnable()
    {
        SetTMPEnable(true);
        ShowText = true;
        SetText(_bot_TMP,HoldedValue.ToString("0"));
            _textInstantor.InstText(HoldedValue);
    }
    private int GetRandomValue()
    {
        HoldedValue = Random.Range(RandomMin, RandomMax);
        return HoldedValue ;
    }

    private void Update()
    {
        _bot_TMP.transform.DOLookAt(-Camera.main.transform.position, 0.01f, AxisConstraint.X);
    }

    public void DecreaseHoldedText(int value)
    {
        HoldedValue -= value;
        SetText(_bot_TMP,HoldedValue.ToString("0"));
        
        if(HoldedValue<=0) SetTMPEnable(false);
    }

    public void SetHoldedValue(int v)
    {
        HoldedValue = v;
        
    }
}
