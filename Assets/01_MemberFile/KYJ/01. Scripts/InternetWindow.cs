using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InternetWindow : PlayerMovement
{
    [SerializeField] private GameObject internetWindow;
    [SerializeField] private GameObject wifiWindow;


    void Awake()
    {
         wifiWindow.SetActive(false);

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
    }

    public void OnClickReadMore() // �ڼ������� ��ư ���� ��
    {
        wifiWindow.SetActive(true);
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
