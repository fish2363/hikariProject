using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum NodeSaveType
{
   None,
   Register,
   Pool
}

public interface IOwnable
{
   Node Parent { get; set; }
   void SetParent(Node parent);
}

public class NULL { }

public abstract class NodeSendData
{
   public NodeSendData(Node sender)
   {
      _sender = sender;
   }

   private Node _sender;
   public Node Sender => _sender;
}

public abstract class NodeSendObject : ScriptableObject
{
   public virtual void Initialize(Node sender)
   {
      _sender = sender;
   }

   private Node _sender;
   public Node Sender => _sender;
}



public abstract class Node : MonoBehaviour
{
   public bool isFreeze;
   public LensType TargetLens { get; }
   public NodeSaveType nodeSaveType = NodeSaveType.None;

   public abstract void Initialize();
   public abstract void Dispose();

   public NodePool _nodePool = null;
   public NodeRegister _nodeRegister = null;

   protected Node Instance => this;

   public virtual void Receive(Node node) { }
   public virtual void Receive(NodeSendData send) { }
   public virtual void Receive(NodeSendObject send) { }
   public virtual void Receive<T,S>((T data, S sender) data) 
      where T : struct
      where S : Node{ }



   #region Normal&Pool Logic
   public T MakeNode<T>(T prefab, Node parentNode = null, Transform parentTrm = null,
      bool isPoolable = false, Action<T> Callback = null)
      where T : Node
   {
      T result;

      string typeName = typeof(T).ToString();
      result = Instantiate(prefab, parentTrm);
      Callback?.Invoke(result);
      result.Initialize();

      (result as IOwnable)?.SetParent(parentNode ?? this);

      result.nodeSaveType = isPoolable ? NodeSaveType.Pool : NodeSaveType.None;

      if (isPoolable && _nodePool is null)
         _nodePool = new NodePool(this);

      return result;
   }

   public T PopNode<T>(Node parentNode = null, Transform parentTrm = null) where T : Node
   {
      if (!_nodePool.Pop(parentNode, out T popResult))
         Debug.LogError($@"ERROR :: In {gameObject.name}, 
pool has no {typeof(T).ToString()} node. ");
      return popResult;
   }


   public Node PopNode(Type t, Node parentNode = null, Transform parentTrm = null)
   {
      if (!_nodePool.Pop(parentNode, out Node popResult))
         Debug.LogError($@"ERROR :: In {gameObject.name}, 
pool has no {t.ToString()} node. ");
      return popResult;
   }
   #endregion
   #region Registe Logic
   public T MakeRegiste<T>(T prefab, Node parentNode = null, Transform parentTrm = null, Action<Node> Callback = null)
      where T : Node
   {
      T result;
      result = Instantiate(prefab, parentTrm);
      result.isFreeze = true;

      Callback?.Invoke(result);

      result.Initialize();
      (result as IOwnable)?.SetParent(parentNode ?? this);

      result.nodeSaveType = NodeSaveType.Register;

      if (_nodeRegister is null)
         _nodeRegister = new NodeRegister(this);

      Registe(result);

      return result;
   }

   public Node MakeRegiste(Node prefab, Type t, Node parentNode = null, Transform parentTrm = null, Action<Node> Callback = null)
   {
      Node result;
      string typeName = t.ToString();
      result = Instantiate(prefab, parentTrm);
      result.isFreeze = true;

      Callback?.Invoke(result);
      result.Initialize();
      (result as IOwnable)?.SetParent(parentNode ?? this);

      result.nodeSaveType = NodeSaveType.Register;

      if (_nodeRegister is null)
         _nodeRegister = new NodeRegister(this);

      Registe(result);

      return result;
   }

   public void Registe(Node node)
      => _nodeRegister.Registe(node);

   public void DeRegiste(Node node)
      => _nodeRegister.DeRegiste(node);
   #endregion



   public void ReturnNode(Node target)
   {
      switch (target.nodeSaveType)
      {
         case NodeSaveType.None:
            Destroy(target.gameObject);
            break;

         case NodeSaveType.Pool:
            _nodePool.Push(target);
            break;

         case NodeSaveType.Register:
            _nodeRegister.Registe(target);
            break;
      }
   }

}


public abstract class OwnableNode<T> : Node, IOwnable
   where T : Node
{
   protected T _parent;
   public Node Parent { get => _parent; set => _parent = value as T; }

   public virtual void SetParent(Node parent)
      => Parent = parent;

   protected void Send(NodeSendData data)
      => _parent?.Receive(data);

   protected void Send(NodeSendObject obj)
      => _parent?.Receive(obj);

   protected void Send()
      => _parent?.Receive(this);

   protected void Send<D,S>((D data, S Sender) send) 
      where D : struct
      where S : Node
      => _parent?.Receive(send);
}

public static class ReceiveCastHelper
{
   public static void OnCastSuccess<D, T>(this NodeSendData data, Action<D> SuccessCallback)
      where T : Node
      where D : NodeSendData
   {
      T castedNode = (data.Sender as T);
      D castedData = (data as D);

      if (castedNode is not null && castedData is not null)
         SuccessCallback?.Invoke(castedData);
   }

   public static void OnCastSuccess<D, T>(this NodeSendObject data, Action<D> SuccessCallback)
   where T : Node
   where D : NodeSendObject
   {
      T castedNode = (data.Sender as T);
      D castedData = (data as D);

      if (castedNode is not null && castedData is not null)
         SuccessCallback?.Invoke(castedData);
   }

   public static void OnCastSuccess<D, S>(this (object data, object sender) send, Action<D> SuccessCallback)
      where D : struct
      where S : class
   {
      if ((send.sender as S is not null)
         && send.data.GetType() == typeof(D))
         SuccessCallback?.Invoke((D)send.data);
   }


   public static void OnCastSuccess<S>(this object sender, Action<S> SuccessCallback)
      where S : class
   {
      if (sender as S is not null)
         SuccessCallback?.Invoke(sender as S);
   }

}
