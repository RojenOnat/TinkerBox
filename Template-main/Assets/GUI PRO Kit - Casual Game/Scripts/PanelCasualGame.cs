using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;

namespace LayerLab
{
    public class PanelCasualGame : MonoBehaviour
    {
        [SerializeField] private GameObject[] otherPanels;
        public RectTransform TopRect;
        public RectTransform ButtonRect;
         public List<RectTransform> StarList;
         public bool IsSucces;
        public void OnEnable()
        {
            TopRect.DOAnchorPosY(230, 0.25f).SetEase(Ease.OutBack).OnComplete(() =>ButtonRect.gameObject.SetActive(true) );
            if(IsSucces)StartCoroutine(StarEnable());
        }

        private IEnumerator StarEnable()
        {
            yield return new WaitForSeconds(.8f);
            for (int i = 0; i < StarList.Count; i++)
            {
                StarList[i].gameObject.SetActive(true);
                StarList[i].DOScale(StarList[i].transform.localScale.x+10f, 0.1f).SetEase(Ease.Linear).SetLoops(2, LoopType.Yoyo).SetDelay(i * 0.05f);
                yield return new WaitForSeconds(.1f);

            }
        }


        public void OnDisable()
        {
            for (int i = 0; i < otherPanels.Length; i++) otherPanels[i].SetActive(false);
        }
    }
}
