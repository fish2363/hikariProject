using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InternetWindow : MonoBehaviour
{
    private void Awake()
    {
        gameObject.SetActive(false); // ó���� ���ͳ� ȭ�� ��Ȱ��ȭ
    }

    public void OnClickBack() // �ڷΰ��� ��ư ���� ��
    {
        gameObject.SetActive(false); // ���ͳ� ȭ�� �ݱ�
    }

    public void OnClickWifi() // �������� ��ư ���� ��
    {
        if(WiFiManager.Instance.WifiOnOff == false) // �������� ������ ��
        {
            WiFiManager.Instance.WifiOnOff = true; // �������� �����ϱ�
        }
        else
        {
            WiFiManager.Instance.WifiOnOff = false;
        }
    }
}
