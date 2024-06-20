using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WifiWindow : MonoBehaviour
{
    [SerializeField] private GameObject wifiWindow;
    [SerializeField] private TextMeshProUGUI text;

    private void Awake()
    {
        wifiWindow.SetActive(false);
    }


    public void OnClickBack() // �ڷΰ��� ��ư ���� ��
    {
        wifiWindow.SetActive(false);
    }

    public void OnClickConnection() // ���� ��ư�� ���� ��
    {
        if (WiFiManager.instance.WifiOnOff == true) // ������ ������ ��
        {
            WiFiManager.instance.WifiOnOff = false; // ���� ����
            text.text = "���� �� ��";
        }

        else
        {
            WiFiManager.instance.WifiOnOff = true; // �����ϱ�
            text.text = "�����";
        }
    }
}
