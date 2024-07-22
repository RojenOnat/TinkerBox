using System;
using System.Collections;
using System.Collections.Generic;
using _TinkerBox.Script.Base;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class TableTextHolder : TextBase
{

    /// <summary>
    /// Table holded value.
    /// </summary>
    public int HoldedValue;

    private int _holdedPoint;
    public int CurrentHoldedValue;
    private ChairSetter _chairSetter;
    [Tooltip("Text mesh pro component")]
    [SerializeField]private TextMeshProUGUI _table_TMP;

    private SliderProgressController _sliderProgressController;
    public override TextMeshProUGUI TMP { get; set; }


    public override void SetText(TextMeshProUGUI tmp, string value)
    {
        base.SetText(tmp,value);
    }

    private void Awake()
    {
        TableInit();
    }

    private void Start()
    {
        _sliderProgressController = FindObjectOfType<SliderProgressController>();
        _chairSetter = GetComponent<ChairSetter>();
    }

    public void TableInit()
    {
        CurrentHoldedValue = HoldedValue;
        _holdedPoint = HoldedValue;
        
        SetText(_table_TMP,HoldedValue.ToString());

    }

    public void RegenerateValue()
    {
        CurrentHoldedValue = _holdedPoint;
        HoldedValue = CurrentHoldedValue;
        SetText(_table_TMP,HoldedValue.ToString());

    }

    public void DecreaseHoldedValue(int value)
    {
        HoldedValue -= value;
        SetText(_table_TMP,HoldedValue.ToString());

        if (HoldedValue == 0)
        {
            //Todo:puan ekle
            _sliderProgressController.RaiseSlider(_holdedPoint);
            Debug.LogError("Table Done!");
            GetComponent<TableSuccesProcces>().OnSucces();
            _chairSetter.ChairScaler();
        }
    }

    public void SetCurrentHoldedValue(int value) => CurrentHoldedValue -= value;
    

}
