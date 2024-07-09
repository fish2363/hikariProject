using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingWindow : MonoBehaviour
{
    [SerializeField] private GameObject internetWindow;
    [SerializeField] private GameObject firewallWindow;
    [SerializeField] private GameObject settingWindow;
 
    private void Awake()
    {
        internetWindow.SetActive(false); // ���ͳ� ȭ�� ��Ȱ��ȭ
        firewallWindow.SetActive(false); // ��ȭ�� ȭ�� ��Ȱ��ȭ
    }

    public void OnClickInternet() // �޴����� ���ͳ� ��ư ���� ��
    {
        internetWindow.SetActive(true); // ���ͳ� ȭ�� Ȱ��ȭ
    }
    
    public void OnClickFirewall() // �޴����� ��ȭ�� ��ư ���� ��
    {
        firewallWindow.SetActive(true); // ��ȭ�� ȭ�� Ȱ��ȭ
    }

    public void OnClickBack() // �ڷΰ��� ��ư ���� ��
    {
        settingWindow.SetActive(false);
    }
}
