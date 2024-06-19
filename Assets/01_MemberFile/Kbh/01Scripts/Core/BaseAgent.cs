using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// BaseAgent�� BaseTag�� ��ӹް� �ִ�.
/// ������Ʈ��� �翬�� ������ �Ѵٰ� �����Ǵ� ����
/// ���´�. 
/// </summary>
public interface IBase
{
   void Initialize();
   void BaseUpdate();
}

/// <summary>
/// �����͸� ������ Tag�� ���� �������̽��̴�. 
/// </summary>
/// <typeparam name="D">
/// � ������ Ÿ���̵� �� �� �ִ�. 
/// </typeparam>
public interface INext<D>
{
   D Current { get; set; }
}


/// <summary>
/// Base Agent�� ��.��.��. Tag�� ������ �����ϵ�,
/// �ٸ� ���Ӽ��� ������ �ʵ��� �����ؾ� �Ѵ�.
/// </summary>
public abstract class BaseAgent : MonoBehaviour, IBase
{
   /// <summary>
   /// �⺻ ������ ���־�� �Ѵ�. 
   /// </summary>
   public abstract void Initialize();

   /// <summary>
   /// � ��ũ�� ������Ʈ ��ų �������� ���� ������ ����� �Ѵ�. 
   /// </summary>
   public abstract void BaseUpdate();
}