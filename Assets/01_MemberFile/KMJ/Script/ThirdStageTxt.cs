using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class ThirdStageTxt : MonoBehaviour
{
    private Sequence _textSequence;
    [SerializeField] private Text _text;

    private void Awake()
    {
        _textSequence = DOTween.Sequence()
            .Append(_text.DOText("���̷����� ����.", 2))
            .AppendInterval(1f)
            .Append(_text.DOText("", 1))
            .Append(_text.DOText("������ ����Ǿ����ϴ�.", 2.3f))
            .AppendInterval(1f)
            .Append(_text.DOFade(0, 3));
    }

    private void Start()
    {
        _textSequence.Play();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            _text.enabled = false;
    }
}
