using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FirewallManger : Monosingleton<FirewallManger>
{
    private bool isCool;
    [SerializeField] private bool virusOnOff;
    [SerializeField] private bool firewallOnOff; // �������� �ߵ� ����
    public bool FirewallOnOff
    {
        get
        {
            return firewallOnOff;
        }
        set
        {
            firewallOnOff = value;
        }
    }

    [SerializeField] private TextMeshProUGUI text; // �������� ���� ���� �ؽ�Ʈ

    private WiFiManager wifiManager;


    private void Awake()
    {
        wifiManager = GameObject.Find("WiFiManager").GetComponent<WiFiManager>();
    }


    private void Update()
    {
        VirusOnOff();
        StartCoroutine(WifiCool());
    }


    private void VirusOnOff() // ���̷��� ���� ��ȭ�� �¿���
    {
        if (virusOnOff == true)
        {
            firewallOnOff = false;
        }
        else
        {
            firewallOnOff = true;
        }
    }

    private IEnumerator WifiCool() // �������� ���� ���� ��Ÿ��
    {
        if (firewallOnOff == false && isCool == false) // ��ȭ�� ���� ������ ��
        {
            isCool = true;
            int rand1 = Random.Range(3, 10);
            yield return new WaitForSeconds(rand1);
            wifiManager.RandomOnOff(0f, 50f); // �������� �ٿ� Ȯ�� ��
            print("Ȯ�� ��!");
            isCool = false;
        }
        else if (firewallOnOff == true && isCool == false)
        {
            isCool = true;
            int rand = Random.Range(3, 10);
            yield return new WaitForSeconds(rand);
            wifiManager.RandomOnOff(0f, 20f); // Ȯ�� �״��
            print("Ȯ�� ����!");
            isCool = false;
        }
    }
}
