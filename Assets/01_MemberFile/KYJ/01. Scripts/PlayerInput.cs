using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInput : PlayerMovement
{
    [SerializeField] private GameObject SettingWindow;

    private void Awake()
    {
        SettingWindow.SetActive(false);
    }


    private void Update()
    {
        SettingWindowOn();
    }


    private void SettingWindowOn() // esc Ű�� ���� ��
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SettingWindow.SetActive(true); // ����â Ȱ��ȭ
        }
    }
}
