using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotCreator : MonoBehaviour
{
    [SerializeField] private GameObject _botPrefab;

    private BotListBase _bListBase;
    private BotPositionSetter _bPositionSetter;
    private RandomValueHolder _randomValueHolder;
    
    [SerializeField]private int _startBotCount;
    private bool _canControl = false;


    public int LevelBotCount;
    private void Start()
    {
        _randomValueHolder = FindObjectOfType<RandomValueHolder>();
        _bListBase = GetComponent<BotListBase>();
        _bPositionSetter = GetComponent<BotPositionSetter>();

        StartCoroutine(CreateBotByDelay(0.1f, _startBotCount));
    }

    
    /// <summary>
    /// Create new bot.
    /// </summary>
    /// <param name="botCount"></param>
    /// <param name="botInstPos"></param>
    public void CreateANewBot(int botCount)
    {
        //if(LevelBotCount<=0) return;
        
        //_bListBase.BotList.Count+1
        var goTo = _bPositionSetter.StartPos.position-new Vector3(0,0,10);
   
        for (int i = 0; i < botCount; i++)
        {
            GameObject go = Instantiate(_botPrefab, goTo, Quaternion.identity);
            _bListBase.BotList.Add(go);
            go.GetComponent<BotTextHolder>().SetHoldedValue(_randomValueHolder.GetValue());

            if(_bListBase.BotList.Count == 0) go.GetComponent<BotTextHolder>().TextEnable();
            else
                go.GetComponent<BotTextHolder>().CalculateOfPosibilityOfShowingText();

            
            LevelBotCount--;
        }
       
    }

    private void Update()
    {
        if (_bListBase.BotList.Count<10 && _canControl && LevelBotCount >0)
        {
            CreateANewBot(1);
        }
    }

    IEnumerator CreateBotByDelay(float delay,int botCount)
    {
        for (int i = 0; i < botCount; i++)
        {
            CreateANewBot(1);
            yield return new WaitForSeconds(delay);
        }

        _canControl = true;
    }
   

 

  
}
