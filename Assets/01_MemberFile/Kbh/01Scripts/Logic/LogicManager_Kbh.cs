using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LogicManager_Kbh : MonoSingleton<LogicManager_Kbh>
{
   /// [�ʼ� ��ҵ�]
   /// 
   /// �÷��̾�
   /// �÷��̾� �ൿ��
   /// ���� ���� ����Ʈ
   /// ������ ��ɵ�
   /// �г� ����
   /// 

   [SerializeField] private GameLogic_Kbh _logicAgent;

   private void Awake()
   {
      _logicAgent.Initialize(this, null, null);
   }

   public void DoTutorial()
   {

   }




}
