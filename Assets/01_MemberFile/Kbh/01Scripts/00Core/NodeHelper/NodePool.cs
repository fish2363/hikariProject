using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodePool
{
   private Node _owner;
   private Dictionary<Type, Stack<Node>> _nodePoolDictionary;

   public NodePool(Node owner)
   {
      _owner = owner;
      _nodePoolDictionary = new Dictionary<Type, Stack<Node>>();
   }

   public bool Push(Node node)
   {
      if (node is null || node.isFreeze || node.nodeSaveType != NodeSaveType.Pool) return false;

      Type nodeType = node.GetType();

      if (!_nodePoolDictionary.TryGetValue(nodeType, out Stack<Node> stack))
         _nodePoolDictionary[nodeType] = new Stack<Node>();

      node.Dispose();
      node.isFreeze = true;
      node.gameObject.SetActive(false);
      stack.Push(node);

      return true;
   }

   public bool Pop<T>(Node parentNode, out T result)
      where T : Node
   {
      Type nodeType = typeof(T);
      if (!_nodePoolDictionary.TryGetValue(nodeType, out Stack<Node> stack)
          || stack.Count == 0)
      {
         result = null;
         return false;
      }
      else
      {
         Node node = stack.Pop();
         node.isFreeze = false;
         node.gameObject.SetActive(true);

         (node as IOwnable)?.SetParent(parentNode);
         node.Initialize();
         result = node as T;
         return true;
      }
   }

}
