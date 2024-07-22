using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class TableSuccesProcces : MonoBehaviour
{

    private TableTextHolder _tableTextHolder;
    private TableBotHolder _tableBotHolder;
    private TableCapaticyHolder _tableCapaticyHolder;
    private void Start()
    {
        _tableTextHolder = GetComponent<TableTextHolder>();
        _tableBotHolder = GetComponent<TableBotHolder>();
        _tableCapaticyHolder= GetComponent<TableCapaticyHolder>();
    }

    public void OnSucces()
    {
        float f = 0;
        DOTween.To(x => f = x, 0, 1, .2f).SetEase(Ease.Linear).OnComplete(() =>
        {
            _tableBotHolder.ClearTable();
            _tableTextHolder.RegenerateValue();
            _tableCapaticyHolder.SetTableBoolState(true);
        });

    }
}
