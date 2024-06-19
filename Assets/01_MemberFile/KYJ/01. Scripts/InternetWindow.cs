using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Network : PlayerMovement
{
    [SerializeField] private GameObject internetWindow;
    [SerializeField] private GameObject wifiWindow;

    [SerializeField] private List<GameObject> wifiButton = new List<GameObject>(); // �������� ��ư��
    private PlayerMovement playerMove;
    private PlayerInput playerInput;


    void Awake()
    {
        internetWindow.SetActive(false); // ���ͳ� ȭ�� ��Ȱ��ȭ

        for (int i = 0; i < 2; i++)
        {
            wifiButton[i].SetActive(false); // �������� ��ư ��Ȱ��ȭ
        }

        wifiWindow.SetActive(false);

        playerMove = GameObject.Find("Player").GetComponent<PlayerMovement>();
        playerInput = GameObject.Find("Player").GetComponent<PlayerInput>();
    }

    private void Update()
    {
        //if (GameManager.instance.WifiOnOff == false)
        //{
        //    playerInput.Buffering();
        //}
        //else
        //{
        //    playerMove.PlayerMove(4f);
        //}
    }

    public void OnClickBack() // �ڷΰ��� ��ư ���� ��
    {
        internetWindow.SetActive(false); 

        for (int i = 0; i < 2; i++)
        {
            wifiButton[i].SetActive(false);
        }
    }

    public void OnClickInternet() // ���ͳ� ��ư ���� ��
    {
        internetWindow.SetActive(true);

        for (int i = 0; i < 2; i++)
        {
            wifiButton[i].SetActive(true);
        }
    }

    public void OnClickWifi() // �������� ��ư ���� ��
    {
        //if (GameManager.instance.WifiOnOff == false)
        //{
        //    GameManager.instance.WifiOnOff = true;
        //}
        //else
        //{
        //    GameManager.instance.WifiOnOff = false;
        //}
    }
}
