using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class ThirdStageTxt : MonoBehaviour
{
    public static bool _isStart;
    private Sequence _textSequence;
    [SerializeField] private TextMeshProUGUI _text;

    private void Awake()
    {
        _isStart = false;
    }

    private void Start()
    {
    }

    private void OnEnable()
    {
        PlayerChatBoxManager.Instance.Show("���̷����� ������ ���Ҿ�!", 3, true)
                    .Show("�� �ٷ� �ؿ� ���ĸ� ��ġ�ؼ� ���� �ö���!", 3.5f, true)
                    .End();
    }

    private void Update()
    { 
    }
}
