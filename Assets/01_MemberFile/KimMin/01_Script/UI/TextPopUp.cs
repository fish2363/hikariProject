using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.Events;

public class TextPopUp : MonoBehaviour
{
    public UnityEvent OnPopUpEvent;

    [SerializeField] private TMP_Text _popUpText;
    [SerializeField] private GameObject _canvas;

    [SerializeField] private float _interval; //�����Ǵ� ��Ÿ��
    [SerializeField] private float _duration; //���ڰ� ���ִ� �ð�

    private Vector3 _maxSpawnPos;
    private Vector3 _minSpawnPos;

    private string[] _popUpTexts =
    {
        "Go Back",
        "Deep",
        "Darkness",
        "Run Away",
        "Get Out"
    }; //�������� ������ �ؽ�Ʈ �޽���

    private void Update()
    {
        GetSpawnPos(); //�÷��̾� ��ġ�� �����´�

        if (Input.GetKeyDown(KeyCode.R))
        {
            StartGenerateText();
        }
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
        Quaternion rotation = new Quaternion(0, 0, Random.Range(-30, 30), 180f);

        TMP_Text newText = Instantiate(_popUpText, spawnPos, rotation,
            _canvas.transform); //�ؽ�Ʈ ����

        newText.text = _popUpTexts[Random.Range(0, _popUpTexts.Length)]; //�ؽ�Ʈ ���� ����

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
