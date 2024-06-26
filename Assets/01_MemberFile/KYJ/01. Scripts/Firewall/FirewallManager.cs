using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FirewallManger : Monosingleton<FirewallManger>
{
    [SerializeField] private bool firewallOnOff; // �������� �ߵ� ����
    [SerializeField] private TextMeshProUGUI text; // �������� ���� ���� �ؽ�Ʈ

    [SerializeField] private TextMeshProUGUI wifi; // �������� ���� ���� �ؽ�Ʈ

    [SerializeField] private bool virusOnOff;
    private bool isCool;

    private WiFiManager wifiManager;


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
