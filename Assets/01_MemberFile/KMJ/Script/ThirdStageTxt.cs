using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class ThirdStageTxt : MonoBehaviour
{
    private Sequence _textSequence;
    [SerializeField] private TextMeshProUGUI _text;

    private void Awake()
    {
    }

    private void Start()
    {
    }

    private void OnEnable()
    {
        PlayerChatBoxManager.Instance.Show("���̷����� ������ ���Ҿ�!", 3, true)
            .Show("��ǳ�⸦ Ȱ���� �������� �ö���!", 3.5f, true)
            .End();
    }

    private void Update()
    {
    }
}
