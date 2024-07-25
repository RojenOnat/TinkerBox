using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayManager : MonoBehaviour
{
    public LayerMask NeededMask;
    
    public BotListBase BListBase;
    private GameObject _currentBot;
    
    private TableCalculator _tempTableCalculator;
    private TableTextHolder _tableTextHolder;
    private ChairSetter _chairSetter;
    private BotAIDestinationSetter _botAIDestinationSetter;
    private BotScaler _botScaler;
    private BotColorChanger _botColorChanger;
    private SliderProgressController _sliderProgressController;

    public GameObject TargetT;
    public FeedbackManager FManager;
    private AudioManager _aManager;

    private void Start()
    {
        _sliderProgressController = FindObjectOfType<SliderProgressController>();
        _aManager = FindObjectOfType<AudioManager>();
    }

    public GameObject Ray()
    {
        GameObject hitted = null;
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(ray, out RaycastHit hit,25f,NeededMask))
        {
            hitted = hit.collider.transform.parent.gameObject;
            SetTempTableCalculator(hitted.GetComponent<TableCalculator>());
            SetChairSetter(hitted.GetComponent<ChairSetter>());
            SetTableTextHolder(hitted.GetComponent<TableTextHolder>());
        }
        else
        {
            SetTempTableCalculator(null);
            SetChairSetter(null);
            SetTableTextHolder(null);
        }
        
        
        
        return hitted;
    }

    private void Update()
    {
        if(_sliderProgressController.IsComplete) return;
        if(!BListBase.CanClickable) return;
        
        if (Input.GetMouseButtonDown(0))
        {
            Ray();
            SetCurrentBot(BListBase.GetFirstBot());
            
            if(CurrentBotIsNull()) return;
            if(CurrentTableIsNull()) return;
            if (TableControl())
            {
                //Debug.Log("Bot Can Sit!!");
                FManager.OnSellectionVibrate();
                BListBase.BotList.Remove(_currentBot);
                _botAIDestinationSetter.target = InstTargetPoint().transform;
                _tableTextHolder.SetCurrentHoldedValue(_currentBot.GetComponent<BotTextHolder>().HoldedValue);
                _currentBot.GetComponent<TextInstantor>().TableObject = _tempTableCalculator.gameObject;
                _botScaler.SetStartScale();
            }
            else
            {
                //Debug.Log("BOT CANT SİT!");
                _aManager.PlayFalseSound();
                _botColorChanger.RedFlash();
            }
            
        }
        
        if(Input.GetMouseButtonUp(0)) OnResetScripts();
    }

    private void OnResetScripts()
    {
        SetBotScaler(null);
        SetBotDestinationSetter(null);
        SetChairSetter(null);
        SetBotColorChanger(null);
        SetCurrentBot(null);
        
    }
    private GameObject InstTargetPoint()
    {
        var t = _chairSetter.GetEmptyChairTransform();
        
        if (t == null) return null;
        
        return Instantiate(TargetT,t.position + (Vector3.up*0.5f), Quaternion.identity);

    }

    private void SetCurrentBot(GameObject go)
    {
        _currentBot = go;

        if (_currentBot != null)
        {
            SetBotDestinationSetter(_currentBot.GetComponent<BotAIDestinationSetter>());
            SetBotScaler(_currentBot.GetComponent<BotScaler>());
            SetBotColorChanger(_currentBot.GetComponent<BotColorChanger>());
        }
        else
            SetBotDestinationSetter(null);
    }
    private void SetTempTableCalculator(TableCalculator tCalculator) => _tempTableCalculator = tCalculator;
    private void SetChairSetter(ChairSetter c) => _chairSetter = c;
    private void SetBotDestinationSetter(BotAIDestinationSetter b) => _botAIDestinationSetter = b;
    private void SetBotScaler(BotScaler b) => _botScaler = b;
    private void SetBotColorChanger(BotColorChanger b) => _botColorChanger = b;
    private void SetTableTextHolder(TableTextHolder t) => _tableTextHolder = t;

    private bool CurrentBotIsNull()
    {
        if (_currentBot == null)
        {
            Debug.Log("Current Bot Is Null");
            return true;
        }

        return false;
    }

    private bool CurrentTableIsNull()
    {
        if (_tempTableCalculator == null)
        {
            Debug.Log("Current table Is Null");
            return true;
        }

        return false;
    }

    private bool TableControl()
    {
        return _tempTableCalculator.BotCanSit(_currentBot.GetComponent<BotTextHolder>().HoldedValue);
    }
}
