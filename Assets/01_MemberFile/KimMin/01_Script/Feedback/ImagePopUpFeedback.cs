using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImagePopUpFeedback : Feedback
{
    [SerializeField] private GameObject _popUpObject;
    [SerializeField] private GameObject _spawnTrm;

    [Range(0, 30)]
    [SerializeField] private float _spawnTime;

    public override void PlayFeedback()
    {
        PopUpCoroutine();
    }

    public override void StopFeedback()
    {
        
    }

    private Vector2 GetSpawnPos() //���� ��ġ ���� �żҵ�
    {
        Vector2 spawnPos = Camera.main.ViewportToScreenPoint(new Vector2(
            Random.Range(0.25f, 0.75f), Random.Range(0.25f, 0.75f)));

        return spawnPos;
    }

    private void GeneratePopUp()
    {
        Vector3 spawnPos = GetSpawnPos(); //���� ��ġ ����
        GameObject popUpObject = Instantiate(_popUpObject, spawnPos, Quaternion.identity,
            _spawnTrm.transform);
    }

    private IEnumerator PopUpCoroutine()
    {
        yield return new WaitForSeconds(_spawnTime);
        GeneratePopUp();
    }
}
