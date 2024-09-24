using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class CaptureStartText : MonoBehaviour
{
    private Sequence _textSequence;
    [SerializeField] private Text _text;
    [SerializeField] private GameObject _textMember;

    private void Awake()
    {
        _textSequence = DOTween.Sequence()
            .Append(_text.DOText("Esc�� �ִ� ĸ�ĸ� �̿���", 2.3f))
            .AppendInterval(1f)
            .Append(_text.DOText("", 1))
            .Append(_text.DOText("������ ĸ���ؼ�", 1.7f))
            .AppendInterval(1f)
            .Append(_text.DOText("", 1))
            .Append(_text.DOText("���� ���� �̵��ϼ���", 2))
            .AppendInterval(1f)
            .Append(_text.DOText("", 1))
            .Append(_text.DOText("������ FŰ�� �����ø�", 2))
            .AppendInterval(1f)
            .Append(_text.DOText("", 1))
            .Append(_text.DOText("�������������� �Ѿ�ϴ�", 2.5f))
            .Append(_text.DOFade(0, 3));
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
