using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FirewallWindow : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text; // �������� ���� ���� �ؽ�Ʈ

    void Awake()
    {
    }

    void Update()
    {
        
    }

    public void FirewallConnection() // ��ȭ�� ���� �� �ؽ�Ʈ ����
    {
        if (FirewallManger.instance.FirewallOnOff == true) // ������ ������ ��
        {
            FirewallManger.instance.FirewallOnOff = false;
            text.text = "���� �� ��";
        }

        else
        {
            FirewallManger.instance.FirewallOnOff = true;
            text.text = "�����";
        }
    }
}
