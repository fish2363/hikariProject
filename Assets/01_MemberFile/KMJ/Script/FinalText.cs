using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class FinalText : MonoBehaviour
{
    public static bool _isStart;

    private void Awake()
    {
        _isStart = false;
    }

    private void OnEnable()
    {
        PlayerChatBoxManager.Instance.Show("���̷����� ������", 3, true)
           .Show("���� �������̾� ���� Ż������!", 3.5f, true)
           .End();
    }

    private void Update()
    {
    }
}
