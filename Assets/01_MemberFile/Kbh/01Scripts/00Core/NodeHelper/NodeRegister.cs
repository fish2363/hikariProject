using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeRegister
{
   private Node _owner;
   private List<Node> _nodeList;

   public NodeRegister(Node owner)
   {
      _owner = owner;
      _nodeList = new List<Node>();
   }

   public void DeRegiste(Node node)
   {
      if (node is not null && _nodeList.Contains(node))
      {
         node.isFreeze = true;
         node.gameObject.SetActive(true);
         node.Initialize();
         _nodeList.Remove(node);
      }
   }

   public void Registe(Node node)
   {
      if (node is not null)
      {
         node.isFreeze = true;
         node.Dispose();
         node.gameObject.SetActive(false);
         _nodeList.Add(node);
      }
   }
}
