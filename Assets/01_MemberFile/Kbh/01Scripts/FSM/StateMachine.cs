using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StateMachine<T> where T : Enum
{
   [SerializeField] private T _currentState;
   [HideInInspector] public StatesReference<T> Reference;
   public T State => _currentState;
   public bool isJustEnter = false;
   private Dictionary<T, State<T>> _stateConditionDictionary
      = new Dictionary<T, State<T>>();

   public virtual void Initialize(MonoBehaviour owner, T defaultState)
   {

      // ��� State���� ����� �� �ִ� Reference���� ��Ƶ�. 
      Reference = owner.transform.Find("Conditions").GetComponent<StatesReference<T>>();

      // Dictionary �ʱ�ȭ
      var conditionCompos = owner.transform.Find("Conditions").GetComponents<State<T>>();
      for(int i = 0; i<conditionCompos.Length; ++i)
      {
         conditionCompos[i].Initialize(Reference);
         _stateConditionDictionary[conditionCompos[i].state] = conditionCompos[i];
      }

      ChangeState(_currentState);
   }

   public virtual void Update()
   {
      T result = State;
      isJustEnter = false;
      if (_stateConditionDictionary[_currentState].CanChangeToOther(ref result))
      {
         ChangeState(result);
      }
   }

   public virtual void ChangeState(T changeState)
   {
      _stateConditionDictionary[_currentState].Exit();
      _currentState = changeState;
      _stateConditionDictionary[changeState].Enter();
      isJustEnter = true;
   }

   public bool IsEqualWithType<S>(T checkingState) where S : State<T>
   {
      return _stateConditionDictionary[checkingState] is S;
   }
}

