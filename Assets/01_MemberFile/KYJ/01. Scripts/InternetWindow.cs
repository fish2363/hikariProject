using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InternetWindow : MonoBehaviour
{
    [SerializeField] private GameObject internetWindow;
    [SerializeField] private GameObject wifiWindow;



    void Awake()
    {
        internetWindow.SetActive(false);
    }

    

    public void OnClickBack() // �ڷΰ��� ��ư ���� ��
    {
        internetWindow.SetActive(false); 
    }

    public void OnClickReadMore() // �ڼ������� ��ư ���� ��
    {
        wifiWindow.SetActive(true);
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
