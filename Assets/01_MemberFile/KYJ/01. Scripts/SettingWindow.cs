using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingWindow : MonoBehaviour
{
    [SerializeField] private GameObject internetWindow;
    [SerializeField] private GameObject settingWindow;

    private void Awake()
    {
        internetWindow.SetActive(false); // ���ͳ� ȭ�� ��Ȱ��ȭ
    }

    public void OnClickInternet() // �޴����� ���ͳ� ��ư ���� ��
    {
        internetWindow.SetActive(true); // ���ͳ� ȭ�� Ȱ��ȭ
    }

    public void OnClickBack() // �ڷΰ��� ��ư ���� ��
    {
        settingWindow.SetActive(false);
    }
}
