using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class LastBotControl : MonoBehaviour // Start is called before the first frame update
{

    private BotListBase _bListBase;
 
    private void Start()
    {
        _bListBase = GetComponent<BotListBase>();
    }

    
    /// <summary>
    /// Will retun last index of botlist.
    /// </summary>
    /// <returns></returns>
    public GameObject GetLastBot()
    {
        if (_bListBase.BotList.Count > 0) return _bListBase.BotList[^1].gameObject;

        return null;
    }
    
    
    

   
}
