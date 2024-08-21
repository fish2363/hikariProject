using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public static class NodeGetHelper
{
   
   public static List<Node> GetNodes(this Node parent)
   {
      Node[] nodes;
      List<Node> result = new List<Node>();
      nodes = parent.GetComponentsInChildren<Node>();

      for(int i = 0; i<nodes.Length; ++i)
      {
         if(nodes[i].TargetLens == parent.TargetLens)
         {
            if (nodes[i] == parent) continue;
            result.Add(nodes[i]);
         }
      }

      return result;
   }

   public static Node GetNode(this Node parent, string name = "")
   {
      Node[] nodes;
      nodes = parent.transform.Find(name).GetComponents<Node>();

      for (int i = 0; i < nodes.Length; ++i)
      {
         if (nodes[i].TargetLens == parent.TargetLens)
         {
            if (nodes[i] == parent) continue;
            return nodes[i];
         }
      }

      return null;
   }


   public static Node GetNode<T>(this Node parent)
      where T : Node
   {
      T[] nodes;
      nodes = parent.transform.GetComponentsInChildren<T>();

      for (int i = 0; i < nodes.Length; ++i)
      {
         if (nodes[i].TargetLens == parent.TargetLens)
         {
            if (nodes[i] == parent) continue;
            return nodes[i];
         }
      }



      return null;
   }

}
