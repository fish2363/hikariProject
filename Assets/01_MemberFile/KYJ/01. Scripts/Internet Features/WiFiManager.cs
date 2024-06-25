using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WiFiManager : MonoBehaviour
{
    public static WiFiManager instance = null;

    [SerializeField] private bool wifiOnOff; // �������� �ߵ� ����
    [SerializeField] private TextMeshProUGUI text; // �������� ���� ���� �ؽ�Ʈ

    private PlayerMovement playerMovement;

    private bool isCool = true; // ��Ÿ�� ����


    public bool WifiOnOff
    {
        get
        {
            return wifiOnOff;
        }
        set
        {
            wifiOnOff = value;
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

        playerMovement = FindObjectOfType<PlayerMovement>();
    }


    private void Update()
    {
        if(isCool == true)
        StartCoroutine(WifiCool());

        WifiConnection();


        if (WifiOnOff == false) // �������� ���� ������ ��
        {
            playerMovement.Buffering(); // ���۸� ��� 
        }
        else
        {
            playerMovement.PlayerMove(4f); // �ƴϸ� �׳� �̵� ���
        }
    }


    public void RandomOnOff(float a, float b) // �������� �������� �¿���
    {
        float rand = Random.Range(a, b);

        if (rand < b)
        {
            wifiOnOff = false;
        }
        else
        {
            wifiOnOff = true;
        }
    }

    private void WifiConnection() // �������� ���� �� �ؽ�Ʈ ����
    {
        if (WifiOnOff == true) // ������ ������ ��
        {
            text.text = "�����";
        }

        else
        {
            text.text = "���� �� ��";
        }
    }

    private IEnumerator WifiCool() // �������� ���� ���� ��Ÿ��
    {
        isCool = false;
        if (wifiOnOff == true)
        {
            int rand = Random.Range(3, 10);
            yield return new WaitForSeconds(rand);
            RandomOnOff(0f, 20f);
            print("����");
        }
        isCool = true;
    }
}
