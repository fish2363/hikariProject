using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class SecondText : MonoBehaviour
{
    private Sequence _textSequence;
    [SerializeField] private Text _text;
    [SerializeField] private GameObject _textMember;

    private void Awake()
    {
        _textSequence = DOTween.Sequence()
            .Append(_text.DOText("������ ������ �����Դϴ�.", 2))
            .AppendInterval(1f)
            .Append(_text.DOText("", 1))
            .Append(_text.DOText("������ ���ӽð��� 6���Դϴ�.", 2.5f))
            .AppendInterval(1f)
            .Append(_text.DOText("", 1))
            .Append(_text.DOText("�������� �� ������ �������� �ʽ��ϴ�.", 3))
            .Append(_text.DOFade(0, 3));
        _textMember.SetActive(false);
    }

    private void Start()
    {
        _textSequence.Play();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            _textMember.SetActive(false);
    }
}
