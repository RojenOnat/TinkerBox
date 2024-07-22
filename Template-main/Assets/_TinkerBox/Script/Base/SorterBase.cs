using System.Collections.Generic;
using UnityEngine;

namespace _TinkerBox.Script.Base
{
    public abstract class SorterBase : MonoBehaviour
    {
        public virtual void SortItems(List<GameObject> sortedItems,int count,Vector3 startPos,float offset)
        {
            
            for (int i = 0; i < count; i++)
            {
                Vector3 toPosition = startPos - new Vector3(0,
                    sortedItems[i].transform.position.y,
                    (i * offset));
                
                if (sortedItems[i].transform.position != toPosition)
                {
                    Debug.Log("Must Move");
                    sortedItems[i].transform.position = toPosition;
                }
                
            }
        }
    }
}