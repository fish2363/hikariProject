using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FirewallWindow : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text; // �������� ���� ���� �ؽ�Ʈ


    public void FirewallConnection() // ��ȭ�� ���� �� �ؽ�Ʈ ����
    {
        if (FirewallManger.Instance.FirewallOnOff == true) // ������ ������ ��
        {
            FirewallManger.Instance.FirewallOnOff = false;
            text.text = "���� �� ��";
        }

        else
        {
            FirewallManger.Instance.FirewallOnOff = true;
            text.text = "�����";
        }
    }
}
