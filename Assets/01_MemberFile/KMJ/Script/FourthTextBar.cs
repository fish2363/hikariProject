using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FourthTextBar : MonoBehaviour
{
    public static bool _isStart;
    private void OnEnable()
    {
        PlayerChatBoxManager.Instance.Show("�̹��� ���̷����� �������� ��� ���Ҿ�!", 3, true)
            .Show("�������̰� ���������� ���� �ö���!", 3.5f, true)
            .End();
    }
    private void Awake()
    {
        _isStart = false;
    }

    private void Update()
    {
    }
}
