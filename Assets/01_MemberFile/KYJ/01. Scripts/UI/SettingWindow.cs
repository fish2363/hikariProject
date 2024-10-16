using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingWindow : MonoBehaviour
{
    [SerializeField] private GameObject internetWindow;
    [SerializeField] private GameObject firewallWindow;
    [SerializeField] private GameObject settingWindow;
 
    private void Awake()
    {
        internetWindow.SetActive(false); // 인터넷 화면 비활성화
        firewallWindow.SetActive(false); // 방화벽 화면 비활성화
    }

    public void OnClickInternet() // 메뉴에서 인터넷 버튼 누를 시
    {
        internetWindow.SetActive(true); // 인터넷 화면 활성화
    }
    
    public void OnClickFirewall() // 메뉴에서 방화벽 버튼 누를 시
    {
        firewallWindow.SetActive(true); // 방화벽 화면 활성화
    }

    public void OnClickBack() // 뒤로가기 버튼 누를 시
    {
        settingWindow.SetActive(false);
    }
}
