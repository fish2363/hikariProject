using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Diagnostics;
using System.Reflection;

public class AppDescription : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI descriptionText;
    public App currentAPP;

    [SerializeField]
    private GameObject descriptionPanel;



    public void DescriptionApp()
    {
        GetType().GetMethod($"{currentAPP}Description", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).Invoke(this, null);
        //GetType().GetMethod("currnetApp").Invoke(this, new object[] {3, 4 });
    }

    private void WeatherDescription()
    {
        descriptionPanel.SetActive(true);
        descriptionText.text = "���� ������ ���?";
    }

    private void ChromeDescription()
    {
        descriptionPanel.SetActive(true);
        descriptionText.text = "1��° ������ �ڷ� ã�⸦ ���ؼ� ������ ���̴�";
    }

    private void ExitDescription()
    {
        descriptionPanel.SetActive(true);
        descriptionText.text = "���� ������ �Ѽ� �ڰ��� �ؾ���";
    }

    private void YoutubeDescription()
    {
        descriptionPanel.SetActive(true);
        descriptionText.text = "��ī���� ���� �Ұ��������� ����Ǿ��ִ�";
    }

    private void HowControllDescription()
    {
        descriptionPanel.SetActive(true);
        descriptionText.text = "��� ������ �ؾ��ϴ��� ���۹��� �����ִ�";
    }
    private void PortPolioDescription()
    {
        descriptionPanel.SetActive(true);
        descriptionText.text = "��ī���� ��ǥ�Ϸ� �ٷ� �����ִ�";
    }
    private void PowerPointDescription()
    {
        descriptionPanel.SetActive(true);
        descriptionText.text = "2��° ������ ppt����⸦ �Ϸ����� ���̴�";
    }
    private void GameDescription()
    {
        descriptionPanel.SetActive(true);
        descriptionText.text = "�����ϰ� �ٿ�ε� �Ǿ��ִ� �����̴�";
    }
}
