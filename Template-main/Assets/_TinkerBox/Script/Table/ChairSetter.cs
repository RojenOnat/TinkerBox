
using System;
using System.Collections.Generic;
using _TinkerBox.Script.Base.Resizer;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using Random = UnityEngine.Random;

public class ChairSetter : MonoBehaviour
{
    public GameObject ChairPrefab;
    public List<GameObject> ChairList;
    public int ChairCount;
    public float Radius;
    private TableCapaticyHolder _tableCapaticyHolder;
    private TableTextHolder _tableTextHolder;
    private RandomValueHolder _randomValueHolder;
    private void Awake()
    {
        _tableCapaticyHolder = GetComponent<TableCapaticyHolder>();
        _tableTextHolder = GetComponent<TableTextHolder>();
        _randomValueHolder = FindObjectOfType<RandomValueHolder>();
        
        CreateNumber();
    }

    private void Start()
    {
        if (ChairList.Count != _tableCapaticyHolder.TableCapacityList.Count)
        {
            Debug.LogError("Sandalye Sayısı ve Kapasite eşit değil");
        }
    }

    public void CreateNumber()
    {
        List<int> t = new List<int>();
        var a = Random.Range(2, ChairList.Count);
        //Debug.Log(a);
        for (int i = 0; i < a; i++)
        {
            t.Add(Random.Range(1, 8));
        }
        
        var sum = 0;

        for (int i = 0; i < a; i++)
        {
            sum+=t[i];
        }

        var total = 0;

        if (_tableTextHolder._holdedPoint == 0)
        {
            total = _tableTextHolder.HoldedValue;
        }
        else
        {
            total = _tableTextHolder._holdedPoint;
        }
        
        
        if (sum != total)
        {
            //Debug.LogError("Burda patladı" + total);
            CreateNumber();
        } else
        {
            t.Add(Random.Range(1,4));
            t = ShuffleList(t);
         
            for (int i = 0; i < a+1; i++)
            {
                _randomValueHolder.RandomValues.Add(t[i]);
            }

            //RandomValues = ShuffleList(RandomValues);
        }
    }
    public List < int > ShuffleList(List < int > list)
    {
        for (int i = list.Count - 1; i > 0; i--)
        {
            int j = UnityEngine.Random.Range(0, i + 1);
            int temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
        return list;
    }

    [Button]
    public void CreateChair()
    {
        ControlChairList();
        ChairInstantiator();
        GetComponent<TableCapaticyHolder>().TableCapacityList.Clear();

        for (int i = 0; i < ChairList.Count; i++)
        {
            GetComponent<TableCapaticyHolder>().TableCapacityList.Add(false);
        }
        //GetComponent<TableCapaticyHolder>().TableCapacityList = new List<bool>(ChairList.Count);

    }


    public Transform GetEmptyChairTransform()
    {
        Transform _tempChairT = null;
        
        for (int i = 0; i < ChairList.Count; i++)
        {
            if (!_tableCapaticyHolder.TableCapacityList[i])
            {
                _tempChairT = ChairList[i].transform;
                _tableCapaticyHolder.SetTableBoolState(i,true);
                break;
                
            }
        }

        return _tempChairT;
    }
    private void ChairInstantiator()
    {
        Circler.InstantiateInCircle(ChairPrefab,
            transform.position
            ,ChairCount,Radius
            ,transform.position.y
            ,ChairList
            ,transform);
    }

    public void ChairScaler()
    {
        float f = 0;

        DOTween.To(x => f = x, 0, 1, 0.20f).SetEase(Ease.Linear).OnComplete(() =>
        {
            for (int i = 0; i < ChairCount; i++)
            {
                ChairList[i].transform.DOLocalMoveY(1.75f, 0.1f).SetEase(Ease.Linear).SetLoops(2, LoopType.Yoyo)
                    .SetDelay(i * 0.05f);
            }
        });
       
    }

    private void ControlChairList()
    {
        if (ChairList.Count > 0)
        {
            for (int i = 0; i < ChairList.Count; i++)
            {
                DestroyImmediate(ChairList[i].gameObject);
            }
            
            ChairList.Clear();
        }
    }
}
