using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WiFiManager : Monosingleton<WiFiManager>
{
    private bool isCool = true; // 쿨타임 제어
    public bool WifiRandomOnOff; // 와이파이 랜덤 여부 제어

    [SerializeField] private bool wifiOnOff; // 와이파이 발동 여부

    [SerializeField] private TextMeshProUGUI text; // 와이파이 연결 여부 텍스트

    private PlayerMovement playerMovement;


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
        playerMovement = FindObjectOfType<PlayerMovement>();
    }


    private void Update()
    {
        if(isCool == true)
        StartCoroutine(WifiCool());

        WifiConnection();


        if (WifiOnOff == false) // 와이파이 연결 끊겼을 때
        {
            playerMovement.Buffering(); // 버퍼링 기능 
        }
        else
        {
            playerMovement.PlayerMove(4f); // 아니면 그냥 이동 기능
        }
    }



    public void RandomOnOff(float a, float b) // 랜덤으로 와이파이 온오프
    {
        float rand = Random.Range(a, b);

        if (rand <= b)
        {
            wifiOnOff = false;
        }
        else
        {
            wifiOnOff = true;
        }

    }

    private void WifiConnection() // 와이파이 연결 시 텍스트 변경
    {
        if (WifiOnOff == true) // 연결이 돼있을 때
        {
            text.text = "연결됨";
        }

        else
        {
            text.text = "연결 안 됨";
        }
    }

    private IEnumerator WifiCool() // 와이파이 랜덤 연결 쿨타임
    {
        isCool = false;
        if ( wifiOnOff == true)
        {
            int rand = Random.Range(3, 10);
            yield return new WaitForSeconds(rand);
            RandomOnOff(0f, 20f);
        }
        isCool = true;
    }
}
