using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class TextPopUpFeedback : Feedback
{
    [SerializeField] private TMP_Text _popUpText;
    [SerializeField] private GameObject _spawnTrm;

    [SerializeField] private float _interval; //�����Ǵ� ��Ÿ��
    [SerializeField] private float _duration; //���ڰ� ���ִ� �ð�

    private string[] _popUpTexts =
    {
        "���ư�..",
        "�ʹ� ���..",
        "���",
        "������",
        "����",
        "������"
    }; //�������� ������ �ؽ�Ʈ �޽���

    public override void PlayFeedback()
    {
        StartGenerateText();
    }

    public override void StopFeedback()
    {

    }


    private Vector2 GetSpawnPos() //���� ��ġ ���� �żҵ�
    {
        Vector2 spawnPos = Camera.main.ViewportToScreenPoint(new Vector2(
            Random.Range(0.15f, 0.85f), Random.Range(0.15f, 0.85f)));
        return spawnPos;
    }

    private void GenerateText() //�˾� �ؽ�Ʈ ����
    {
        Vector3 spawnPos = GetSpawnPos(); //���� ��ġ ����
        Quaternion rotation = new Quaternion(0, 0, Random.Range(-15, 15), 180f);

        TMP_Text newText = Instantiate(_popUpText, spawnPos, rotation,
            _spawnTrm.transform); //�ؽ�Ʈ ����

        newText.text = $"{_popUpTexts[Random.Range(0, _popUpTexts.Length)]}"; //�ؽ�Ʈ ���� ����

        newText.DOFade(0f, _duration); //������ �������
    }

    public void StartGenerateText() //�̺�Ʈ �ߵ��� ����Ǵ� �żҵ�
    {
        StartCoroutine(GenerateTextCoroutine());
    }

    private IEnumerator GenerateTextCoroutine() //�ؽ�Ʈ ���� �żҵ带 ��������ִ� �ڷ�ƾ
    {
        for (int i = 0; i < 10; i++)
        {
            GenerateText();
            yield return new WaitForSeconds(_interval);
        }
    }
}
