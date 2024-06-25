using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FirewallWindow : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text; // �������� ���� ���� �ؽ�Ʈ

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void FirewallConnection()
    {
        if (FirewallManger.instance.FirewallOnOff == true) // ������ ������ ��
        {
            WiFiManager.instance.WifiOnOff = false; // ���� ����
            text.text = "���� �� ��";
        }

        else
        {
            FirewallManger.instance.FirewallOnOff = true; // �����ϱ�
            text.text = "�����";
        }
    }
}
