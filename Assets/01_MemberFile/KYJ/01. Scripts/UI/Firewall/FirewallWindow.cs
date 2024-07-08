using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FirewallWindow : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text; // �������� ���� ���� �ؽ�Ʈ

    private void Awake()
    {
        gameObject.SetActive(false);
    }

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
    public void OnClickBack() // �ڷΰ��� ��ư ���� ��
    {
        gameObject.SetActive(false);
    }

}
