using UnityEngine;


/// <summary>
/// ��� ������� ���Ⱕ�� �ɰ��� �� ��
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class Get<T>
   where T : class, IData
{
   protected Transform _trm = null;
   [SerializeField] protected string _path = string.Empty;
   [SerializeField] public T data = null;

   public void Initialize(Transform trm)
   {
      _trm = trm;
      TryInitComponent();
   }

      public void TryInitComponent()
      => data = Find();

   protected abstract T Find();
}
