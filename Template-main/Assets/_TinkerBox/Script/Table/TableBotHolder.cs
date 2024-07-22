using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class TableBotHolder : MonoBehaviour
{
   public List<GameObject> HoldedBot;

   public void ClearTable()
   {

      FindObjectOfType<ReleaseButton>().ReleaseIt(HoldedBot);
      //StartCoroutine(Coro());
   }

   IEnumerator Coro()
   {
      for (int i = 0; i < HoldedBot.Count; i++)
      {
         var t = new GameObject();
         t.transform.position = new Vector3(0,0,15);
         //GameObject go = Instantiate(new GameObject(), new Vector3(0, 0, 10), Quaternion.identity);
         
         BotAnimatorController b = HoldedBot[i].GetComponent<BotAnimatorController>();
         BotAIDestinationSetter c = HoldedBot[i].GetComponent<BotAIDestinationSetter>();
         BotAIReachedController r =  HoldedBot[i].GetComponent<BotAIReachedController>();
         AIPath a = HoldedBot[i].GetComponent<AIPath>();
        

         //c.target = null;
         r.IsClearState = true;
         c.target = t.transform;
         b.SetWalkState(true);
         yield return new WaitForSeconds(0.2f);

      }
   }
}
