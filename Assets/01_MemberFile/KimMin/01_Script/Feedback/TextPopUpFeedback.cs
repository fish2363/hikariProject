using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class TextPopUpFeedback : Feedback
{
    [SerializeField] private TMP_Text _popUpText;
    [SerializeField] private GameObject _spawnTrm;

    [SerializeField] private float _interval; //생성되는 쿨타임
    [SerializeField] private float _duration; //글자가 떠있는 시간

    private string[] _popUpTexts =
    {
        "돌아가..",
        "너무 깊어..",
        "어둠",
        "도망쳐",
        "나가",
        "저리가"
    }; //랜덤으로 생성될 텍스트 메시지

    public override void PlayFeedback()
    {
        StartGenerateText();
    }

    public override void StopFeedback()
    {

    }


    private Vector2 GetSpawnPos() //스폰 위치 설정 매소드
    {
        Vector2 spawnPos = Camera.main.ViewportToScreenPoint(new Vector2(
            Random.Range(0.15f, 0.85f), Random.Range(0.15f, 0.85f)));
        return spawnPos;
    }

    private void GenerateText() //팝업 텍스트 생성
    {
        Vector3 spawnPos = GetSpawnPos(); //스폰 위치 설정
        Quaternion rotation = new Quaternion(0, 0, Random.Range(-15, 15), 180f);

        TMP_Text newText = Instantiate(_popUpText, spawnPos, rotation,
            _spawnTrm.transform); //텍스트 생성

        newText.text = $"{_popUpTexts[Random.Range(0, _popUpTexts.Length)]}"; //텍스트 글자 설정
        newText.DOFade(0, 0f);

        newText.DOFade(1, 0.5f);
        DOVirtual.DelayedCall(_duration - 1f, () => newText.DOFade(0f, 1f));

    }

    public void StartGenerateText() //이벤트 발동시 실행되는 매소드
    {
        StartCoroutine(GenerateTextCoroutine());
    }


    private IEnumerator GenerateTextCoroutine() //텍스트 생성 매소드를 실행시켜주는 코루틴
    {
        for (int i = 0; i < 10; i++)
        {
            GenerateText();
            yield return new WaitForSeconds(_interval);
        }
    }
}
