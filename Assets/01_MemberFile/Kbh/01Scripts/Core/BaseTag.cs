using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �⺻ �ױ��Դϴ�. �Ϲ����� ��쿡�� �̰��� ��ӹ��� ģ����
/// ������ ���� ����� �����ϰ� �� ���Դϴ�. 
/// </summary>
/// <typeparam name="D">
/// �� ������Ʈ�� ������ �� �������� Ÿ���� �����մϴ�. 
/// </typeparam>
public abstract class BaseTag<D> : IBase, INext<D>
{
   public D Current { get; set; }

   public abstract void Initialize();
   public abstract void BaseUpdate();
}

public abstract class MonoTag<D> : MonoBehaviour, IBase, INext<D>
{
   [field:SerializeField] public D Current { get; set; }

   public abstract void Initialize();
   public abstract void BaseUpdate();
}