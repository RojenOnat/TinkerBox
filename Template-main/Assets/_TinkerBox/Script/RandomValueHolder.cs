using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomValueHolder : MonoBehaviour
{
   
   public List<int> RandomValues;

   [Range(1,10)] public int value1;
   [Range(1,10)] public int value2;
   [Range(1,10)] public int value3;
   [Range(1,10)] public int value4;
   [Range(1,10)] public int value5;

   public List<ChairSetter> C;
   /*private void Awake()
   {
      //CreateRandomValue(20);
      for (int i = 0; i < 10; i++)
      {
         Denem();
      }      
   }

   public void Denem()
   {
      List<int> t = new List<int>();
      for (int i = 0; i < 5; i++)
      {
         t.Add(Random.Range(1, 10));
      }

      var sum = 0;

      for (int i = 0; i < 5; i++)
      {
          sum+=t[i];
      }

      if (sum != 15)
      {
         Denem();
      }
      else
      {
         t.Add(Random.Range(1,6));
         t = ShuffleList(t);
         
         for (int i = 0; i < 6; i++)
         {
            RandomValues.Add(t[i]);
         }

         //RandomValues = ShuffleList(RandomValues);
      }
   }*/
   
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

   public int GetValue()
   {
      var a = RandomValues[0];
      RandomValues.Remove(a);
      return a;
   }

   private void Update()
   {
      if (RandomValues.Count<10)
      {
         //CreateRandomValue(1);
        
            C[Random.Range(0,C.Count-1)].CreateNumber();
         
      }
   }

   public void CreateRandomValue(int count)
   {

      for (int i = 0; i < count; i++)
      {
         var rnd = Random.Range(0, 10);

         if (rnd<=value1)
         {
            RandomValues.Add(1);

         }else if (rnd<=value2)
         {
            RandomValues.Add(2);

         }else if (rnd<=value3)
         {
            RandomValues.Add(3);
            
         }
         else if(rnd<=value4)
         {
            RandomValues.Add(4);
         }
         else
         {
            RandomValues.Add(5);

         }
            
      }
        
   }
   
}
