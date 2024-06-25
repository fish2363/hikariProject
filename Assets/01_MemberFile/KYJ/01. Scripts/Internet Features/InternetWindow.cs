using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InternetWindow : MonoBehaviour
{

    private void Awake()
    {
        gameObject.SetActive(false);
    }

    public void OnClickBack() // �ڷΰ��� ��ư ���� ��
    {
        gameObject.SetActive(false);
    }

    public void OnClickWifi() // �������� ��ư ���� ��
    {
        if (WiFiManager.instance.WifiOnOff == false) // �������� ������ ��
        {
            WiFiManager.instance.WifiOnOff = true; // �������� �����ϱ�
        }
        else
        {
            WiFiManager.instance.WifiOnOff = false;
        }
    }
}
