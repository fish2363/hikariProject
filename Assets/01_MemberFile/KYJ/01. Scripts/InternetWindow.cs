using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InternetWindow : PlayerMovement
{
    [SerializeField] private GameObject internetWindow;
    [SerializeField] private GameObject wifiWindow;

    private PlayerInput playerInput;
    private PlayerMovement playerMovement;


    void Awake()
    {
        playerInput = FindObjectOfType<PlayerInput>();
        playerMovement = FindObjectOfType<PlayerMovement>();
        internetWindow.SetActive(false);
    }

    private void Update()
    {
        if (WiFiManager.instance.WifiOnOff == false)
        {
            playerInput.Buffering();
        }
        else
        {
            playerMovement.PlayerMove(4f);
        }
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
        if (WiFiManager.instance.WifiOnOff == false)
        {
            WiFiManager.instance.WifiOnOff = true;
        }
        else
        {
            WiFiManager.instance.WifiOnOff = false;
        }
    }
}
