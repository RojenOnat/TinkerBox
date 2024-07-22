using System.Collections.Generic;
using UnityEngine;

namespace _TinkerBox.Script.Base.Resizer
{
    public class Circler : MonoBehaviour
    {
        public static void InstantiateInCircle(GameObject prefab, Vector3 location,
            int howMany, float radius, float yPosition, List<GameObject> go, Transform parentObj)
        {
            float angleSection = Mathf.PI * 2f / howMany;
            for (int i = 0; i < howMany; i++)
            {
                float angle = i * angleSection;
                Vector3 newPos = location + new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * radius;
                newPos.y = yPosition;
                var a = Instantiate(prefab, newPos, prefab.transform.rotation);
                go.Add(a);
                a.transform.parent = parentObj;
            }
        }

        public static List<Vector3> GetCirclePosition(Vector3 location,
            int howMany, float radius, float yPosition)
        {
            List<Vector3> pos = new List<Vector3>(howMany);
            float angleSection = Mathf.PI * 2f / howMany;
            for (int i = 0; i < howMany; i++)
            {
                float angle = i * angleSection;
                Vector3 newPos = location + new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * radius;
                newPos.y = yPosition;
                pos[i] = newPos;
            }
            
            return pos;
        }
    }
}
