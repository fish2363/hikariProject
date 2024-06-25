using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FirewallManger : MonoBehaviour
{
    public static FirewallManger instance = null;

    [SerializeField] private bool firewallOnOff; // �������� �ߵ� ����
    [SerializeField] private TextMeshProUGUI text; // �������� ���� ���� �ؽ�Ʈ

    private PlayerMovement playerMovement;

    [SerializeField] private bool virusOnOff;

    private bool isCool = true; // ��Ÿ�� ����


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
        if (instance == null) // �̱����Դϴ�
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }


    private void Update()
    {
        FirewallConnection();
        VirusOnOff();

        if (firewallOnOff == false) // ��ȭ�� ���� ������ ��
        {
            // �������� �ٿ� Ȯ�� ��
        }
        else
        {

        }
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

    private void FirewallConnection() // ��ȭ�� ���� �� �ؽ�Ʈ ����
    {
        if (firewallOnOff == true) // ������ ������ ��
        {
            text.text = "�����";
        }

        else
        {
            text.text = "���� �� ��";
        }
    }

    //private IEnumerator WifiCool() // �������� ���� ���� ��Ÿ��
    //{
    //    isCool = false;
    //    int rand = Random.Range(3, 10);
    //    yield return new WaitForSeconds(rand);
    //    RandomOnOff();
    //    print("����");
    //    isCool = true;
    //}
}
